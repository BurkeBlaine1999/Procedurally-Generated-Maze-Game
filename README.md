# Escape The Maze

Escape the maze is a 3D Unity game where the player must make their way through a procedurally generated maze to the finish line. 

There are two game modes, the reglar mode in which the player must make their way to the finish line. Every time they reach the end the mazes width and height grows by 1. The can play as long as they want until they give up. Their highscore is displayed in the main menu area. Every level is different as the mazes are always randomly generated.

The next game mode is practice where the player can specify the height and width of the maze and generate as many mazes as they want.

## How it works
I used the recursive backtracker algorithm. It uses Depth first search to form the maze.
In the diagrams below yellow represents the current node and red represents the neighbouring 
node that has been selected.


It begins by choosing a random, current node and adds its position to the stack. Next, it checks for
any unvisited neighbours to that node and breaks the walls between the current node and one of 
the neighbouring nodes. It then moves the current node to the neighbour’s position, adds it to the 
stack and then repeats this process until a dead end is reached.


We then backtrack through the nodes by removing them from the stack until we meet another node 
that hasn’t been visited and has neighbours that haven’t been visited. We then repeat the process
until there are eventually no elements left in the stack.

![Recursive Backtracker Algorithim](https://github.com/BurkeBlaine1999/procedurally-Generated-Maze/blob/main/Assets/Images/Designs.PNG)

## Playing the game

1) Download the [Package File](https://drive.google.com/file/d/1R97L_9xT5KJi4ILwg1XbSj52KS34SPoY/view?usp=sharing) from my google Drive.
2) Import the asset into the unity editor
3) Enjoy!

## Controls
* Use WSAD or the arrow keys to move.
* Use the scroll wheel to zoom in and out.

## Built With

[Unity 2019-3](https://unity.com/releases/2019-3)

[Unity Hub](https://unity3d.com/get-unity/download)

## prerequisites
* The game require you in install Cinemachine from the unity package manager.
* The game require you add the scenes to the build settings after importing.

## Versioning

Version 1.0

## Authors

* **Blaine Burke** - [GitHub](https://github.com/BurkeBlaine1999)

## License

This project is licensed under the MIT License - see the [LICENSE](https://github.com/BurkeBlaine1999/procedurally-Generated-Maze/blob/main/LICENSE) file for details

## Acknowledgments

* [Geeks for geeks](https://www.geeksforgeeks.org/) - Helped with debugging 
* [Stack Overflow](https://stackoverflow.com/) - Helped with debugging 
* [Sandeep Nambiar](https://www.youtube.com/channel/UCmfFa5FtYTbE_sFHpB1gxKg) - Helped with the recursive backtracker algorithm.
* [SoundImage.org](http://soundimage.org/) - Provided me with some of my sound effects and music! 
* [Zapsplat](https://www.zapsplat.com/) - Provided me with some of my sound effects and music! 

