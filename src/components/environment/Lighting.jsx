export default function Lighting() {

  return (
    <>

      {/* Ambient */}
      <ambientLight intensity={0.2} />

      {/* Moon/Sun */}
      <directionalLight
        position={[10, 20, 10]}
        intensity={2}
        castShadow
        shadow-mapSize-width={2048}
        shadow-mapSize-height={2048}
      />

      {/* Blue neon */}
      <pointLight
        position={[0, 5, 0]}
        color="#00ffff"
        intensity={15}
      />

      {/* Purple glow */}
      <pointLight
        position={[10, 3, 10]}
        color="#aa00ff"
        intensity={10}
      />

      {/* Red edge light */}
      <pointLight
        position={[-10, 3, -10]}
        color="#ff0033"
        intensity={8}
      />

    </>
  );
}
