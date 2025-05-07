using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Linq;

public class HighScoreWriter : MonoBehaviour
{
    float HighScoreTime;
    float CarryOverTime;
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
        
    }
}
