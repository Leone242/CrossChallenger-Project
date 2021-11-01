using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Obstacle : MonoBehaviour
{
    [SerializeField]
    private VelocityFloat velocityVar;
    [SerializeField]
    private UnityEvent passByBarrier;

    public virtual void Update()
    {
        this.transform.Translate(Vector3.left * this.velocityVar.speed * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        passByBarrier.Invoke();
    }


    private ObstacleContainer container;

    public void ReturnObject()
    {
        this.container.ReturnObstacle(this.gameObject);
    }

    public void SetContainer(ObstacleContainer container)
    {
        this.container = container;
    }
}
