import { Sphere } from "@react-three/drei";

import { useFrame } from "@react-three/fiber";

import { useRef } from "react";

export default function EnemyProjectile({
  position,
  direction,
  playerRef,
  onDestroy
}) {

  const meshRef = useRef();

  useFrame(() => {

    if (!meshRef.current) return;

    meshRef.current.position.x +=
      direction.x * 0.25;

    meshRef.current.position.z +=
      direction.z * 0.25;

    if (
      playerRef?.current?.position
    ) {

      const playerPosition =
        playerRef.current.position;

      const projectilePosition =
        meshRef.current.position;

      const distance =
        projectilePosition.distanceTo(
          playerPosition
        );

      if (distance < 2) {

        playerRef.current.takeDamage(
          20,
          direction
        );

        onDestroy();

      }

    }

    const travelled =
      meshRef.current.position.distanceTo({
        x: position.x,
        y: position.y,
        z: position.z
      });

    if (travelled > 40) {

      onDestroy();

    }

  });

  return (
    <Sphere
      ref={meshRef}
      args={[0.6, 16, 16]}
      position={[
        position.x,
        position.y,
        position.z
      ]}
    >

      <meshStandardMaterial
        color="#aa00ff"
        emissive="#aa00ff"
        emissiveIntensity={5}
      />

    </Sphere>
  );
}
