using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Advertisements.Platform.Editor;
using UnityEngine.SceneManagement;

public class WinControl : MonoBehaviour
{
    public GameObject redcube;
    public GameObject bluecube;
    public GameObject redgoal;
    public GameObject bluegoal;
    public string nextscene;
    public float timescore;
    public bool FirstLevel;
    // Start is called before the first frame update
    void Start()
    {
        redcube = GameObject.FindWithTag("RedCube");
        bluecube = GameObject.FindWithTag("BlueCube");
        redgoal = GameObject.FindWithTag("RedGoal");
        bluegoal = GameObject.FindWithTag("BlueGoal");
        if (FirstLevel)
        {
            PlayerPrefs.SetFloat("CarryOverTime", 0);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (redcube.transform.position == redgoal.transform.position && bluecube.transform.position == bluegoal.transform.position)
        {
            if(!redcube.GetComponent<cubemovement>().hitspike && !bluecube.GetComponent<cubemovement>().hitspike)
            SceneManager.LoadScene(nextscene);
        }
        
        timescore = PlayerPrefs.GetFloat("CarryOverTime");
        PlayerPrefs.SetFloat("CarryOverTime", timescore + Time.deltaTime);
        GameObject.FindWithTag("Stopwatch").GetComponent<TMP_Text>().text = timescore.ToString();
    }
    private void LateUpdate()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            if (bluecube.GetComponent<cubemovement>().DontMove == false && redcube.GetComponent<cubemovement>().DontMove == false)
            {
                bluecube.transform.position = bluecube.GetComponent<cubemovement>().spawn.transform.position;
                redcube.transform.position = redcube.GetComponent<cubemovement>().spawn.transform.position;
                redcube.GetComponent<cubemovement>().movementscore = 0;
                bluecube.GetComponent<cubemovement>().movementscore = 0;
            }
        }
    }
}
