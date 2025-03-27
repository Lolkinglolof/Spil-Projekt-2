using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinControl : MonoBehaviour
{
    public GameObject redcube;
    public GameObject bluecube;
    public GameObject redgoal;
    public GameObject bluegoal;
    // Start is called before the first frame update
    void Start()
    {
        redcube = GameObject.FindWithTag("RedCube");
        bluecube = GameObject.FindWithTag("BlueCube");
        redgoal = GameObject.FindWithTag("RedGoal");
        bluegoal = GameObject.FindWithTag("BlueGoal");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
