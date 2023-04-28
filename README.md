# Ball Brawl

Welcome to Ball Brawl, an exciting 3D game where you must survive for as long as possible on a small platform as a ball. Your goal is to defeat the enemy balls that spawn in waves, each with different abilities, sizes, colors, mass, and speed. Each wave spawns a different number of enemies with every third wave being a boss round where a big ball appears, which can spawn small minion balls. As you progress through the game, you'll encounter a random power-up with each wave, which you can activate by pressing the space bar.

## Gameplay

![Gameplay](./Assets/Images/Gameplay.png)

To control your ball, use the W and S keys to move forward or backward with respect to the camera, and the A and D keys to rotate the camera. The enemies will spawn randomly in waves, starting with one enemy ball in the first wave and increasing by one with each subsequent wave. The third wave features the boss enemy, a big ball that can spawn smaller minion balls.

Here are descriptions of the different enemy balls:

-   Normal Enemy: These enemies are about the same size as the player ball and have a red and black checkered pattern. They have a mass of 1 and move at a speed similar to the player ball.

-   Weak Enemy: These enemies are slightly smaller than the player ball and are a reddish-pink color. They have a smaller mass of 0.5 and move at the same speed as the player ball.

-   Strong Enemy: These enemies are larger than the player ball and are yellow in color. They have a mass of 2 and move faster than the player ball.

-   Boss Enemy: This enemy is significantly larger than the player ball and is pink in color. It has a massive size and mass of 5, but moves slower than the player ball. During the boss round, the boss will also spawn two types of minions:

    -   Mini Enemy: These minions are small and glossy purple in color. They have a size and mass of 0.8 and move faster than the player ball.

    -   Mini Fast Enemy: These minions are the same size and color as the Mini Enemy, but they move even faster at a speed of 5.

Here are descriptions of the different power-ups:

-   Star: Gives the player invincibility. Any enemy that touches the player is launched back. Lasts 7 seconds.
-   Bolt: Gives the player the ability to fire homing missiles that track any and all enemies in the scene. Lasts 7 seconds.
-   Fire: Gives the player the ability to super smash by launching into the air and smashing down, launching all enemies in the smash radius to be knocked back. Lasts 7 seconds.

## Features

The game utilizes many features of Unity, including but not limited to:

-   Particle System
-   Physics
-   Enums
-   Animation Controller
-   Scripting with C#

## Installation

To install the game, clone the repository and open it in Unity to build and run the game from the source code.

## License

This project is licensed under the MIT License. Feel free to modify and use any of the code for your own purposes, but please credit the original author if you share or distribute any modified versions of this project. See the [LICENSE](./LICENSEtxt) file for details.

## Contact

If you have any questions or suggestions, feel free to contact me at [LinkedIn](https://www.linkedin.com/in/ali-qadir-1509b1226/) or [Instagram](https://www.instagram.com/oily.oli/).
