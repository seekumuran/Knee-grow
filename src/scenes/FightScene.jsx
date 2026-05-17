import { Canvas } from "@react-three/fiber";
import {
  OrbitControls
} from "@react-three/drei";
import Arena from "../components/environment/Arena";
import Lighting from "../components/environment/Lighting";
import Fighter from "../components/characters/Fighter";
export default function FightScene() {
  return (
    <Canvas
      camera={{
        position: [0, 5, 10],
        fov: 60
      }}
      shadows
    >
      <Lighting />
      <Arena />
      <Fighter />
      <OrbitControls />
    </Canvas>
  );
}
