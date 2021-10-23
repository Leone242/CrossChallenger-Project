using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Odometer : MonoBehaviour
{
    private float movement;
    private float distance;
    [SerializeField]
    private CanvasUpdate interfaceCanvas;
    private float distanceUnity = 0.014f;

    private Vector3 startPoint;


    private void Awake()
    {
        this.startPoint = this.transform.position;
    }

    private void Update()
    {
        this.movement = this.startPoint.x * Time.deltaTime;
        if (this.movement <= startPoint.x)
        {
            this.CoutDistance();
            this.movement = 0;
        }
    }

    private void CoutDistance()
    {
        this.distance += distanceUnity;
        this.interfaceCanvas.UpdInterface((int)distance);
    }
}
