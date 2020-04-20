Source Code goes Here

Make a branch for each milestone.
Commit work for each milestone to the branch.
Merge the brance back to the master for each Milestone
Produce a Build of each Milestone and add to build folder 



Vertical Slice Developer Log:
    - There is a base for a win state in the game (if you complete all the laps) but right now it does not do anything besides getting the data.
    - The only pattern I use is the command pattern. The command pattern takes in the the transform of the car. I did change it so that old commands are being removed after a certain amount of commands are being created (See CommandManager.cs). I do want to change it so that it is not creating a new command every frame.
    - The game is structured with an InputManager that gets the keyboard (controller soon) input from the user. That information is passed into the CarController class. The Car Controller class handles the physics with the wheel colliders and other variables related to the car. The RewindCommand class holds all the data needed for each command. The commands are managed in the CommandManager class, this is also where the limit of commands are set.
    - Some things that do not work is the car's flip over easily, I know how to go about fixing this but have not put the time into this yet. Also the meter for how long the player can rewind does increase base off of the rewind pickups, but does not acurately display how far the player can rewind. The finish line does increase the amount of laps whenever the player goes across the it, but it does not detect if the player takes a shortcut, so I plan on adding some sort of invisible waypoints to make sure the player is on the path.

Vertical Slice Decision Log:
    - The main limitation to my game is that right now it only supports two players and it would take some refactoring for each new player. Another limitation is the memory is taken up by the list of RewindCommands. But to combat this limitation, I have a max to how many commands are in the list and I plan to change it so that a new command isnt being created every new frame.
    -  With my main game mechanic revolving around the command pattern, the command pattern has made a huge impact on how I structure my code. For example, for the command pattern to work, I have to have a IEntity interface, a CommandManager, a base command class, and a command class for each command.
    - Some problems that I hope to fix: script for camera wobble, make it so that the player travels slower if they leave the track, fix it so that the car does not flip over as easily, create barriers so that the player cannot leave the level, add a GameMode class to handle win and lose condition, and move more code into the UI class for more seperation of conern.