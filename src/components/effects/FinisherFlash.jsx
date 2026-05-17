import { useEffect, useState } from "react";

export default function FinisherFlash() {

  const [visible, setVisible] =
    useState(true);

  useEffect(() => {

    const timer = setTimeout(() => {
      setVisible(false);
    }, 300);

    return () => clearTimeout(timer);

  }, []);

  if (!visible) return null;

  return (
    <div
      style={{
        position: "absolute",
        inset: 0,
        background: "#ffffff",
        opacity: 0.8,
        pointerEvents: "none"
      }}
    />
  );
}
