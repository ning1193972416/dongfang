using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class misseffect : MonoBehaviour
{
    public Transform mask;
    SpriteRenderer sprite;
    int frame = 1;
    public Vector3 behitpos;
    public boom boomobject;

    void Start()
    {
        sprite = GetComponent<SpriteRenderer>();
        transform.localScale *= 0;
        mask.localScale *= 0;
    }

    void Update()
    {
        if (motion.playerstate == motion.PlayerState.dead)
        {
            if (frame==1)
            {
                transform.position = motion.instance.behit_pos;
                mask.position = motion.instance.behit_pos;
                sprite.enabled = true;
            }
            if (frame <= 35)
                transform.localScale += new Vector3(20, 20, 20) * Time.deltaTime;
            else
                mask.localScale += new Vector3(20, 20, 20) * Time.deltaTime;
            frame+=framemanager.framescale;
        }
        else if(boomobject.booming)
        {
            if (frame == 1)
            {
                transform.position = motion.instance.transform.position;
                sprite.enabled = true;
            }
            if (frame >= 20 && frame <= 60)
                transform.localScale += new Vector3(20, 20, 20) * Time.deltaTime;
            else if(frame>=180)
                sprite.color -= new Color(0, 0, 0, 0.5f * Time.deltaTime);
            frame += framemanager.framescale;
        }
        else
        {
            if (frame != 1)
            {
                sprite.color = Color.white;
                sprite.enabled = false;
                transform.localScale *= 0;
                mask.localScale *= 0;
                frame = 1;
            }
        }
    }
}
