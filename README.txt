Erik Anderson
100753323

---Block Dodger---
A simple game of dodging the falling blocks. If you get hit by one, its game over! 2 new types of blocks are added at 20 points and 30 points!

<<Observer>>
-- What element of your game adopts the chosen pattern?
In the game, I applied the abstract class "Subject" to the PlayerMovement.cs script and the abstract class "Observer" to the AudioManager.cs, GameManager.cs, and Factory.cs scripts. The PlayerMovement script is the one that handles the different states for the player. Said states are if they're jumping and if the player has died. The 3 scripts that are observers just need to know if those states change. If the player has jumped, then it sets a grounded variable to false and so the AudioManager plays the jumping sfx. If the player has died, then the AudioManager is notified and will play the death sfx. Then the Factory is notified and destroys itself to stop spawning objects. And finally the GameManager is notified and enables the game over menu.

-- Why is this pattern a good choice for spawning these objects?
Its a good choice as by doing it this way, the observer scripts can easily have their own Notify function changed in their own script without having to alter anything else (besides maybe having to add new variables in PlayerMovement to describe any new states). It also makes it much easier to add in more observers as all you need to do is add it to the list of observers in the PlayerMovement script.

Jump Sound: https://opengameart.org/content/platformer-jumping-sounds

Death Sound: https://opengameart.org/content/bombexplosion8bit

Flowchart Diagram:
