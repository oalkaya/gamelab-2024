
# 🕹️ Bazaar Bounty – GameLab Project

This repository contains a 2D top-down roguelike dungeon crawler developed using **MonoGame** as part of the GameLab course at ETH Zurich. 

---

## 🎮 Core Features

- **2D Sprite Animation System**  
  Smooth animations for both player and enemy entities, supporting multiple states (idle, moving, attacking, dying).

- **Pathfinding for Enemy AI**  
  Enemies dynamically navigate dungeon rooms using an efficient pathfinding algorithm to chase and surround the player.

- **Tiled Map Editor Integration**  
  Custom-built pipeline to import and parse `.tmx` maps from the [Tiled](https://www.mapeditor.org/) editor, enabling rapid level design iteration.

- **Semi-Randomized Visuals**  
  Tilesets and environmental props are randomized between playthroughs, offering visual variation while preserving core layout logic.

- **Enemy Variety & Scaling Difficulty**  
  Multiple enemy types with unique stats and behaviors. A global difficulty curve progressively increases enemy spawn strength as players advance.

- **Power-Up System**  
  Players earn melee or ranged power-ups after each level, boosting damage, attack speed, or special abilities to match the scaling challenge.

- **Melee & Ranged Combat Mechanics**  
  Implemented collision-based combat with hitbox logic for melee weapons and projectile logic (including travel, collisions, and lifespan) for ranged attacks.

- **Deflection System**  
  Certain attacks or abilities can deflect incoming projectiles, adding depth to positioning and tactical combat.

---

## 🧩 Tools
- **Language:** C#
- **Framework:** MonoGame
- **Level Design:** Tiled Map Editor (`.tmx`)

---

## 👥 Credits
- **Alkaya Ömer** 
- **Willy Shih** 
- **Yingzhe Liu**
- **Minsung Kang**
- **Shenghao Zhang**

---

Thanks for checking out our game! Feel free to clone, build, and explore!

