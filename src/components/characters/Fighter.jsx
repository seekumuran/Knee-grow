import { Capsule } from "@react-three/drei";

import { useFrame } from "@react-three/fiber";

import { forwardRef } from "react";

import keys from "../../game/controls";

const Fighter = forwardRef(function Fighter(
  {
    cameraRotation
  },
  ref
) {

  useFrame(() => {

    if (!ref.current) return;

    const speed = 0.1;

    let moveX = 0;
    let moveZ = 0;

    // Input
    if (keys["w"]) moveZ -= 1;
    if (keys["s"]) moveZ += 1;
    if (keys["a"]) moveX -= 1;
    if (keys["d"]) moveX += 1;

    // Normalize diagonal movement
    const length = Math.hypot(moveX, moveZ);

    if (length > 0) {

      moveX /= length;
      moveZ /= length;

      // Camera-relative movement
      const rotatedX =
        moveX * Math.cos(cameraRotation)
        - moveZ * Math.sin(cameraRotation);

      const rotatedZ =
        moveX * Math.sin(cameraRotation)
        + moveZ * Math.cos(cameraRotation);

      // Apply movement
      ref.current.position.x += rotatedX * speed;
      ref.current.position.z += rotatedZ * speed;

      // Rotate player
      const angle =
        Math.atan2(rotatedX, rotatedZ);

      ref.current.rotation.y +=
        (angle - ref.current.rotation.y) * 0.1;
    }

  });

  return (

    <Capsule
      ref={ref}
      args={[0.5, 1.5, 8, 16]}
      position={[0, 1, 0]}
    >

      <meshStandardMaterial color="#00aaff" />

    </Capsule>
  );
});

export default Fighter;
