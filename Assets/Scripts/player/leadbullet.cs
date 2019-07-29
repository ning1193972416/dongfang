using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class leadbullet : MonoBehaviour
{
    public SpriteRenderer bullet;
    public Transform ball;
    public Collider2D col;
    public Animator ani;
    public Vector3 initrotato;
    isenemyexist ex;
    int hitgoalstate = 0;                                  //0正常飞行，1减速，2停止
    Vector3 initmovedirect = new Vector3(9, 0, 0);
    Vector3 hitmovedirect;

    void Start()
    {
        ani = GetComponent<Animator>();
        ex = isenemyexist.instance;
    }

    void Update()
    {
        if (transform.position.y < 10)
        {
            if (hitgoalstate == 0)
            {
                transform.Translate(initmovedirect * Time.deltaTime);
                if (ex.exist)
                {
                    Vector3 vec = enemyjudge.enemy.transform.position - transform.position;
                    Vector3 selfdirect = transform.TransformDirection(1, 0, 0);

                    //获取两个向量间的夹角(带正负符号)
                    float angledeg = Vector3.Angle(selfdirect, vec);
                    float anglepersdeg;
                    if (angledeg <= 60)
                    {
                        anglepersdeg = initmovedirect.x * 2 * Mathf.Cos((90 - angledeg) * Mathf.Deg2Rad) / vec.magnitude * Mathf.Rad2Deg;
                        if (Vector3.Cross(selfdirect, vec).z > 0)
                            transform.Rotate(0, 0, anglepersdeg * Time.deltaTime);
                        else if (Vector3.Cross(selfdirect, vec).z < 0)
                            transform.Rotate(0, 0, -anglepersdeg * Time.deltaTime);
                    }
                    else
                    {
                        if (Vector3.Cross(selfdirect, vec).z > 0)
                            transform.Rotate(0, 0, 360 * Time.deltaTime);
                        else if (Vector3.Cross(selfdirect, vec).z < 0)
                            transform.Rotate(0, 0, -360 * Time.deltaTime);
                    }
                }
            }
            else if (hitgoalstate == 1)
            {
                hitmovedirect -= hitmovedirect * 4 * Time.deltaTime;
                transform.Translate(hitmovedirect * Time.deltaTime);
            }
        }
        else
        {
            bullet.enabled = false;
            col.enabled = false;
        }
    }

    public void setactive()
    {
        transform.position = ball.position;
        transform.eulerAngles = initrotato;
        bullet.enabled = true;
        col.enabled = true;
        hitgoalstate = 0;
        ani.Play("New State");
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
        ani.Play("destroyleadb");
        hitgoalstate = 1;
        hitmovedirect = initmovedirect;
    }

    void endrender()
    {
        bullet.enabled = false;  
    }
    
    void endmove()
    {
        hitgoalstate = 2;
    }
}
