using System.Collections;
using TMPro;
using UnityEngine;

public class cubemovement : MonoBehaviour
{
    public int movementscore = 0;
    public GameObject othercube;
    public float speed = 1.2f;
    public bool bluecolor;
    public float upperbound = 4.8f;
    public float lowerbound = -3.6f;
    public float rightbound = 6;
    public float leftbound = -7.2f;
    public bool movementfailed;
    public LayerMask mask;
    public LayerMask spike;
    public GameObject spawn;
    public TMP_Text movementcounter;
    public bool hitspike;
    public bool DontMove;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        DontMove = false;
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
        movementcounter = GameObject.FindWithTag("movementcounter").GetComponent<TMP_Text>();
    }

    // Update is called once per frame
    void Update()
    {
        if (DontMove == false)
        {
            if (othercube.GetComponent<cubemovement>().hitspike)
                StartCoroutine(Death());
            movementfailed = false;
            if (Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.LeftArrow))
            {
                movementscore++;
                if (transform.position.x > leftbound)
                    MoveCube(new Vector3(-speed, 0, 0));
            }
            else if (Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.RightArrow))
            {
                movementscore++;
                if (transform.position.x < rightbound)
                    MoveCube(new Vector3(speed, 0, 0));
            }
            else if (Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.DownArrow))
            {
                movementscore++;
                if (transform.position.y > lowerbound)
                    MoveCube(new Vector3(0, -speed, 0));
            }
            else if (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow))
            {
                movementscore++;
                if (transform.position.y < upperbound)
                    MoveCube(new Vector3(0, speed, 0));
            }
            movementcounter.text = movementscore.ToString();
        }
    }
    void MoveCube(Vector3 movement)
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
                transform.GetChild(0).GetComponent<Animator>().SetTrigger("die");
                StartCoroutine(Death());
                hitspike = true;
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

        return;
    }
    IEnumerator Death()
    {
        DontMove = true;
        yield return new WaitForSeconds(1.417f);
        transform.GetChild(0).GetComponent<Animator>().SetTrigger("alive");
        transform.position = spawn.transform.position;
        movementscore = 0;
        hitspike = false;
        DontMove = false;
    }
}
