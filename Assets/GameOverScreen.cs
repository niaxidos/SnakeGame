using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameOverScreen : MonoBehaviour
{
    public Text scoreText;
    public Text highscoreText;
    
    public void Setup(int score, int highscore){
        gameObject.SetActive(true);
        scoreText.text = "Score: " + score.ToString();
        highscoreText.text = "Highscore: " + highscore.ToString();
    }

   
}
