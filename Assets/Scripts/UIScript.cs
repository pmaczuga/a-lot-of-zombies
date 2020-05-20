using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;
using UnityEngine.UI;

public class UIScript : MonoBehaviour
{
    public float multiplierTime = 1.0f;
    public Text text;
    public Text deathScore;

    private int health = 100;
    private int score = 0;
    private int multiplier = 1;
    private float timeToEndMultiplier = 0.0f;
    private int currentWave;
    private int totalWaves;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        timeToEndMultiplier -= Time.deltaTime;
        if (timeToEndMultiplier <= 0)
            multiplier = 1;

        text.text = "Health: " + health + "\nScore: " + score + "\nMultiplier: " + multiplier + "\nWave: " + (currentWave + 1) + "/" + totalWaves;
        deathScore.text = score.ToString();

    }

    public void SetHealth(int health)
    {
        this.health = health;
    }

    public void AddScore(int score)
    {
        this.score += score * multiplier;
        multiplier += 1;
        timeToEndMultiplier = multiplierTime;
    }

    public void SetCurrentWave(int currentWave)
    {
        this.currentWave = currentWave;
    }

    public void SetTotalWaves(int totalWaves)
    {
        this.totalWaves = totalWaves;
    }
}
