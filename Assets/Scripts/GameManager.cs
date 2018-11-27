using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {

    public int lives;
    public int score; 
    public Text scoreText;
    public Text livesText;

    // Use this for initialization
    void Start () {
        livesText.text = "Lives: " + lives;
        scoreText.text = "Score: " + score;
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void UpdateLives(int changeLives){
        lives += changeLives;
        livesText.text = "Lives: " + lives;
    }
    public void UpdateScore(int ScoreChange){
        score += ScoreChange;
        scoreText.text = "Score: " + score;
    }
}
