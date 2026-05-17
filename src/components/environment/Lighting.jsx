export default function Lighting() {
  return (
    <>
      <ambientLight intensity={0.4} />
      <directionalLight
        position={[5, 10, 5]}
        intensity={2}
        castShadow
      />
      <pointLight
        position={[0, 5, 0]}
        color="#00ffff"
        intensity={10}
      />
    </>
  );
}
