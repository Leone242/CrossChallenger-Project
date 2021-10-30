using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleContainer : MonoBehaviour
{
    [SerializeField]
    private GameObject[] prefab;
    [SerializeField]
    private int amount;
    private Stack<GameObject> obstacleContainer;


    private void Start()
    {
        this.obstacleContainer = new Stack<GameObject>();
        this.CreateObstacles();
    }

    //private void CreateObstacles()
    //{
    //    Obstacle[] obstacles = GameObject.FindObjectsOfType<Obstacle>();
    //    foreach(Obstacle obstacle in obstacles)
    //    {
    //        obstacle.SetContainer(this);

    //        this.obstacleContainer.Push(obstacle.gameObject);
    //    }
    //}

    private void CreateObstacles()
    {
        for (var i = 0; i < amount; i++)
        {
            var obstacle = GameObject.Instantiate(this.prefab[i], this.transform);
            var containerObject = obstacle.GetComponent<ObstacleContainerObject>();
            containerObject.SetContainer(this);
            obstacle.SetActive(false);
            this.obstacleContainer.Push(obstacle);
        }
    }

    public GameObject GetObstacle()
    {
        var obstacle = this.obstacleContainer.Pop();
        obstacle.SetActive(true);
        return obstacle;
    }

    public void ReturnObstacle(GameObject obstacle)
    {
        obstacle.SetActive(false);
        this.obstacleContainer.Push(obstacle);
    }

    public bool HasObstacle()
    {
        return this.obstacleContainer.Count > 0;
    }
}
