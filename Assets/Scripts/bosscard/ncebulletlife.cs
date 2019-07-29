using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ncebulletlife : blifeTemplate
{
    public override void Start()
    {
        base.Start();
        eblist.instance.ncebullet.Add(this);
    }
}
