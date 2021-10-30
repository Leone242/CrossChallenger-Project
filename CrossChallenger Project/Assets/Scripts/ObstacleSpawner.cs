using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleSpawner : MonoBehaviour
{
    [SerializeField]
    private Rect area;
    [SerializeField]
    private float timeToSpawn;
    [SerializeField]
    private ObstacleContainer obstacleContainer;
    [SerializeField]
    private Vector2 regulator;

    private void Start()
    {
        InvokeRepeating("Spawn", 0f, timeToSpawn);
    }

    private void Spawn()
    {
        if (this.obstacleContainer.HasObstacle())
        {
            var obstacle = this.obstacleContainer.GetObstacle();
            obstacle.transform.position = this.transform.position / regulator;
        }
    }




    private void OnDrawGizmos()
    {
        Gizmos.color = new Color(0, 100, 0, 1);
        var place = this.area.position + (Vector2)this.transform.position + this.area.size / 2;
        Gizmos.DrawWireCube(place, this.area.size);
    }
}
