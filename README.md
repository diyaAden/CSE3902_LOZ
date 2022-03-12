# LegendOfZelda

CSE 3902 Group Project
Members: Ben Roth, Sean Burns, Alex Quedens, Jiayi Pu, Diya Adengada


Player Controls
- Arrow and "wasd" keys move Link and change his facing direction.
- The 'z' and 'n' key cause Link to attack using his sword.
- Number keys (1, 2, 3, etc.) are used to let Link use a different item
- Use 'e' to cause Link to become damaged.

Item Controls
- Items move and animate, but don't interact with any other objects

Enemy/NPC (other character) Controls
- Enemies collide with blocks and players
- Colliding with an enemy causes the player to become damaged (turn red)

Other Controls
- Use 'q' to quit and 'r' to reset the program back to its initial state.
- Use left mouse click to cycle between rooms


Updates Log:
Sprint 2 Completion 2/21/22

Potential Bugs:
- Switching Link to "damage" state might take a couple of presses to go into effect due to how fast the damage state is toggled
- Current NPC movement is very fast and largely based on randomness, a more controlled system will be utilized in the future
(Sprint3)
- Now the link cannot be damaged by the balls from dragon.
- Enemy damage now use "output" to show it is damaged, will add sprites for damaged enemy in the future.
