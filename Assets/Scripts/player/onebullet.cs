using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class onebullet : MonoBehaviour
{
    public SpriteRenderer bullet1;
    public SpriteRenderer bullet2;

    void Update()
    {
        if(transform.position.y < 10)
            transform.Translate(new Vector2(0, 16 * Time.deltaTime));
        else
        {
            bullet1.enabled = false;
            bullet2.enabled = false;
            bullet1.GetComponent<BoxCollider2D>().enabled = false;
            bullet2.GetComponent<BoxCollider2D>().enabled = false;
        }
    }

    public void setactive()
    {
        transform.position = motion.instance.player.position;
        bullet1.enabled = true;
        bullet2.enabled = true;
        bullet1.GetComponent<BoxCollider2D>().enabled = true;
        bullet2.GetComponent<BoxCollider2D>().enabled = true;
    }
}
