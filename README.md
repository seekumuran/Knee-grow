# ⚡ RA.ONE Mobile — Cyber Combat Arena

A fast-paced futuristic arena combat game inspired by the 2011 Ra.One universe, built using React, Three.js, React Three Fiber, and mobile-ready web technologies.

This project focuses on:
- cinematic combat
- sci-fi visuals
- boss fights
- Android deployment
- stylized VFX
- mobile controls
- real-time action gameplay

---

# 🎮 Features

## Combat System
- Melee combo attacks
- Energy blast projectiles
- Dash mechanics
- Ground slam ability
- Hit-stop combat feedback
- Cinematic finishers
- Enemy knockback

---

## Enemy AI
- Aggressive AI behavior
- Enemy tracking
- Wave progression
- Fast enemies
- Tank enemies
- Boss enemies
- Boss rage mode
- Enemy projectiles

---

## Visual Effects
- Neon cyberpunk arena
- Bloom post-processing
- Dash trails
- Shockwaves
- Explosion effects
- Screen shake
- Cinematic flashes
- Energy aura system

---

## UI / HUD
- Health bar
- Wave counter
- Combo counter
- Ability indicators
- Main menu
- Pause menu
- Game over screen
- Mobile touch controls

---

## Mobile Support
- Android-ready architecture
- Capacitor integration
- Touchscreen controls
- Optimized rendering
- Mobile quality scaling
- Fullscreen support

---

# 🛠 Tech Stack

## Frontend
- React
- Vite

## 3D / Rendering
- Three.js
- React Three Fiber
- Drei

## Effects
- Postprocessing
- Bloom
- Vignette

## Mobile
- Capacitor
- Android Studio

---

# 📁 Project Structure

```txt
src
│
├── audio
│   └── sounds.js
│
├── components
│   │
│   ├── camera
│   │   └── ThirdPersonCamera.jsx
│   │
│   ├── characters
│   │   ├── Enemy.jsx
│   │   └── Fighter.jsx
│   │
│   ├── combat
│   │   ├── EnemyProjectile.jsx
│   │   └── EnergyBlast.jsx
│   │
│   ├── effects
│   │   ├── DashTrail.jsx
│   │   ├── ExplosionEffect.jsx
│   │   ├── FinisherFlash.jsx
│   │   ├── HitStop.jsx
│   │   ├── ScreenShake.jsx
│   │   └── Shockwave.jsx
│   │
│   ├── environment
│   │   ├── Arena.jsx
│   │   ├── Lighting.jsx
│   │   └── NeonArena.jsx
│   │
│   └── ui
│       ├── GameOver.jsx
│       ├── HUD.jsx
│       ├── MainMenu.jsx
│       ├── MobileControls.jsx
│       └── PauseMenu.jsx
│
├── game
│   └── controls.js
│
├── scenes
│   └── FightScene.jsx
│
├── utils
│   └── device.js
│
├── App.jsx
├── main.jsx
│
└── README.md
```

---

# 📦 Asset Structure

```txt
public
│
├── audio
│   ├── attack.wav
│   ├── blast.wav
│   ├── dash.wav
│   ├── hit.wav
│   └── bgm.mp3
│
├── icons
│   └── app-icon.png
│
└── models
    │
    ├── g-one
    │   └── GOne.glb
    │
    └── ra-one
        └── RAOne.glb
```

---

# 🚀 Installation

## Clone Repository

```bash
git clone https://github.com/your-username/raone-mobile.git
```

---

## Enter Project

```bash
cd raone-mobile
```

---

## Install Dependencies

```bash
npm install
```

---

## Start Development Server

```bash
npm run dev
```

---

# 🎮 Controls

## Desktop Controls

| Action | Key |
|---|---|
| Move | WASD |
| Jump | Space |
| Dash | Q |
| Melee Attack | F |
| Energy Blast | G |
| Ground Slam | X |
| Pause | ESC |

---

## Mobile Controls

- Virtual joystick
- Attack button
- Blast button
- Dash button
- Jump button

---

# 📱 Android Build Setup

## Install Capacitor

```bash
npm install @capacitor/core @capacitor/cli
npm install @capacitor/android
```

---

## Initialize Capacitor

```bash
npx cap init
```

Example:

```txt
App Name: RA.ONE Mobile
App ID: com.kumaran.raone
```

---

## Add Android Platform

```bash
npx cap add android
```

---

## Build Web Project

```bash
npm run build
```

---

## Sync Android Project

```bash
npx cap sync
```

---

## Open Android Studio

```bash
npx cap open android
```

---

# ⚡ Performance Optimizations

- Reduced bloom intensity on mobile
- Shadow optimization
- Geometry simplification
- Projectile limits
- Adaptive fog rendering
- Device quality detection
- High-performance GPU rendering

---

# 🧠 Architecture Notes

This project uses:
- modular combat systems
- separated VFX architecture
- reusable gameplay systems
- scalable enemy framework
- mobile-first optimization design

The project was intentionally structured like a real indie game prototype rather than a simple demo.

---

# 🔮 Future Improvements

- Real character shaders
- Advanced combo system
- Multiplayer support
- Story mode
- Voice lines
- Save system
- Skill tree
- Better enemy animations
- Destructible environments
- Advanced boss phases

---

# 📸 Screenshots

_Add gameplay screenshots here_

---

# 📜 License

This project is inspired by the Ra.One universe for educational and portfolio purposes.

All original movie/IP rights belong to their respective owners.

---

# 👨‍💻 Developer

Built by Kumaran Chandrashekar

Focused on:
- game development
- UI/UX
- mobile-first interactive systems
- creative engineering
- real-time graphics

---
