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
        if (Input.GetKeyDown(KeyCode.A) && transform.position.x > leftbound)
        {
            transform.position = transform.position + new Vector3(-speed, 0, 0);
        }
        if (Input.GetKeyDown(KeyCode.D) && transform.position.x < rightbound)
        {
            transform.position = transform.position + new Vector3(speed, 0, 0);
        }
        if (Input.GetKeyDown(KeyCode.S) && transform.position.y > lowerbound)
        {
            transform.position = transform.position + new Vector3(0, -speed,0);
        }
        if (Input.GetKeyDown(KeyCode.W) && transform.position.y < upperbound)
        {
            transform.position = transform.position + new Vector3(0, speed, 0);
        }

    }
}
