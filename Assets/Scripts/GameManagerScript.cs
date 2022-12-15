using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private int Score;
    private float Timer;
    public float GameFinishTime;
    [HideInInspector] public bool bIsGameOver;

    private void Awake()
    {
        bIsGameOver = false;
        Timer = 0.0f;
        Score = 0;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Timer += Time.deltaTime;
    }

    public void IsGameOver()
    {

    }

    public void HUD()
    {

    }

    public void MainMenu()
    {

    }
}
