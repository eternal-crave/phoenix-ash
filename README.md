# Phoenix Ash

A Unity-based top-down shooter game featuring weapon progression, enemy waves, and score-based gameplay.

## Overview

Phoenix Ash is a 2D top-down shooter where players fight waves of enemies using various weapons. The game features a progression system where new weapons unlock as players achieve higher scores, creating an engaging gameplay loop.

## Features

### Core Gameplay
- **Player Combat**: Control a player character that can shoot at enemies
- **Enemy Waves**: Enemies spawn periodically from screen edges
- **Weapon System**: Multiple weapon types with different firing patterns:
  - **Single Weapon**: Basic single-shot weapon
  - **Queue Weapon**: Rapid-fire weapon
  - **Shotgun Weapon**: Spread-shot weapon
- **Weapon Unlocking**: New weapons unlock based on score milestones
- **Score System**: Track current score and high score
- **Death Zones**: Areas that eliminate units on contact

### Technical Systems

#### Core Architecture
- **Dependency Injection**: Uses [Zenject] for dependency injection and IoC container
- **Factory System**: Generic factory pattern for creating game objects
- **Object Pooling**: Efficient object pooling system for bullets and enemies
- **View System**: MVC-like view management system for UI screens
- **Save System**: PlayerPrefs-based save system for persistent data

#### Game Systems
- **Game Flow Management**: Handles game state transitions (Start → Game → Game Over)
- **Weapon Manager**: Manages weapon switching and unlocking
- **Score Counter**: Tracks and manages player scores
- **Gameplay Manager**: Orchestrates enemy spawning and game logic

## Project Structure

```
Assets/
├── Plugins/
│   └── Zenject/              # Dependency injection framework
├── Resources/                # Game resources
│   ├── Bullets/             # Bullet prefabs
│   ├── Config/              # Game configuration ScriptableObjects
│   ├── GameplayProcessors/  # Gameplay processor assets
│   ├── Prefabs/             # Game prefabs
│   ├── Units/               # Player and Enemy prefabs
│   ├── ViewPrefabs/         # UI view prefabs
│   └── Weapons/             # Weapon ScriptableObject assets
├── Scenes/                  # Unity scenes
│   ├── Main.unity          # Main game scene
│   └── Test.unity          # Test scene
└── Scripts/                 # Source code
    ├── Core/               # Core systems
    │   ├── Factory/        # Factory pattern implementation
    │   ├── PoolSystem/     # Object pooling system
    │   ├── SaveSystem/     # Save/load system
    │   ├── ScoreSystem/    # Score management
    │   ├── UnitSystem/     # Unit interfaces (damage, etc.)
    │   └── ViewSystem/     # View management system
    ├── Factories/          # Concrete factory implementations
    ├── GameConfiguration/  # Game configuration ScriptableObjects
    ├── GameFlow/           # Game flow and state management
    ├── Installers/         # Zenject installers
    ├── Units/              # Player and Enemy scripts
    ├── Views/              # UI view implementations
    └── Weapons/            # Weapon system implementation
```

## Requirements

- **Unity Version**: 6000.2.6f2 or compatible

## Setup

1. **Clone the repository**
   ```bash
   git clone <repository-url>
   cd phoenix-ash
   ```

2. **Open in Unity**
   - Open Unity Hub
   - Click "Add" and select the project folder
   - Ensure Unity 6000.2.6f2 or compatible version is installed
   - Open the project

3. **Configure the Scene**
   - Open `Assets/Scenes/Main.unity`

4. **Game Configuration**
   - Configure `Assets/Resources/Config/GameConfig.asset`:
     - Set default player weapon
     - Configure enemy spawn interval
     - Set points per enemy kill
     - Configure weapon unlock thresholds

5. Play! :D

## Game Configuration

The game uses a ScriptableObject-based configuration system (`GameConfig`). Key settings include:

- **Player Settings**:
  - Default weapon type
  
- **Enemy Settings**:
  - Points awarded per enemy kill
  - Enemy creation interval (seconds)
  - Creation offset from screen edges
  
- **Weapon Progression**:
  - Score thresholds for weapon unlocks

## Architecture Highlights

### Dependency Injection
The project uses Zenject for dependency injection, providing:
- Loose coupling between systems
- Easy testing and mocking
- Centralized configuration in `BootstrapInstaller`

### Object Pooling
Efficient object pooling for frequently created/destroyed objects:
- Bullets are pooled to reduce garbage collection
- Enemies are pooled for better performance

### Factory Pattern
Generic factory system for creating game objects:
- `BulletFactory`: Creates bullet instances
- `EnemyFactory`: Creates enemy instances
- Extensible for new object types

### View System
MVC-like view management:
- `ViewManager`: Manages view lifecycle
- Views: `StartView`, `GameView`, `GameOverView`
- Clean separation between UI and game logic

## Key Scripts

### Core Systems
- `GameFlow`: Manages game state and view transitions
- `GameplayManager`: Handles enemy spawning and game logic
- `WeaponManager`: Manages weapon switching and unlocking
- `ScoreCounter`: Tracks player scores
- `ViewManager`: Manages UI view lifecycle

### Game Objects
- `Player`: Player character controller
- `Enemy`: Enemy AI and behavior
- `Bullet`: Projectile behavior
- `DeathZone`: Area that eliminates units

### Weapons
- `Weapon`: Base weapon class (ScriptableObject)
- `SingleWeapon`: Single-shot weapon
- `QueueWeapon`: Rapid-fire weapon
- `ShotGunWeapon`: Spread-shot weapon

<!--
## Development Notes

This section is reserved for ongoing developer notes, tips, and reminders. Use this area to document:
- Current work-in-progress items
- Known issues and quick fixes
- Module integration notes
- Design decisions or trade-offs to revisit

Comment out or remove this section before public release.
-->

### Best Practices
- Separation of concerns: Core systems are independent and reusable
- Dependency injection: All dependencies are injected via Zenject
- ScriptableObject configuration: Game settings are data-driven
- Object pooling: Used for frequently created/destroyed objects

### Extensibility
The architecture supports easy extension:
- Add new weapons by creating ScriptableObject assets
- Add new views by extending the `View` base class
- Add new factories by implementing `IFactoryMarker`
- Add new pools by extending `BasePool<T>`

## License

This project uses Zenject, which is licensed separately. Please refer to the Zenject license in `Assets/Plugins/Zenject/LICENSE.txt`.

## Contributing

When contributing to this project:
1. Follow the existing code structure and patterns
2. Use dependency injection for all dependencies
3. Wrap reusable code into methods
4. Maintain separation of concerns
5. Add appropriate comments for complex logic

## Future Improvements

Potential areas for enhancement:
- Audio system integration
- Particle effects for weapon impacts
- More weapon types and variations
- Enemy AI improvements
- Power-up system
- Level progression system
- Achievement system

