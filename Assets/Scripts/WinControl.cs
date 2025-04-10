using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WinControl : MonoBehaviour
{
    public GameObject redcube;
    public GameObject bluecube;
    public GameObject redgoal;
    public GameObject bluegoal;
    public string nextscene;
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
        if (redcube.transform.position == redgoal.transform.position && bluecube.transform.position == bluegoal.transform.position)
        {
            SceneManager.LoadScene(nextscene);
        }
        
    }
    private void LateUpdate()
    {
        //i don't know why, but this breaks if both restart functions are called
        //with this setup, the blue cube needs to be above the red one in the hierarchy
        //and that has to be above this one
        //for whatever reason it apparently just works like this
        //i give up on understanding it
        if (Input.GetKeyDown(KeyCode.R))
        {
            bluecube.GetComponent<cubemovement>().RestartLevel();
            //redcube.GetComponent<cubemovement>().RestartLevel();
        }
    }
}
