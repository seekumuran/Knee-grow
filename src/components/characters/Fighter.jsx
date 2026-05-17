import { Capsule } from "@react-three/drei";

import { useFrame } from "@react-three/fiber";

import {
  forwardRef,
  useRef
} from "react";

import keys from "../../game/controls";

const Fighter = forwardRef(function Fighter(
  {
    cameraRotation
  },
  ref
) {

  // Velocity
  const velocity = useRef({
    x: 0,
    z: 0
  });

  useFrame(() => {

    if (!ref.current) return;

    // Base speed
    let moveSpeed = 0.08;

    // Sprint
    if (keys["shift"]) {
      moveSpeed = 0.15;
    }

    let inputX = 0;
    let inputZ = 0;

    // Input
    if (keys["w"]) inputZ -= 1;
    if (keys["s"]) inputZ += 1;
    if (keys["a"]) inputX -= 1;
    if (keys["d"]) inputX += 1;

    // Normalize movement
    const length = Math.hypot(inputX, inputZ);

    if (length > 0) {

      inputX /= length;
      inputZ /= length;

      // Camera-relative movement
      const rotatedX =
        inputX * Math.cos(cameraRotation)
        - inputZ * Math.sin(cameraRotation);

      const rotatedZ =
        inputX * Math.sin(cameraRotation)
        + inputZ * Math.cos(cameraRotation);

      // Smooth acceleration
      velocity.current.x +=
        (rotatedX * moveSpeed - velocity.current.x)
        * 0.1;

      velocity.current.z +=
        (rotatedZ * moveSpeed - velocity.current.z)
        * 0.1;

      // Rotate player
      const angle =
        Math.atan2(rotatedX, rotatedZ);

      ref.current.rotation.y +=
        (angle - ref.current.rotation.y) * 0.1;

    } else {

      // Deceleration
      velocity.current.x *= 0.9;
      velocity.current.z *= 0.9;

    }

    // Apply movement
    ref.current.position.x += velocity.current.x;

    ref.current.position.z += velocity.current.z;

  });

  return (

    <Capsule
      ref={ref}
      args={[0.5, 1.5, 8, 16]}
      position={[0, 1, 0]}
      castShadow
    >

      <meshStandardMaterial color="#00aaff" />

    </Capsule>
  );
});

export default Fighter;
