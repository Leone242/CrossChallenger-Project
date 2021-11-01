using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Manager : MonoBehaviour
{
    [SerializeField]
    private Odometer odometer;
    [SerializeField]
    private CanvasUpdate canvasUpdate;
    [SerializeField]
    private GameObject gameOverPanel;
    [SerializeField]
    private AudioSource soundTrack;
    [SerializeField]
    private AudioClip audioGameOver;


    private void Start()
    {
        Time.timeScale = 1;
    }

    public void StopGame()
    {
        AudioController.instance.PlayOneShot(audioGameOver);
        odometer.SetOdometerBool(false);
        StartCoroutine("WaitToFinish");
    }
    private void EndGame()
    {
        gameOverPanel.SetActive(true);

        canvasUpdate.UpdGameOver();
        soundTrack.Stop();
    }

    private IEnumerator WaitToFinish()
    {
        yield return new WaitForSecondsRealtime(0.5f);
        EndGame();
    }

    public void RestartGame()
    {
        SceneManager.LoadScene("game");
    }

    public void QuitGame()
    {
        Application.Quit();


        #if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
        #endif
    }
}
