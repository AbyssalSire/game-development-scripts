# 2D Platformer

These are the scripts used on a 2D platformer created during the Game Development course taken at Universidade Tecnológica Federal do Paraná (UTFPR)(Technological Federal University of Parana) for the major of Software Engineering.

The project uses Unity's older Input System.

## Project requirements

Make a small platform game level that has at least the following requirements:

* A scene at least 6 times the width of the screen.

* A playable character (PC) with motion animation.

* A non-playable character (NPC) that always moves to the same side. If this character hits an obstacle, he must reverse movement. If the NPC collides head-on with the PC, the PC must be destroyed.

* If the PC jumps on the NPC's head, the NPC must be destroyed.

* Textures and tilemaps cannot be those used in the classroom.

* One floor (platform). This floor must have two barriers (obstacles), one at each end, so that it is not possible for the PC and NPC to fall.

* It needs to have a mobile platform.

* The game must have a start screen with start and exit buttons.

## Additional features

Although not requested some extra features were added:

* Pause menu (uses ESC to return to game and can quit the game);

* Menu and game soundtracks (free, obtained via itch.io);

## Know issues
* Floaty jumps;

* Enemy sometimes gets stuck on corners due to not registering the colision with the wall;

* No win condition;