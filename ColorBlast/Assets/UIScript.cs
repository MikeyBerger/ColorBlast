using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UIScript : MonoBehaviour
{
    public float StartTime;
    public float Timer;
    public int Points;
    public int HiScore;
    public Text CountDownText;
    public Text GameOverText;
    public Text PointText;
    public Canvas InGameCanvas;
    public Canvas GameOverCanvas;
    public bool GameOver;
    public bool GameOver2;


    // Start is called before the first frame update
    void Start()
    {
//        GameOverText.enabled = false;
  //      GameOverText.text = "Game Over";

        //Timer = StartTime;
        StartTime = 180;
        HiScore = PlayerPrefs.GetInt("HiScore", 0);

        //CountDownText.text = Timer.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        /*
        Timer -= Time.deltaTime;
        CountDownText.text = Timer.ToString();
        PointText.text = "Points: " + Points.ToString();
        */

        if (StartTime <= 0)
        {
            InGameCanvas.enabled = false;
            GameOverCanvas.enabled = true;
            //CountDownText.enabled = false;
            //GameOverText.enabled = true;
            GameOver2 = true;
        }

        if (Points > HiScore)
        {
            HiScore = Points;
            PlayerPrefs.SetInt("HiScore", HiScore);
        }
        

        //Use this method
        TimerMethodV2();
    }

    private void TimerMethodV2()
    {
        float t = StartTime - Time.time;

        string Minutes = ((int)t / 60).ToString();
        string Seconds = (t % 60).ToString("f2");

        CountDownText.text = Minutes + ":" + Seconds;
    }

}
