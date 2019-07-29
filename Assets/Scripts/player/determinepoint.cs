using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class determinepoint : MonoBehaviour
{
    public float angle;
    public AudioSource deadaud;
    
    void Update()
    {
        transform.Rotate(0, 0, angle * Time.deltaTime);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if(motion.playerstate == motion.PlayerState.general)
        {
            motion.instance.behit_time = Time.time;
            motion.playerstate = motion.PlayerState.behit;
            deadaud.Play();
        }
    }
}
