using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class generalshooter : MonoBehaviour
{
    public GameObject[] bullet;
    private int relay = 2;
    private int frame = 0;
    private int bulletindex = 0;

    // Update is called once per frame
    void FixedUpdate()
    {
        if(frame==relay)
        {
            bullet[bulletindex].GetComponent<onebullet>().setactive();
            bulletindex++;
        }
        if (bulletindex == bullet.Length)
            bulletindex = 0;
        frame++;
        if (frame == relay + 1)
            frame = 0;
    }
}
