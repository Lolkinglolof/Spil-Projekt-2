using Unity.Burst.CompilerServices;
using UnityEngine;
using UnityEngine.UI;

public class cubemovement : MonoBehaviour
{
    public GameObject othercube;
    public float speed = 1.2f;
    public bool bluecolor;
    public float upperbound = 4.8f;
    public float lowerbound = -3.6f;
    public float rightbound = 6;
    public float leftbound = -7.2f;
    public bool movementfailed;
    public LayerMask mask;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        if (bluecolor)
        {
            othercube = GameObject.FindWithTag("RedCube");
            mask = LayerMask.GetMask("RedWall");
        }
        else
        {
            othercube = GameObject.FindWithTag("BlueCube");
            mask = LayerMask.GetMask("BlueWall");
        }
    }

    // Update is called once per frame
    void Update()
    {
        movementfailed = false;
            if (Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.LeftArrow))
            {
                if (transform.position.x > leftbound)
                    MoveCube(new Vector3(-speed, 0, 0));
            }
            else if (Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.RightArrow))
            {
                if (transform.position.x < rightbound)
                    MoveCube(new Vector3(speed, 0, 0));
            }
            else if (Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.DownArrow))
            {
                if (transform.position.y > lowerbound)
                    MoveCube(new Vector3(0, -speed, 0));
            }            
            else if (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow))
            {
                if (transform.position.y < upperbound)
                    MoveCube(new Vector3(0, speed, 0));
            }
    }
    void MoveCube(Vector3 movement)
    {
        if (!Physics2D.Raycast(transform.position, movement, 1, mask) && !Physics2D.Raycast(transform.position, movement, 1, LayerMask.GetMask("NeutralWall")))
        {
            Debug.Log("Not blocked by wall");
            //checks if the other cube is blocking the movement
            //runs if it didn't
            if (transform.position + movement != othercube.transform.position)
            {
                //moves the other cube if it got blocked by this one
                //basically just a debug, neccesary because one script runs before the other
                //so it's possible for a cube to be blocked when it shouldn't be without this
                if (othercube.GetComponent<cubemovement>().movementfailed)
                {
                    othercube.transform.position = transform.position;
                }
                //does the actual moving of the cube
                transform.position = transform.position + movement;
            }
            else movementfailed = true;
        }
        else Debug.Log("blocked by wall");
    }
}