import { useFrame, useThree } from "@react-three/fiber";

import { useEffect, useState } from "react";

import { Vector3 } from "three";

export default function ThirdPersonCamera({
  target,
  setCameraRotation
}) {

  const { camera } = useThree();

  const [rotation, setRotation] = useState({
    x: 0,
    y: 0
  });

  useEffect(() => {

    const handleMouseMove = (e) => {

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

    // Share camera angle
    setCameraRotation(rotation.y);

    const distance = 10;
    const height = 5;

    const offsetX =
      Math.sin(rotation.y) * distance;

    const offsetZ =
      Math.cos(rotation.y) * distance;

    const desiredPosition = new Vector3(
      playerPosition.x + offsetX,
      playerPosition.y + height,
      playerPosition.z + offsetZ
    );

    camera.position.lerp(desiredPosition, 0.1);

    camera.lookAt(playerPosition);

  });

  return null;
}
