using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Cinemachine;
using System.Linq;

//Reference --> https://www.youtube.com/watch?v=ya1HyptE5uc&t=9s

//This class renders the maze walls and draws the maze


public class MazeRenderer : MonoBehaviour
{
    //Variables
    [SerializeField] private int width = 2;
    [SerializeField] private int height = 2;
    [SerializeField] private float size = 1f;
    [SerializeField] private Transform wallPrefab = null;
    [SerializeField] private Transform floorPrefab = null;
    [SerializeField] private GameObject parentObj;
    [SerializeField] private GameObject widthField;
    [SerializeField] private GameObject heightField;
    [SerializeField] private Text curWidth;
    [SerializeField] private Text curHeight;
    [SerializeField] private GameObject finish;
    public Transform Player, Goal;

    //Body
    public void Start()
    {
        if (finish.gameObject.tag == "finish")
        {
            if (width == 0) { width = 7; }
            if (height == 0) { height = 7; }
            if (width == 1 && height == 1) { width = 2; height = 2; }
        }

        //Generate a new maze with specified width and height
        var maze = MazeGenerator.Generate(width, height);
        //Set the players position to a random area.
        Player.position = randomPosition(Player);

        /*Set the finish lines position to a random area 
        * that is outside a certain range of the player.
        */
        do Goal.position = randomPosition(Goal);
        while (Vector3.Distance(Player.position, Goal.position) < (width + height) / 4);

        //Update the width and height text.
        curWidth.text = width.ToString();
        curHeight.text = height.ToString();

        //Draw the maze.
        Draw(maze);
    }

    Vector3 randomPosition(Transform input)
    {
        int x;
        int z;

        //Set input position to 0,0,0 (The center of the maze)
        input.position = new Vector3(0, 0, 0);

        /*Set input position to the bottom left corner of the 
        * maze by dividing the height and width by 2.
        */
        input.position = new Vector3(input.transform.position.x - width / 2, 0,
        input.transform.position.z - height / 2);

        //Set a random height and width for the gameobject
        x = Random.Range(0, width);
        z = Random.Range(0, height);

        //Set the new postion of the gameobject to the random one.
        input.position = new Vector3(input.transform.position.x + x, 0,
        input.transform.position.z + z);

        //Return the new random transform.
        return input.position;
    }

    private void Draw(WallState[,] maze)
    {
        var floor = Instantiate(floorPrefab, transform);
        floor.localScale = new Vector3(width / 2, 1, height / 2);

        
        for (int i = 0; i < width; ++i)
        {
            for (int j = 0; j < height; ++j)
            {
                var cell = maze[i, j];
                var position = new Vector3(-width / 2 + i, 0, -height / 2 + j);

                //If this node has a wall on the top, instantiate a wall there
                if (cell.HasFlag(WallState.UP))
                {
                    var topWall = Instantiate(wallPrefab, transform) as Transform;
                    topWall.position = position + new Vector3(0, 0, size / 2);
                    topWall.localScale = new Vector3(size, topWall.localScale.y, topWall.localScale.z);
                }

                //If this node has a wall on the left, instantiate a wall there
                if (cell.HasFlag(WallState.LEFT))
                {
                    var leftWall = Instantiate(wallPrefab, transform) as Transform;
                    leftWall.position = position + new Vector3(-size / 2, 0, 0);
                    leftWall.localScale = new Vector3(size, leftWall.localScale.y, leftWall.localScale.z);
                    leftWall.eulerAngles = new Vector3(0, 90, 0);
                }
                
                //If on last column, check if cell has a right wall.
                if (i == width - 1)
                {
                    //If this node has a wall on the right, instantiate a wall there
                    if (cell.HasFlag(WallState.RIGHT))
                    {
                        var rightWall = Instantiate(wallPrefab, transform) as Transform;
                        rightWall.position = position + new Vector3(+size / 2, 0, 0);
                        rightWall.localScale = new Vector3(size, rightWall.localScale.y, rightWall.localScale.z);
                        rightWall.eulerAngles = new Vector3(0, 90, 0);
                    }
                }

                //Check if it is the first row
                if (j == 0)
                {
                    //If this node has a wall on the bottom, instantiate a wall there
                    if (cell.HasFlag(WallState.DOWN))
                    {
                        var bottomWall = Instantiate(wallPrefab, transform) as Transform;
                        bottomWall.position = position + new Vector3(0, 0, -size / 2);
                        bottomWall.localScale = new Vector3(size, bottomWall.localScale.y, bottomWall.localScale.z);
                    }
                }
            }

        }

    }

    //Get inputted width value from the text boxes
    public void setWidth()
    {
        //If the gameObject tag is equal to "finish", then the gamemode is practice
        if (finish.gameObject.tag == "finish")
        {
            int output;
            int.TryParse(widthField.GetComponent<Text>().text, out output);
            width = output;
        }
    }

    //Get inputted height value from the text boxes
    public void setHeight()
    {
        //if the tag is "finish", then the gamemode is practice
        if (finish.gameObject.tag == "finish")
        {
            int output;
            int.TryParse(heightField.GetComponent<Text>().text, out output);
            height = output;
        }
    }

    //ReGenerate a new maze with specified a height or width
    public void ReGenerateMaze()
    {
        setWidth();
        setHeight();
        deleteMaze();
        Start();
    }

    //Delete all children(Walls) from the maze renderer gameobject
    public void deleteMaze()
    {
        foreach (Transform child in parentObj.transform)
        {
            GameObject.Destroy(child.gameObject);
        }
    }

    //Increase Difficulty by increasing both width & height
    public void increaseDifficulty()
    {
        width++;
        height++;
    }
    
    //Return the current difficulty level
    public int getScore()
    {
        return width;
    }
}