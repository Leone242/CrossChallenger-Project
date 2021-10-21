using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    public void LoadGame()
    {
        SceneManager.LoadScene("game");
    }

    public void ExitGame()
    {
        Application.Quit();


#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#endif
    }
}
