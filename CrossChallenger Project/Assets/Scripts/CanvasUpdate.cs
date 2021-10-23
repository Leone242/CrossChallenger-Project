using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CanvasUpdate : MonoBehaviour
{
    [SerializeField]
    private GameObject odometer;
    [SerializeField]
    private Text distanceText;
    [SerializeField]
    private Text bestScoreText;
    private int newDistance;

    public void UpdInterface(int distance)
    {
        this.distanceText.text = "Distance: " + distance.ToString();
        int bestScore = PlayerPrefs.GetInt("bestScore");
        if(distance > bestScore)
        {
            newDistance = distance;
            UpdBestScore();
        }
        this.bestScoreText.text = "Best Score: 0";

    }
    private void UpdBestScore()
    {
        PlayerPrefs.SetInt("bestScore", newDistance);
        this.bestScoreText.text = "Best Score: " + PlayerPrefs.GetInt("bestScore");
    }

}
