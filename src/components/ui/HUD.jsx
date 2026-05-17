export default function HUD({
  health,
  wave,
  combo,
  blastCooldown,
  dashCooldown
}) {

  return (
    <div
      style={{
        position: "absolute",
        top: 0,
        left: 0,
        width: "100%",
        height: "100%",
        pointerEvents: "none",
        fontFamily: "Arial",
        color: "white"
      }}
    >

      <div
        style={{
          position: "absolute",
          top: 20,
          left: 20,
          width: 300
        }}
      >

        <div
          style={{
            marginBottom: 8,
            fontSize: 20
          }}
        >

          HEALTH

        </div>

        <div
          style={{
            width: "100%",
            height: 25,
            background: "#222",
            border: "2px solid #00ffff"
          }}
        >

          <div
            style={{
              width: `${health}%`,
              height: "100%",
              background: "#00ffff",
              transition: "0.2s"
            }}
          />

        </div>

      </div>

      <div
        style={{
          position: "absolute",
          top: 20,
          right: 20,
          textAlign: "right"
        }}
      >

        <div
          style={{
            fontSize: 32,
            color: "#00ffff"
          }}
        >

          WAVE {wave}

        </div>

        <div
          style={{
            marginTop: 10,
            fontSize: 20
          }}
        >

          COMBO x{combo}

        </div>

      </div>

      <div
        style={{
          position: "absolute",
          bottom: 20,
          left: 20,
          display: "flex",
          gap: 20
        }}
      >

        <div
          style={{
            width: 90,
            height: 90,
            borderRadius: "50%",
            border: "3px solid #00ffff",
            display: "flex",
            alignItems: "center",
            justifyContent: "center",
            background:
              blastCooldown > 0
                ? "#222"
                : "#00ffff22",
            fontSize: 18
          }}
        >

          BLAST

        </div>

        <div
          style={{
            width: 90,
            height: 90,
            borderRadius: "50%",
            border: "3px solid #ff00ff",
            display: "flex",
            alignItems: "center",
            justifyContent: "center",
            background:
              dashCooldown > 0
                ? "#222"
                : "#ff00ff22",
            fontSize: 18
          }}
        >

          DASH

        </div>

      </div>

    </div>
  );
}
