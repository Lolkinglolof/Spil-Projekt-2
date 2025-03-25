using UnityEngine;

public class cubemovement : MonoBehaviour
{
    public GameObject othercube;
    public float speed = 1.2f;
    public bool color;
    public float upperbound = 4.8f;
    public float lowerbound = -3.6f;
    public float rightbound = 6;
    public float leftbound = -7.2f;
    public bool movementfailed;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        if (color)
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
        if (transform.position.x > leftbound)
        {
            if (Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.LeftArrow))
            {
                if (transform.position + new Vector3(-speed, 0, 0) != othercube.transform.position)
                {
                    if (othercube.GetComponent<cubemovement>().movementfailed)
                    {
                        othercube.transform.position = transform.position;
                    }
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
