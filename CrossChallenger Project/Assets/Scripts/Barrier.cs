using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Barrier : MonoBehaviour
{
    [SerializeField]
    private Rect area;
    private void OnDrawGizmos()
    {
        Gizmos.color = new Color(0, 100, 100, 1);
        var place = this.area.position + (Vector2)this.transform.position + this.area.size;
        Gizmos.DrawWireCube(place, this.area.size);
    }
}
