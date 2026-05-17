import { useFrame, useThree } from "@react-three/fiber";

import { useEffect, useRef } from "react";

export default function ScreenShake({
  shake
}) {

  const { camera } = useThree();

  const originalPosition = useRef();

  useEffect(() => {

    originalPosition.current =
      camera.position.clone();

  }, [camera]);

  useFrame(() => {

    if (!shake) return;

    camera.position.x =
      originalPosition.current.x
      + (Math.random() - 0.5) * 0.3;

    camera.position.y =
      originalPosition.current.y
      + (Math.random() - 0.5) * 0.3;

  });

  return null;
}
