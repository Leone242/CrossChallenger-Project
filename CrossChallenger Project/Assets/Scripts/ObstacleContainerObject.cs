using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleContainerObject : MonoBehaviour
{
    private ObstacleContainer theContainer;

    public void ReturnObject()
    {
        this.theContainer.ReturnObstacle(this.gameObject);
    }

    public void SetContainer(ObstacleContainer container)
    {
        this.theContainer = container;
    }
}
