import { Capsule } from "@react-three/drei";

import { useFrame } from "@react-three/fiber";

import { useRef } from "react";

import keys from "../../game/controls";

export default function Fighter() {

  const fighterRef = useRef();

  useFrame(() => {

    if (!fighterRef.current) return;

    // Movement speed
    const speed = 0.1;

    // Forward
    if (keys["w"]) {
      fighterRef.current.position.z -= speed;
    }

    // Backward
    if (keys["s"]) {
      fighterRef.current.position.z += speed;
    }

    // Left
    if (keys["a"]) {
      fighterRef.current.position.x -= speed;
    }

    // Right
    if (keys["d"]) {
      fighterRef.current.position.x += speed;
    }

  });

  return (

    <Capsule
      ref={fighterRef}
      args={[0.5, 1.5, 8, 16]}
      position={[0, 1, 0]}
    >

      <meshStandardMaterial color="#00aaff" />

    </Capsule>
  );
}
