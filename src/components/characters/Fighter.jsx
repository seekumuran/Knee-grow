import { Capsule } from "@react-three/drei";

import { useFrame } from "@react-three/fiber";

import { forwardRef } from "react";

import keys from "../../game/controls";

const Fighter = forwardRef(function Fighter(props, ref) {

  useFrame(() => {

    if (!ref.current) return;

    const speed = 0.1;

    // Movement values
    let moveX = 0;
    let moveZ = 0;

    // Forward
    if (keys["w"]) {
      moveZ -= speed;
    }

    // Backward
    if (keys["s"]) {
      moveZ += speed;
    }

    // Left
    if (keys["a"]) {
      moveX -= speed;
    }

    // Right
    if (keys["d"]) {
      moveX += speed;
    }

    // Apply movement
    ref.current.position.x += moveX;
    ref.current.position.z += moveZ;

    // Rotate toward movement direction
    if (moveX !== 0 || moveZ !== 0) {

      const angle = Math.atan2(moveX, moveZ);

      ref.current.rotation.y = angle;

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
