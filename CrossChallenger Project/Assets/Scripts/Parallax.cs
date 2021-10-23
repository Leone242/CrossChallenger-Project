using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Parallax : MonoBehaviour
{
    [SerializeField]
    private VelocityFloat velocityVar;
    protected Vector3 initialPosition;
    protected float imgSize;

    public virtual void Awake()
    {
        this.initialPosition = this.transform.position;
        this.imgSize = this.GetComponent<SpriteRenderer>().size.x;
    }


    private void Update()
    {
        float mov = Mathf.Repeat(this.velocityVar.speed * Time.time, this.imgSize/2);
        this.transform.position = this.initialPosition + Vector3.left * mov;
    }
}
