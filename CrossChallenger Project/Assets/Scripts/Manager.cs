using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Manager : MonoBehaviour
{
    public void StopGame()
    {
        Time.timeScale = 0;
    }
}
