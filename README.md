# Escape The Maze

Escape the maze is a 3D Unity game where the player must make their way through a procedurally generated maze to the finish line.

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

1) Download the [Build File](https://drive.google.com/file/d/1Cj9XqGRRVThX00QirjG52muzaP7VoCjF/view?usp=sharing) from my google Drive.
3) Run 'Build.exe' to play the game.
4) Enjoy!

## Built With

[Unity 2019-3](https://unity.com/releases/2019-3)

[Unity Hub](https://unity3d.com/get-unity/download)

## Versioning

Version 1.0

## Authors

* **Blaine Burke** - [GitHub](https://github.com/BurkeBlaine1999)

## License

This project is licensed under the MIT License - see the [LICENSE](https://github.com/BurkeBlaine1999/Final-Year-Project/blob/main/LICENSE) file for details

## Acknowledgments

* [Geeks for geeks](https://www.geeksforgeeks.org/) - Helped with debugging 
* [Stack Overflow](https://stackoverflow.com/) - Helped with debugging 
* [Sandeep Nambiar](https://www.youtube.com/channel/UCmfFa5FtYTbE_sFHpB1gxKg) - Helped with the recursive backtracker algorithm.
* [SoundImage.org](http://soundimage.org/) - Provided me with some of my sound effects and music! 
* [Zapsplat](https://www.zapsplat.com/) - Provided me with some of my sound effects and music! 

