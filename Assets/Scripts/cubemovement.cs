using Unity.Burst.CompilerServices;
using UnityEngine;
using UnityEngine.SceneManagement;
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
    public bool DontMove;
    public LayerMask mask;
    public LayerMask spike;
    public GameObject spawn;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        if (bluecolor)
        {
            spawn = GameObject.FindWithTag("BlueSpawn");
            othercube = GameObject.FindWithTag("RedCube");
            mask = LayerMask.GetMask("RedWall");
            spike = LayerMask.GetMask("RedSpike");
        }
        else
        {
            spawn = GameObject.FindWithTag("RedSpawn");
            othercube = GameObject.FindWithTag("BlueCube");
            mask = LayerMask.GetMask("BlueWall");
            spike = LayerMask.GetMask("BlueSpike");
        }
        spawn.transform.position = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        movementfailed = false;
        DontMove = false;
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
        if (othercube.GetComponent<cubemovement>().DontMove == false)
        {
            if (Physics2D.Raycast(transform.position, movement, 1).collider != null && Physics2D.Raycast(transform.position, movement, 1).collider.gameObject.tag == "Portal")
            {
                if (othercube.GetComponent<cubemovement>().movementfailed)
                {
                    othercube.transform.position = transform.position;
                }
                GameObject Portal = Physics2D.Raycast(transform.position, movement, 1).collider.gameObject;
                Portal.GetComponent<PortalScript>().Teleport(movement, gameObject);
            }
            else if (!Physics2D.Raycast(transform.position, movement, 1, mask) && !Physics2D.Raycast(transform.position, movement, 1, LayerMask.GetMask("NeutralWall")))
            {
                if (Physics2D.Raycast(transform.position, movement, 1.2f, spike) || Physics2D.Raycast(transform.position, movement, 1.2f, LayerMask.GetMask("NeutralSpike")))
                {
                    transform.position = spawn.transform.position;
                    othercube.transform.position = othercube.GetComponent<cubemovement>().spawn.transform.position;
                    DontMove = true;
                }
                else if (transform.position + movement != othercube.transform.position)
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
        }
        return;
    }
}