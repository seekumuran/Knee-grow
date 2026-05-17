import { Canvas } from "@react-three/fiber";

import { useRef, useState } from "react";

import Arena from "../components/environment/Arena";
import Lighting from "../components/environment/Lighting";

import Fighter from "../components/characters/Fighter";

import ThirdPersonCamera from "../components/camera/ThirdPersonCamera";

export default function FightScene() {

  const playerRef = useRef();

  // Shared camera rotation
  const [cameraRotation, setCameraRotation] = useState(0);

  return (

    <Canvas shadows>

      <Lighting />

      <Arena />

      <Fighter
        ref={playerRef}
        cameraRotation={cameraRotation}
      />

      <ThirdPersonCamera
        target={playerRef}
        setCameraRotation={setCameraRotation}
      />

    </Canvas>
  );
}
