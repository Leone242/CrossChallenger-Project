using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CanvasUpdate : MonoBehaviour
{
    [SerializeField]
    private Text distanceText;
    [SerializeField]
    private Text bestScoreText;
    [SerializeField]
    private Text scoreText;
    private int newDistance;
    private int bestScore;
    private int distanceEndGame;

    public void UpdInterface(int distance)
    {
        this.distanceEndGame = distance;
        this.distanceText.text = "Distance: " + distance.ToString();
        bestScore = PlayerPrefs.GetInt("bestScore");
        if(distance > bestScore)
        {
            newDistance = distance;
            UpdBestScore();
        }
    }

    private void UpdBestScore()
    {
        PlayerPrefs.SetInt("bestScore", newDistance);
        this.bestScoreText.text = "Best Score: " + PlayerPrefs.GetInt("bestScore");
    }

    public void UpdGameOver()
    {        
        scoreText.text = "Score: " + distanceEndGame.ToString();
        bestScoreText.text = "Best Score: " + PlayerPrefs.GetInt("bestScore");
    }
}
