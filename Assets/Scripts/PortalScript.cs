using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEditor.Tilemaps;
using UnityEngine;

public class PortalScript : MonoBehaviour
{
    GameObject RedCube;
    GameObject BlueCube;
    GameObject OtherPortal;
    // Start is called before the first frame update
    void Start()
    {
        RedCube = GameObject.FindWithTag("RedCube");
        BlueCube = GameObject.FindWithTag("BlueCube");
        OtherPortal = GameObject.FindGameObjectsWithTag("Portal").Where(g => g != gameObject).FirstOrDefault();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void Teleport(Vector3 movement, GameObject cube)
    {
        cube.transform.position = OtherPortal.transform.position + 0.5f *movement;
        return;
    }
}
