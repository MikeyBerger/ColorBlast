using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UIScript : MonoBehaviour
{
    public float StartTime;
    public float Timer;
    public float Points;
    public Text CountDownText;
    public Text GameOverText;
    public Text PointText;
    public bool GameOver;
    public bool GameOver2;


    // Start is called before the first frame update
    void Start()
    {
        GameOverText.enabled = false;
        GameOverText.text = "Game Over";

        Timer = StartTime;

        CountDownText.text = Timer.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        Timer -= Time.deltaTime;
        CountDownText.text = Timer.ToString();
        PointText.text = "Points: " + Points.ToString();

        if (Timer <= 0)
        {
            CountDownText.enabled = false;
            GameOverText.enabled = true;
            GameOver2 = true;
        }
    }

   
}
