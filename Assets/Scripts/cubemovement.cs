using UnityEngine;

public class cubemovement : MonoBehaviour
{
    public float speed = 1.2f;
    public bool color;
    public float upperbound = 4.8f;
    public float lowerbound = -3.6f;
    public float rightbound = 6;
    public float leftbound = -7.2f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //moving left
        if (transform.position.x > leftbound)
        {
            if (Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.LeftArrow))
            {
                transform.position = transform.position + new Vector3(-speed, 0, 0);
            }
        }
        //moving right
        if (transform.position.x < rightbound)
        {
            if (Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.RightArrow))
            {
                transform.position = transform.position + new Vector3(speed, 0, 0);
            }
        }
       //moving down
       if (transform.position.y > lowerbound)
        {
            if (Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.DownArrow))
            {
                transform.position = transform.position + new Vector3(0, -speed, 0);
            }
        }
        //moving up
        if (transform.position.y < upperbound)
        {
            if (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow))
            {
                transform.position = transform.position + new Vector3(0, speed, 0);
            }
        }
    }
}
