import { useFrame, useThree } from "@react-three/fiber";

import { useEffect, useState } from "react";

import { Vector3 } from "three";

export default function ThirdPersonCamera({ target }) {

  const { camera } = useThree();

  // Rotation values
  const [rotation, setRotation] = useState({
    x: 0,
    y: 0
  });

  useEffect(() => {

    const handleMouseMove = (e) => {

      // Only rotate while holding left click
      if (e.buttons !== 1) return;

      setRotation((prev) => ({
        x: prev.x - e.movementY * 0.003,
        y: prev.y - e.movementX * 0.003
      }));
    };

    window.addEventListener("mousemove", handleMouseMove);

    return () => {
      window.removeEventListener("mousemove", handleMouseMove);
    };

  }, []);

  useFrame(() => {

    if (!target.current) return;

    const playerPosition = target.current.position;

    // Camera distance
    const distance = 10;

    // Camera height
    const height = 5;

    // Orbit calculations
    const offsetX =
      Math.sin(rotation.y) * distance;

    const offsetZ =
      Math.cos(rotation.y) * distance;

    const desiredPosition = new Vector3(
      playerPosition.x + offsetX,
      playerPosition.y + height,
      playerPosition.z + offsetZ
    );

    // Smooth camera movement
    camera.position.lerp(desiredPosition, 0.1);

    // Look at player
    camera.lookAt(playerPosition);

  });

  return null;
}
