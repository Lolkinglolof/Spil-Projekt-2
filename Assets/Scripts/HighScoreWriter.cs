using TMPro;
using UnityEngine;

public class HighScoreWriter : MonoBehaviour
{
    int HighScoreTime;
    int CarryOverTime;
    int GameComplete;
    // Start is called before the first frame update
    void Start()
    {
        HighScoreTime = PlayerPrefs.GetInt("HighScoreTime");
        CarryOverTime = PlayerPrefs.GetInt("CarryOverTime");
        GameComplete = PlayerPrefs.GetInt("GameComplete");
        if (GameComplete == 1)
        {
            if (CarryOverTime < HighScoreTime || HighScoreTime == 0)
            {
                HighScoreTime = CarryOverTime;
            }
            GameObject.FindWithTag("Stopwatch").GetComponent<TMP_Text>().text = "Last Time: " + PlayerPrefs.GetInt("CarryOverTime").ToString();
            PlayerPrefs.SetInt("GameComplete", 0);
        } else GameObject.FindWithTag("Stopwatch").GetComponent<TMP_Text>().text = "Last Time: Invalid";

        PlayerPrefs.SetInt("HighScoreTime", HighScoreTime);
        PlayerPrefs.Save();
        
        GameObject.FindWithTag("HighScore").GetComponent<TMP_Text>().text = "Best Time: " + PlayerPrefs.GetInt("HighScoreTime").ToString();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
