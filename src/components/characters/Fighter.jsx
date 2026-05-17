import {
  Text,
  Sphere,
  useAnimations,
  useGLTF
} from "@react-three/drei";

import { useFrame } from "@react-three/fiber";

import {
  forwardRef,
  useEffect,
  useImperativeHandle,
  useRef,
  useState
} from "react";

import keys from "../../game/controls";

import {
  attackSound,
  blastSound,
  dashSound,
  hitSound
} from "../../audio/sounds";

const Fighter = forwardRef(function Fighter(
  {
    cameraRotation,
    enemyRef,
    lockOn,
    setBlasts,
    setShake,
    setHitStop,
    setDashTrails,
    setShockwaves
  },
  ref
) {

  const group = useRef();

  const { scene, animations } =
    useGLTF("/models/g-one/GOne.glb");

  const { actions } =
    useAnimations(animations, group);

  const velocity = useRef({
    x: 0,
    z: 0
  });

  const verticalVelocity = useRef(0);

  const isGrounded = useRef(true);

  const dashCooldown = useRef(0);

  const attackCooldown = useRef(0);

  const comboTimer = useRef(0);

  const comboStep = useRef(0);

  const blastCooldown = useRef(0);

  const slamCooldown = useRef(0);

  const [health, setHealth] =
    useState(100);

  const [isHit, setIsHit] =
    useState(false);

  const [isDead, setIsDead] =
    useState(false);

  const [currentAnimation, setCurrentAnimation] =
    useState("Idle");

  useEffect(() => {

    if (!actions) return;

    Object.values(actions).forEach((action) =>
      action.stop()
    );

    actions[currentAnimation]
      ?.reset()
      .fadeIn(0.2)
      .play();

    return () => {

      actions[currentAnimation]
        ?.fadeOut(0.2);

    };

  }, [actions, currentAnimation]);

  useImperativeHandle(ref, () => ({
    position: group.current?.position,

    health,

    combo: comboStep.current,

    blastCooldown:
      blastCooldown.current,

    dashCooldown:
      dashCooldown.current,

    takeDamage(amount, direction) {

      if (isDead) return;

      setHealth((prev) => {

        const newHealth =
          Math.max(prev - amount, 0);

        if (newHealth <= 0) {

          setCurrentAnimation("Death");

          setTimeout(() => {
            setIsDead(true);
          }, 1500);

        }

        return newHealth;

      });

      setIsHit(true);

      setCurrentAnimation("Hit");

      velocity.current.x +=
        direction.x * 0.3;

      velocity.current.z +=
        direction.z * 0.3;

      setTimeout(() => {
        setIsHit(false);
      }, 100);

    }
  }));

  useFrame(() => {

    if (
      !group.current ||
      isDead
    ) return;

    let moveSpeed = 0.08;

    let moving = false;

    if (keys["shift"]) {
      moveSpeed = 0.15;
    }

    let inputX = 0;
    let inputZ = 0;

    if (keys["w"]) inputZ -= 1;
    if (keys["s"]) inputZ += 1;
    if (keys["a"]) inputX -= 1;
    if (keys["d"]) inputX += 1;

    const length = Math.hypot(
      inputX,
      inputZ
    );

    let rotatedX = 0;
    let rotatedZ = 0;

    if (length > 0) {

      moving = true;

      inputX /= length;
      inputZ /= length;

      rotatedX =
        inputX * Math.cos(cameraRotation)
        - inputZ * Math.sin(cameraRotation);

      rotatedZ =
        inputX * Math.sin(cameraRotation)
        + inputZ * Math.cos(cameraRotation);

      velocity.current.x +=
        (
          rotatedX * moveSpeed
          - velocity.current.x
        ) * 0.1;

      velocity.current.z +=
        (
          rotatedZ * moveSpeed
          - velocity.current.z
        ) * 0.1;

      if (
        lockOn &&
        enemyRef?.current?.mesh
      ) {

        const enemyPosition =
          enemyRef.current.mesh.position;

        const playerPosition =
          group.current.position;

        const dx =
          enemyPosition.x - playerPosition.x;

        const dz =
          enemyPosition.z - playerPosition.z;

        const targetAngle =
          Math.atan2(dx, dz);

        group.current.rotation.y +=
          (
            targetAngle
            - group.current.rotation.y
          ) * 0.1;

      } else {

        const angle =
          Math.atan2(
            rotatedX,
            rotatedZ
          );

        group.current.rotation.y +=
          (
            angle
            - group.current.rotation.y
          ) * 0.1;

      }

    } else {

      velocity.current.x *= 0.9;
      velocity.current.z *= 0.9;

    }

    if (moving) {

      if (keys["shift"]) {

        setCurrentAnimation("Running");

      } else {

        setCurrentAnimation("Walking");

      }

    }

    if (
      keys["q"] &&
      dashCooldown.current <= 0 &&
      length > 0
    ) {

      velocity.current.x +=
        rotatedX * 1.5;

      velocity.current.z +=
        rotatedZ * 1.5;

      dashCooldown.current = 60;

      dashSound.currentTime = 0;

      dashSound.play();

      setDashTrails((prev) => [
        ...prev,

        {
          id: Date.now(),

          position: {
            x: group.current.position.x,
            y: group.current.position.y + 1,
            z: group.current.position.z
          }
        }
      ]);

    }

    if (dashCooldown.current > 0) {
      dashCooldown.current--;
    }

    if (
      keys["f"] &&
      attackCooldown.current <= 0
    ) {

      comboStep.current++;

      if (comboStep.current > 3) {
        comboStep.current = 1;
      }

      comboTimer.current = 60;

      if (comboStep.current === 1) {
        setCurrentAnimation("Punch");
      }

      if (comboStep.current === 2) {
        setCurrentAnimation("Kick");
      }

      if (comboStep.current === 3) {
        setCurrentAnimation("Punch");
      }

      attackCooldown.current = 20;

      attackSound.currentTime = 0;

      attackSound.play();

      if (
        enemyRef?.current?.mesh
      ) {

        const enemyPosition =
          enemyRef.current.mesh.position;

        const playerPosition =
          group.current.position;

        const distance =
          playerPosition.distanceTo(
            enemyPosition
          );

        if (distance < 3) {

          const direction = {
            x:
              enemyPosition.x
              - playerPosition.x,

            z:
              enemyPosition.z
              - playerPosition.z
          };

          const dirLength =
            Math.hypot(
              direction.x,
              direction.z
            );

          direction.x /= dirLength;
          direction.z /= dirLength;

          let damage = 10;

          if (comboStep.current === 2) {
            damage = 15;
          }

          if (comboStep.current === 3) {
            damage = 25;
          }

          enemyRef.current.takeDamage(
            damage,
            direction
          );

          hitSound.currentTime = 0;

          hitSound.play();

          setShake(true);

          setHitStop(true);

          setTimeout(() => {

            setShake(false);

            setHitStop(false);

          }, 120);

        }

      }

    }

    if (attackCooldown.current > 0) {
      attackCooldown.current--;
    }

    if (comboTimer.current > 0) {

      comboTimer.current--;

    } else {

      comboStep.current = 0;

    }

    if (
      keys["g"] &&
      blastCooldown.current <= 0
    ) {

      blastCooldown.current = 40;

      blastSound.currentTime = 0;

      blastSound.play();

      setShake(true);

      setHitStop(true);

      setTimeout(() => {

        setShake(false);

        setHitStop(false);

      }, 120);

      let direction = {
        x: Math.sin(cameraRotation),
        z: Math.cos(cameraRotation)
      };

      if (
        lockOn &&
        enemyRef?.current?.mesh
      ) {

        const enemyPosition =
          enemyRef.current.mesh.position;

        const playerPosition =
          group.current.position;

        const dx =
          enemyPosition.x - playerPosition.x;

        const dz =
          enemyPosition.z - playerPosition.z;

        const distance =
          Math.hypot(dx, dz);

        direction = {
          x: dx / distance,
          z: dz / distance
        };

      }

      setBlasts((prev) => [

        ...prev.slice(-5),

        {
          id: Date.now(),

          position: {
            x: group.current.position.x,
            y: 2,
            z: group.current.position.z
          },

          direction
        }
      ]);

    }

    if (blastCooldown.current > 0) {
      blastCooldown.current--;
    }

    if (
      keys["x"] &&
      slamCooldown.current <= 0
    ) {

      slamCooldown.current = 180;

      setShake(true);

      setHitStop(true);

      setTimeout(() => {

        setShake(false);

        setHitStop(false);

      }, 200);

      setShockwaves((prev) => [
        ...prev,

        {
          id: Date.now(),

          position: {
            x: group.current.position.x,
            y: 0,
            z: group.current.position.z
          }
        }
      ]);

      if (
        enemyRef?.current?.mesh
      ) {

        const enemyPosition =
          enemyRef.current.mesh.position;

        const playerPosition =
          group.current.position;

        const distance =
          playerPosition.distanceTo(
            enemyPosition
          );

        if (distance < 8) {

          const direction = {
            x:
              enemyPosition.x
              - playerPosition.x,

            z:
              enemyPosition.z
              - playerPosition.z
          };

          const dirLength =
            Math.hypot(
              direction.x,
              direction.z
            );

          direction.x /= dirLength;

          direction.z /= dirLength;

          enemyRef.current.takeDamage(
            40,
            direction
          );

        }

      }

    }

    if (slamCooldown.current > 0) {
      slamCooldown.current--;
    }

    group.current.position.x +=
      velocity.current.x;

    group.current.position.z +=
      velocity.current.z;

    if (
      keys[" "] &&
      isGrounded.current
    ) {

      verticalVelocity.current = 0.25;

      isGrounded.current = false;

      setCurrentAnimation("Jump");

    }

    verticalVelocity.current -= 0.01;

    group.current.position.y +=
      verticalVelocity.current;

    if (
      group.current.position.y <= 0
    ) {

      group.current.position.y = 0;

      verticalVelocity.current = 0;

      isGrounded.current = true;

    }

    if (
      attackCooldown.current <= 0 &&
      isGrounded.current &&
      !moving
    ) {

      setCurrentAnimation("Idle");

    }

  });

  if (isDead) {
    return null;
  }

  return (
    <>
      <primitive
        ref={group}
        object={scene}
        scale={1.5}
        castShadow
      />

      <Sphere
        args={[1.3, 16, 16]}
        position={[
          group.current?.position.x || 0,
          (group.current?.position.y || 0) + 1.5,
          group.current?.position.z || 0
        ]}
      >

        <meshStandardMaterial
          color="#00ffff"
          emissive="#00ffff"
          emissiveIntensity={2}
          transparent
          opacity={0.08}
        />

      </Sphere>

      <Text
        position={[
          group.current?.position.x || 0,
          4,
          group.current?.position.z || 0
        ]}
        fontSize={0.5}
        color="white"
      >

        HP: {health}

      </Text>

      <Text
        position={[
          group.current?.position.x || 0,
          5,
          group.current?.position.z || 0
        ]}
        fontSize={0.4}
        color="#00ffff"
      >

        Combo: {comboStep.current}

      </Text>
    </>
  );
});

export default Fighter;
