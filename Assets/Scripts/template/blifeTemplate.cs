using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class blifeTemplate : MonoBehaviour
{
    public SpriteRenderer sprite;
    public Collider2D col;
    public Animator ani;
    [HideInInspector]
    public Vector2 direct;

    public virtual void Start()
    {
        ani = GetComponent<Animator>();
    }

    void Update()
    {
        if (transform.position.x > -4.5 && transform.position.x < 4.5 && transform.position.y > -6 && transform.position.y < 6)
        {
            if (col.enabled)
                transform.Translate(direct * Time.deltaTime);
        }
        else
        {
            setnotactive();
        }
    }

    public void setnotactive()
    {
        sprite.enabled = false;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        ani.Play("deleffect");
        audiomanager.instance.grazeaud.Play();
        col.enabled = false;
    }
}
