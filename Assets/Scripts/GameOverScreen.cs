using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameOverScreen : MonoBehaviour
{
    public Text gameOverScoreText;
    public Text gameOverTimerText;

    private void Awake()
    {
        gameOverScoreText.text = GameManager.GameFinishScore.ToString();
        gameOverTimerText.text = GameManager.GameFinishTime.ToString();
    }


}
