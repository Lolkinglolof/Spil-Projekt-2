using TMPro;
using UnityEngine;

public class HighScoreWriter : MonoBehaviour
{
    float HighScoreTime;
    float CarryOverTime;
    int GameComplete;
    // Start is called before the first frame update
    void Start()
    {
        HighScoreTime = PlayerPrefs.GetFloat("HighScoreTime");
        CarryOverTime = PlayerPrefs.GetFloat("CarryOverTime");
        GameComplete = PlayerPrefs.GetInt("GameComplete");
        if (GameComplete == 1)
        {
            if (CarryOverTime < HighScoreTime || HighScoreTime == 0)
            {
                HighScoreTime = CarryOverTime;
            }
            GameObject.FindWithTag("Stopwatch").GetComponent<TMP_Text>().text = "Last Time: " + PlayerPrefs.GetFloat("CarryOverTime").ToString();
            PlayerPrefs.SetInt("GameComplete", 0);
        } else GameObject.FindWithTag("Stopwatch").GetComponent<TMP_Text>().text = "Last Time: Invalid";

        PlayerPrefs.SetFloat("HighScoreTime", HighScoreTime);
        PlayerPrefs.Save();
        
        GameObject.FindWithTag("HighScore").GetComponent<TMP_Text>().text = "Best Time: " + PlayerPrefs.GetFloat("HighScoreTime").ToString();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
