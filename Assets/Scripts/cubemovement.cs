using UnityEngine;

public class cubemovement : MonoBehaviour
{
    public float speed = 1.2f;
    public bool color;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            transform.position = transform.position + new Vector3(-speed, 0, 0);
        }
        if (Input.GetKeyDown(KeyCode.D))
        {
            transform.position = transform.position + new Vector3(speed, 0, 0);
        }
        if (Input.GetKeyDown(KeyCode.S))
        {
            transform.position = transform.position + new Vector3(0, -speed,0);
        }
        if (Input.GetKeyDown(KeyCode.W))
        {
            transform.position = transform.position + new Vector3(0, speed, 0);
        }

    }
}
