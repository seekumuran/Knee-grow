import { useGLTF } from "@react-three/drei";
export default function Fighter() {
  const model = useGLTF("/models/g-one/GOne.glb");
  return (
    <primitive
      object={model.scene}
      scale={1.5}
      position={[0, 0, 0]}
    />
  );
}
