import { Ring } from "@react-three/drei";

import { useFrame } from "@react-three/fiber";

import {
  useRef,
  useState
} from "react";

export default function Shockwave({
  position,
  onFinish
}) {

  const meshRef = useRef();

  const [scale, setScale] = useState(1);

  useFrame(() => {

    setScale((prev) => prev + 0.25);

    if (meshRef.current) {

      meshRef.current.material.opacity -= 0.03;

      if (
        meshRef.current.material.opacity <= 0
      ) {

        onFinish();

      }

    }

  });

  return (
    <Ring
      ref={meshRef}
      args={[1, 2, 32]}
      rotation={[-Math.PI / 2, 0, 0]}
      position={[
        position.x,
        position.y + 0.1,
        position.z
      ]}
      scale={scale}
    >

      <meshStandardMaterial
        color="#00ffff"
        emissive="#00ffff"
        emissiveIntensity={5}
        transparent
        opacity={0.8}
        side={2}
      />

    </Ring>
  );
}
