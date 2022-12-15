using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [HideInInspector] public int Score;
    [HideInInspector] public float Timer;
    public static float GameFinishTime;
    public static int GameFinishScore;
    [HideInInspector] public bool bIsGameOver;
    public Player player;
    public FinishPoint finishpoint;
    public Text scoreText;
    public Text timerText;

    private void Awake()
    {
        bIsGameOver = false;
        Timer = 0.0f;
        timerText.text = Timer.ToString();
        Score = 0;
        scoreText.text = Score.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        UpdateGameTimer();
        IsGameOver();
        //Debug.Log("Game Timer: " + Timer);
        //Debug.Log("Player Position: " + player.transform.position);
        //Debug.Log("Player On Finish Point: " + finishpoint.bIsPlayerOnFinishPoint);

    }

    public void IsGameOver()
    {
        if (finishpoint.bIsPlayerOnFinishPoint == true)
        {
            bIsGameOver = true;
            Destroy(player);
            GameOver();
        }

        if(player.bIsPlayerDead == true)
        {
            bIsGameOver = true;
            Destroy(player);
            GameOver();
        }
    }

    public void GameOver()
    {
        if(bIsGameOver)
        {
            GameFinishScore = Score;
            GameFinishTime = Timer;
            //Debug.Log("Game Final Score: " + GameFinishScore);
            //Debug.Log("Game Final Time: " + GameFinishTime);
            //UnityEditor.EditorApplication.ExitPlaymode();
            //UnityEditor.EditorApplication.isPlaying = false;
            SceneManager.LoadScene("Game Over");
        }

    }

    public void UpdateGameTimer()
    {
        //while(!bIsGameOver)
        //{
         Timer += Time.deltaTime;
         timerText.text = Timer.ToString();

        //}
    }

}
