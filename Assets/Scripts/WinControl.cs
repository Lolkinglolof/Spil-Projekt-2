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
    public int levelnumber;
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

                int movementcount = int.Parse(GameObject.FindWithTag("movementcounter").GetComponent<TMP_Text>().text);
                int minmove = 1;
                switch (levelnumber)
                {
                    case 1:
                        minmove = 5;
                        break;
                    case 2:
                        minmove = 4;
                        break;
                    case 3:
                        minmove = 7;
                        break;
                    case 4:
                        minmove = 17;
                        break;
                    case 5:
                        minmove = 7;
                        break;
                    case 6:
                        minmove = 8;
                        break;
                    case 7:
                        minmove = 15;
                        break;
                    case 8:
                        minmove = 13;
                        break;
                    case 9:
                        minmove = 17;
                        break;
                    case 10:
                        minmove = 23;
                        break;
                }
                if (movementcount < PlayerPrefs.GetInt("Level"+levelnumber+"Moves") || PlayerPrefs.GetInt("Level" + levelnumber + "Moves") == 0)
                {
                    if (minmove > movementcount && PlayerPrefs.GetInt("Level" + levelnumber + "Moves") != 0)
                        movementcount = PlayerPrefs.GetInt("Level" + levelnumber + "Moves");
                        PlayerPrefs.SetInt("Level" + levelnumber + "Moves", movementcount);
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
