using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class generalbullet : MonoBehaviour
{
    public SpriteRenderer bullet;
    public Collider2D col;
    public Animator ani;

    void Start()
    {
        ani = GetComponent<Animator>();
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        //碰撞检测
        if (bossbehaviour.instance.cardnum % 2 == 0)
        {
            bossbehaviour.instance.lifeval -= 5 * Time.deltaTime;
        }
        else if (bossbehaviour.instance.cardnum % 2 == 1)
        {
            bossbehaviour.instance.lifeval -= 1 * Time.deltaTime;
        }
        col.enabled = false;
        ani.Play("destroygeneralb");
    }

    void endrender()
    {
        bullet.enabled = false;
    }
}
