using UnityEngine;

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
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        if (bluecolor)
        {
            othercube = GameObject.FindWithTag("RedCube");
        }
        else othercube = GameObject.FindWithTag("BlueCube");
    }

    // Update is called once per frame
    void Update()
    {
        movementfailed = false;
        //moving left
        //commenting only this one, others follow the same structure
        if (transform.position.x > leftbound)
        {
            //player input check
            if (Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.LeftArrow))
            {
                //checks if the other cube is blocking the movement
                if (transform.position + new Vector3(-speed, 0, 0) != othercube.transform.position)
                {
                    //moves the other cube if it got blocked
                    //basically just a debug, neccesary because one script runs before the other
                    //so it's possible for a cube to be blocked when it shouldn't be without this
                    if (othercube.GetComponent<cubemovement>().movementfailed)
                    {
                        othercube.transform.position = transform.position;
                    }
                    //does the actual moving of the cube
                    transform.position = transform.position + new Vector3(-speed, 0, 0);
                }
                else movementfailed = true;
            }
        }
        //moving right
        if (transform.position.x < rightbound)
        {
            if (Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.RightArrow))
            {
                
                if (transform.position + new Vector3(speed, 0, 0) != othercube.transform.position)
                {
                    if (othercube.GetComponent<cubemovement>().movementfailed)
                    {
                        othercube.transform.position = transform.position;
                    }
                    transform.position = transform.position + new Vector3(speed, 0, 0);
                }
                else movementfailed = true;
            }
        }
       //moving down
       if (transform.position.y > lowerbound)
        {
            if (Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.DownArrow))
            {
                if (transform.position + new Vector3(0, -speed, 0) != othercube.transform.position)
                {
                    if (othercube.GetComponent<cubemovement>().movementfailed)
                    {
                        othercube.transform.position = transform.position;
                    }
                    transform.position = transform.position + new Vector3(0, -speed, 0);
                }
                else movementfailed = true;
            }
        }
        //moving up
        if (transform.position.y < upperbound)
        {
            if (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow))
            {
                if (transform.position + new Vector3(0, speed, 0) != othercube.transform.position)
                {
                    if (othercube.GetComponent<cubemovement>().movementfailed)
                    {
                        othercube.transform.position = transform.position;
                    }
                    transform.position = transform.position + new Vector3(0, speed, 0);
                }
                else movementfailed = true;
            }
        }
    }
}
