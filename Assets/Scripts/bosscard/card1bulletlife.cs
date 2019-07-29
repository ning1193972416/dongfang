using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class card1bulletlife : blifeTemplate
{
    public override void Start()
    {
        base.Start();
        eblist.instance.cebullet.Add(this);
    }
}
