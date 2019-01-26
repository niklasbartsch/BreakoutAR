using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {

    public int lives;
    public int score;
    public GameObject gameOverObject;
    public GameObject youWonObject;

    public TextMesh scoreText;
    public TextMesh livesText;
    public TextMesh countdownText;
    public bool isTracked = false;


    // Use this for initialization
    void Start () {
        livesText.text = "Lives: " + lives;
        scoreText.text = "Score: " + score;
        countdownText.text = "100";
		
	}
	
	// Update is called once per frame
	void Update () {
		if(lives <= 0)
        {
            gameOverObject.gameObject.SetActive(true);
            
        }
        if(score >= 1140)
        {
            youWonObject.gameObject.SetActive(true);
        }
    }
    public void UpdateCountdown(int value)
    {
        countdownText.text = "" + value;
    }
    public void UpdateLives(int changeLives){
        lives += changeLives;

        if(lives >= 0)
        {
            livesText.text = "Lives: " + lives;
        }

    }
    public void UpdateScore(int ScoreChange){
        score += ScoreChange;
        scoreText.text = "Score: " + score;
    }
}
