using UnityEngine;

public class Puzzle1 : MonoBehaviour
{
    // Board is the board for this puzzle. I will use x different chars to make it know what kind of tile is in each position
    char[][] Board = new char[12][];
    char[][] StartBoard = new char[12][];

    bool start = false;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //temporary way to start the puzzle
        if (Input.GetKeyDown(KeyCode.E))
        {
            start = true;
            RestartPuzzle();
        }
        // the reason i have split this up is because it will be easier to make another script set start to true and thereby start this script
        if (start)
        {

        }
    }
    /// <summary>
    /// Restarts the puzzle, resetting it to the original state.
    /// </summary>
    private void RestartPuzzle()
    {
        //sets the board to the original state
        Board = StartBoard;
        return;
    }
    /// <summary>
    /// refreshes the board after each move
    /// </summary>
    private void RefreshPuzzle()
    {

        return;
    }

}
