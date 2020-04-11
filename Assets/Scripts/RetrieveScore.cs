using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
//this script helped in retrieving the score from the core game scene to display in the death scene
public class RetrieveScore : MonoBehaviour
{
    public Text playerTime;
    void Start()
    {
        float t = PlayerPrefs.GetFloat("Player Time");
        string minutes = ((int)t / 60).ToString();
        string seconds = (t % 60).ToString("f2");
        playerTime.text = minutes.ToString() + ":" + seconds.ToString();
    }
}
