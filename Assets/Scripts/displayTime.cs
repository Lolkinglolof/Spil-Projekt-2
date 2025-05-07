using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SocialPlatforms;

public class displayTime : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        GameObject.FindWithTag("Stopwatch").GetComponent<TMP_Text>().text = PlayerPrefs.GetFloat("CarryOverTime").ToString();
    }
}
