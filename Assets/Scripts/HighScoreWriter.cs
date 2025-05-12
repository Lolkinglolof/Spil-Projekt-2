using TMPro;
using UnityEngine;

public class HighScoreWriter : MonoBehaviour
{
    float HighScoreTime;
    float CarryOverTime;
    int GameComplete;
    int[] LevelMoves = new int[9];
    public GameObject LevelSelectMenu;
    public GameObject highScoreText;
    int TotalMoves;
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
            GameObject.FindWithTag("Stopwatch").GetComponent<TMP_Text>().text = "Last Time: " + System.Math.Round(PlayerPrefs.GetFloat("CarryOverTime"), 3).ToString();
            PlayerPrefs.SetInt("GameComplete", 0);
        }
        else GameObject.FindWithTag("Stopwatch").GetComponent<TMP_Text>().text = "Last Time: Invalid";

        PlayerPrefs.SetFloat("HighScoreTime", HighScoreTime);
        PlayerPrefs.Save();

        highScoreText.GetComponent<TMP_Text>().text = "Best Time: " + System.Math.Round(PlayerPrefs.GetFloat("HighScoreTime"), 3).ToString();
        // IMPORTANT!!!! do not fix the error beneath, it works, i don't know why it says it's wrong... trust me.
        for (int i = 0; i < 9; i++)
        {
            int u = i + 1;
            LevelMoves[i] = PlayerPrefs.GetInt("Level" + u + "Moves");
            TotalMoves += LevelMoves[i];
            Debug.Log("Level" + u + "Moves");
            Debug.Log(LevelMoves[i]);
            TextMeshPro Text = LevelSelectMenu.transform.GetChild(i + 2).GetChild(2).GetChild(1).GetComponent<TextMeshPro>();
            Text.text = "Least Moves: " + LevelMoves[i];
            Debug.Log(Text.text.ToString());
        }
        if (TotalMoves <= 98)
        {
            PlayerPrefs.SetInt("SecretUnlocked", 1);
            Debug.Log("Unlocked");
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
}
