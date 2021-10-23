using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Parallax2 : Parallax
{
    public override void Awake()
    {
        base.Awake();
        this.imgSize = base.imgSize * 4;
    }
}
