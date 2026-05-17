import { Sphere } from "@react-three/drei";

import { useFrame } from "@react-three/fiber";

import { useRef } from "react";

export default function EnergyBlast({
  position,
  direction,
  enemyRef,
  onDestroy
}) {

  const blastRef = useRef();

  useFrame(() => {

    if (!blastRef.current) return;

    blastRef.current.position.x +=
      direction.x * 0.4;

    blastRef.current.position.z +=
      direction.z * 0.4;

    if (
      enemyRef?.current?.mesh
    ) {

      const enemyPosition =
        enemyRef.current.mesh.position;

      const blastPosition =
        blastRef.current.position;

      const distance =
        blastPosition.distanceTo(enemyPosition);

      if (distance < 2) {

        enemyRef.current.takeDamage(
          20,
          direction
        );

        onDestroy();

      }

    }

    const travelled =
      blastRef.current.position.distanceTo(
        position
      );

    if (travelled > 40) {
      onDestroy();
    }

  });

  return (
    <Sphere
      ref={blastRef}
      args={[0.4, 16, 16]}
      position={[
        position.x,
        position.y,
        position.z
      ]}
      castShadow
    >

      <meshStandardMaterial
        color="#00ffff"
        emissive="#00ffff"
        emissiveIntensity={4}
      />

    </Sphere>
  );
}
