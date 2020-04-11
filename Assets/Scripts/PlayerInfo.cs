using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerInfo : MonoBehaviour
{
    public int health = 3;
    private OVRGrabbable ovrGrabbable;
    float startTime;
    string minutes, seconds;
    public Text timeText, healthText;
    float t;
    public AudioClip losingHealth, potion;
    private AudioSource audioSource;

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Trap")
        {
            VibrationManager.singleton.TriggerVibration(losingHealth, OVRInput.Controller.LTouch);
            VibrationManager.singleton.TriggerVibration(losingHealth, OVRInput.Controller.RTouch);
            audioSource.PlayOneShot(losingHealth);
            health--;
        }
        else if (other.tag == "Finish")
        {
            PlayerPrefs.SetFloat("Player Time", t);
            VibrationManager.singleton.TriggerVibration(losingHealth, OVRInput.Controller.LTouch);
            VibrationManager.singleton.TriggerVibration(losingHealth, OVRInput.Controller.RTouch);
            int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
            SceneManager.LoadScene((currentSceneIndex + 1) % SceneManager.sceneCountInBuildSettings);
        }
        else if (other.tag == "Potion")
        {
            VibrationManager.singleton.TriggerVibration(losingHealth, OVRInput.Controller.LTouch);
            VibrationManager.singleton.TriggerVibration(losingHealth, OVRInput.Controller.RTouch);
            health++;
            Destroy(other.gameObject, 0.5f);
            audioSource.PlayOneShot(potion);

        }

    }


    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        startTime = Time.time;
        ovrGrabbable = GetComponent<OVRGrabbable>();
    }

    // Update is called once per frame
    void Update()
    {

        healthText.text = "You have " + health.ToString() + " healthpoints";
        healthText.color = Color.green;//Change
        t = Time.time - startTime;

        minutes = ((int)t / 60).ToString();
        seconds = (t % 60).ToString("f2");
        Debug.Log("Time is: " + minutes + ":" + seconds);
        timeText.text = minutes.ToString() + ":" + seconds.ToString();
        timeText.color = Color.yellow;
        if ((int)t / 60 >= 2)
        {
            timeText.color = Color.red;
        }
        else if ((int)t / 60 >= 1)
        {
            timeText.color = Color.blue;
        }

        if (health <= 1)
        {
            healthText.color = Color.red;//Change
        }
        if (health <= 0)
        {
            int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
            if (currentSceneIndex == 1)
            {
                SceneManager.LoadScene(5);
                Debug.Log("You are dead");
            }

            else if (currentSceneIndex == 3)
            {
                SceneManager.LoadScene(6);
                Debug.Log("You are dead");
            }
        }
    }
}
