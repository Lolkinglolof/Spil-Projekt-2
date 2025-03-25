using Unity.Mathematics;
using UnityEngine;

public class Puzzle1 : MonoBehaviour
{
    // Board is the board for this puzzle. I will use x different chars to make it know what kind of tile is in each position
    char[][] Board = new char[12][];
    char[][] StartBoard = new char[12][];
    char[][] walls = new char[23][];
    char[][][] Map = new char[2][][];
    // 6 tiles and 3 walls for now, tiles being spikes of both colours and neutral, and a victory point for each, and empty ofc
    public GameObject[] Tiles = new GameObject[6];
    // the 4 walls being both colours, neutral and empty
    public GameObject[] Wall = new GameObject[4];
    // here i make some decoders, so my code easily can refer to an array to find the gameobject
    public char[] TileCode = new char[5];
    public char[] WallCode = new char[4];
    // made a bool called start, cuz it's useful i think, idrk
    public bool start = false;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Map[0] = Board;
        Map[1] = walls;
        start = true;
        // sets up the initial board, this is for test reasons
        for (int i = 0; i < StartBoard.Length; i++)
        {
            char[] column = new char[8];
            for (int j = 0; j < column.Length; j++)
            {
                column[j] = 'E';
            }
            StartBoard[i] = column;
        }
        for (int i = 0; i < walls.Length; i++)
        {
            char[] column;
            if (i % 2 == 0)
            {
                column = new char[7];
            }
            else
            {
                column = new char[8];
            }
            for (int j = 0; j < column.Length; j++)
            {
                column[j] = 'E';
            }
            Map[1][i] = column;
        }
        // for now it's all empty
    }

    // Update is called once per frame
    void Update()
    {
        
        if (start)
        {
            RestartPuzzle();
            CreateBoard(Map);
            start = false;
        }
    }
    /// <summary>
    /// Restarts the puzzle, resetting it to the original state.
    /// </summary>
    private void RestartPuzzle()
    {
        //sets the board to the original state
        Map[0] = StartBoard;
        return;
    }
    /// <summary>
    /// Instantiates the board, please don't touch anything inside, it works. just change the board, then run this
    /// </summary>
    private void CreateBoard(char[][][] M)
    {
        char[][] B = M[0];
        char[][] W = M[1];
        float x = B.Length * -0.6f;
        foreach (char[] col in B)
        {
            float y = B[0].Length * 0.6f;
            foreach (char c in col)
            {
                for (int i = 0; i < TileCode.Length; i++)
                {
                    if (c == TileCode[i])
                    {
                        Instantiate(Tiles[i], new Vector3(x, y, 0), Quaternion.identity);
                    }
                }
                y -= 1.2f;
            }
            x += 1.2f;
        }
        x = B.Length * -0.6f;

        foreach (char[] col in W)
        {
            float y = B[0].Length * 0.6f;
            float Wy;

            Quaternion rotaion;
            if (col.Length % 2 == 0)
            {
                rotaion = quaternion.Euler(0, 90, 0);

                Wy = y - 0.6f;
            }
            else
            {
                rotaion = Quaternion.identity;
                Wy = y;
            }
            foreach (char c in col)
            {
                if (col.Length % 2 == 0)
                {
                    rotaion = Quaternion.Euler(new Vector3(0, 0, 0));
                    Wy = y;
                }
                else
                {
                    rotaion = Quaternion.Euler(new Vector3(0, 0, 90));
                    Wy = y - 0.6f;
                }
                for (int i = 0; i < WallCode.Length; i++)
                {
                    if (c == WallCode[i])
                    {
                        Instantiate(Wall[i], new Vector3(x, Wy, -1), rotaion);
                    }
                }
                y -= 1.2f;

            }
            x += 0.6f;
        }

    }

}
