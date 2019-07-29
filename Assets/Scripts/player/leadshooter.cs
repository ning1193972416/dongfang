using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class leadshooter : MonoBehaviour
{
    public GameObject[] bullet;
    private int relay = 4;
    private int frame = 0;
    private int bulletindex = 0;

    // Update is called once per frame
    void FixedUpdate()
    {
        if (frame == relay)
        {
            bullet[bulletindex].GetComponent<leadbullet>().setactive();
            bulletindex++;
        }
        if (bulletindex == bullet.Length)
            bulletindex = 0;
        frame++;
        if (frame == relay + 1)
            frame = 0;
        transform.Rotate(0, 0, 360 * Time.deltaTime);
    }
}
