using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

//Reference --> https://www.youtube.com/watch?v=ya1HyptE5uc&t=9s

[Flags]
public enum WallState{
    // 0000 -> NO WALLS
    // 1111 -> LEFT,RIGHT,UP,DOWN

    //Using bit representation values
    LEFT = 1, // 0001
    RIGHT = 2, // 0010
    UP = 4, // 0100
    DOWN = 8, // 1000

    VISITED = 128, // 1000 0000
}

public struct Position{
    public int X;
    public int Y;
}

//Contains neightbours position & shared wall
public struct Neighbour{
    public Position Position;
    public WallState SharedWall;
}

public static class MazeGenerator{

    private static WallState GetOppositeWall(WallState wall){
        //Returns the opposite wall of the inputted wall.
        switch (wall){
            case WallState.RIGHT: return WallState.LEFT;
            case WallState.LEFT: return WallState.RIGHT;
            case WallState.UP: return WallState.DOWN;
            case WallState.DOWN: return WallState.UP;
            default: return WallState.LEFT;
        }
    }

    private static WallState[,] ApplyRecursiveBacktracker(WallState[,] maze, int width, int height){
        
        var rng = new System.Random(/*A seed can be passed in here to generate a specific maze*/);
        var positionStack = new Stack<Position>();
        //Random position within the grid
        var position = new Position { X = rng.Next(0, width), Y = rng.Next(0, height) };

        //Set the initial cell as visited
        maze[position.X, position.Y] |= WallState.VISITED;  // 1000 1111
        //Add to the stack
        positionStack.Push(position);

        while (positionStack.Count > 0){
            //Pop the top of the stack
            var current = positionStack.Pop();
            //Check the neighbours of the current position
            var neighbours = GetUnvisitedNeighbours(current, maze, width, height);

            //If there are neightbours that are unvisited around the current node
            if (neighbours.Count > 0){
                //Add current back into the stack
                positionStack.Push(current);

                //Take random index from the neighbour list to decide which to go to
                var randIndex = rng.Next(0, neighbours.Count);
                var randomNeighbour = neighbours[randIndex];

                //Set Neighbours position
                var nPosition = randomNeighbour.Position;
                //Remove current nodes shared wall.
                maze[current.X, current.Y] &= ~randomNeighbour.SharedWall;
                //Remove the neighbours shared wall
                maze[nPosition.X, nPosition.Y] &= ~GetOppositeWall(randomNeighbour.SharedWall);
                maze[nPosition.X, nPosition.Y] |= WallState.VISITED;

                //Add neighbours position to the stack.
                positionStack.Push(nPosition);
            }
        }

        return maze;
    }

    private static List<Neighbour> GetUnvisitedNeighbours(Position p, WallState[,] maze, int width, int height){
        var list = new List<Neighbour>();
               
        if (p.X > 0) // left
        {
            //Check if doesnt have a flag and add to the list
            // We remove one from the X position as it is left
            if (!maze[p.X - 1, p.Y].HasFlag(WallState.VISITED))
            {
                list.Add(new Neighbour
                {
                    Position = new Position
                    {
                        X = p.X - 1,
                        Y = p.Y
                    },
                    SharedWall = WallState.LEFT
                });
            }
        }

        if (p.Y > 0) // DOWN
        {   
            //Check if doesnt have a flag and add to the list
            // We remove one from the Y position as it is left
            if (!maze[p.X, p.Y - 1].HasFlag(WallState.VISITED))
            {
                list.Add(new Neighbour
                {
                    Position = new Position
                    {
                        X = p.X,
                        Y = p.Y - 1
                    },
                    SharedWall = WallState.DOWN
                });
            }
        }

        if (p.Y < height - 1) // UP
        {    
            //Check if doesnt have a flag and add to the list
            // We add one to the Y position as it is up
            if (!maze[p.X, p.Y + 1].HasFlag(WallState.VISITED))
            {
                list.Add(new Neighbour
                {
                    Position = new Position
                    {
                        X = p.X,
                        Y = p.Y + 1
                    },
                    SharedWall = WallState.UP
                });
            }
        }

        if (p.X < width - 1) // RIGHT
        {    
            //Check if doesnt have a flag and add to the list
            // We add one to the X position as it is right
            if (!maze[p.X + 1, p.Y].HasFlag(WallState.VISITED))
            {
                list.Add(new Neighbour
                {
                    Position = new Position
                    {
                        X = p.X + 1,
                        Y = p.Y
                    },
                    SharedWall = WallState.RIGHT
                });
            }
        }

        return list;
    }

    public static WallState[,] Generate(int width, int height)
    {
        //Create new maze
        WallState[,] maze = new WallState[width, height];
        //Give each node 4 walls
        WallState initial = WallState.RIGHT | WallState.LEFT | WallState.UP | WallState.DOWN;
        for (int i = 0; i < width; ++i)
        {
            for (int j = 0; j < height; ++j)
            {
                maze[i, j] = initial;  // 1111
            }
        }
        
        return ApplyRecursiveBacktracker(maze, width, height);
    }
}