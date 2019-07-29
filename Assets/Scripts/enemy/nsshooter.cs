using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class nsshooter : MonoBehaviour
{
    public SpriteRenderer bseffect;
    int shootframe = 0;
    int shootdelay = 2;
    public float angle;
    public Vector3 initrotate;
    Vector3 rotate;
    Vector3 localdirect = new Vector3(0, 7);

    void Start()
    {
        rotate = initrotate;
    }

    public void launchnc0()
    {
        shootframe += framemanager.framescale;
        if (shootframe == shootdelay)
        {
            shootframe = 0;
            SpellcardShooter.instance.shootnscard0(angle, ref rotate, localdirect, transform);
        }
    }

    public void launchnc2()
    {
        shootframe += framemanager.framescale;
        if (shootframe == shootdelay)
        {
            shootframe = 0;
            SpellcardShooter.instance.shootnscard0(angle, ref rotate, localdirect, transform);
        }
    }
}
