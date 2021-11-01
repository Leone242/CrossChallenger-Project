using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Odometer : MonoBehaviour
{

    private float distance;
    [SerializeField]
    private CanvasUpdate interfaceCanvas;
    private float distanceUnity = 0.014f;
    private bool odometerActive = true;


    private void Update()
    {
        if (odometerActive)
        {
            CoutDistance();
        }
    }

    public void RestartOdometer()
    {
        distance = 0;
    }

    private void CoutDistance()
    {
        this.distance += distanceUnity;
        this.interfaceCanvas.UpdInterface((int)distance);
    }

    public void SetOdometerBool(bool shifter)
    {
        odometerActive = shifter;
    }
}
