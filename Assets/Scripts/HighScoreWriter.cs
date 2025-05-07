using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Linq;
using TMPro;

public class HighScoreWriter : MonoBehaviour
{
    int HighScoreTime;
    int CarryOverTime;
    GameObject HighScoreTimeText;
    // Start is called before the first frame update
    void Start()
    {
        HighScoreTime = PlayerPrefs.GetInt("HighScoreTime");
        CarryOverTime = PlayerPrefs.GetInt("CarryOverTime");
        if (CarryOverTime < HighScoreTime)
        {
            HighScoreTime = CarryOverTime;
        }
        PlayerPrefs.SetInt("HighScoreTime", HighScoreTime);
        PlayerPrefs.Save();
    }

    // Update is called once per frame
    void Update()
    {
        GameObject.FindWithTag("Stopwatch").GetComponent<TMP_Text>().text = "Last Time: "+PlayerPrefs.GetInt("CarryOverTime").ToString();
        GameObject.FindWithTag("HighScore").GetComponent<TMP_Text>().text = "Best Time: " + PlayerPrefs.GetInt("HighScoreTime").ToString();
    }
}
