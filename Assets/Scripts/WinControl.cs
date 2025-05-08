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
    public bool FirstLevel;
    public bool LastLevel;
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
        //StartCoroutine(Timer());
    }

    // Update is called once per frame
    void Update()
    {
        if (redcube.transform.position == redgoal.transform.position && bluecube.transform.position == bluegoal.transform.position)
        {
            if(!redcube.GetComponent<cubemovement>().hitspike && !bluecube.GetComponent<cubemovement>().hitspike)
            {
                if (LastLevel && PlayerPrefs.GetInt("UseTimer") == 1)
                {
                    PlayerPrefs.SetInt("GameComplete", 1);
                }
                SceneManager.LoadScene(nextscene);
            }
            
        }
        if (PlayerPrefs.GetInt("UseTimer") == 1)
        {
            PlayerPrefs.SetFloat("CarryOverTime", PlayerPrefs.GetFloat("CarryOverTime") + Time.deltaTime);
            GameObject.FindWithTag("Stopwatch").GetComponent<TMP_Text>().text = System.Math.Round(PlayerPrefs.GetFloat("CarryOverTime"), 0).ToString();
        }
        
    }
    private void LateUpdate()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            Restart();
        }
    }
    /*IEnumerator Timer()
    {
        while (true)
        {
            WaitForSeconds delay = new WaitForSeconds(1);
            PlayerPrefs.SetInt("CarryOverTime", PlayerPrefs.GetInt("CarryOverTime") + 1);
            yield return delay;
        }
    }*/
    public void Restart()
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
