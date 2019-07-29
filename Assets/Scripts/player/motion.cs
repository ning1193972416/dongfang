using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class motion : MonoBehaviour
{
    public static motion instance;

    public Animator animator;
    private Vector2 BeganPos;
    private int leftsign;
    public Transform player;
    public boom boomins;
    public AudioSource boomaud;
    public RectTransform rightrect;

    //被击中的时间
    public float behit_time;
    //被击中时的位置
    public Vector3 behit_pos;
    public enum PlayerState
    {
        general = 0,
        behit = 1,
        boominvincible = 2,
        dead = 3,
        invincible = 4
    }
    public static PlayerState playerstate = PlayerState.general;

    void Awake()
    {
        instance = this;
        player = transform;
    }
    void Start()
    {
        BeganPos = Vector2.zero;
        leftsign = -1;
    }
    void Update()
    {
        if (playerstate == PlayerState.general)
            move();
        else if(playerstate == PlayerState.behit)
        {
            if (Time.time <= behit_time + 0.3)
            {
                for (int i = 0; i < Input.touches.Length; i++)
                {
                    if (righthand(Input.touches[i].position) && Input.GetTouch(i).phase == TouchPhase.Began)
                        trigboom();
                }
            }
            else
            {
                behit_pos = transform.position;
                reset();
                playerstate = PlayerState.dead;
                if (uimanager.pllifenum == 0)
                    uimanager.entergameover = true;
                else
                {
                    uimanager.pllifenum--;
                    uimanager.plboomnum = 3;
                }
            }
        }
        else if(playerstate == PlayerState.boominvincible)
        {
            move();
            if (boomins.booming == false)
                playerstate = PlayerState.general;
        }
        else if (playerstate == PlayerState.dead)
        {
            transform.Translate(new Vector2(0, 2 * Time.deltaTime));
            if (Time.time >= behit_time + 1.8)
            {
                playerstate = PlayerState.invincible;
            }
        }
        else if (playerstate == PlayerState.invincible)
        {
            move();
            if (Time.time >= behit_time + 3.3)
                playerstate = PlayerState.general;
        }
    }
    void move()
    {
        for (int i = 0; i < Input.touches.Length; i++)
        {
            Touch a = Input.touches[i];
            if (lefthand(a.position) && a.phase == TouchPhase.Began)                    //左手触控
            {
                BeganPos = a.position;
                leftsign = a.fingerId;
            }
            if (righthand(a.position) && a.phase == TouchPhase.Began)                    //右手触控
            {
                trigboom();
            }
            if (a.fingerId == leftsign)
            {
                Vector2 move = a.position - BeganPos;
                if (move != Vector2.zero)
                {
                    Vector2 direction = move.normalized;
                    float distance = move.SqrMagnitude();
                    if (transform.position.x < -4.2)
                    {
                        if (direction.x < 0)
                            direction.x = 0;
                    }
                    else if (transform.position.x > 4.2)
                        if (direction.x > 0)
                            direction.x = 0;
                    if (transform.position.y < -5)
                    {
                        if (direction.y < 0)
                            direction.y = 0;
                    }
                    else if (transform.position.y > 5)
                        if (direction.y > 0)
                            direction.y = 0;
                    if (distance > 1600 && distance < 10000)
                        transform.Translate(direction * 4 * Time.deltaTime);
                    else if (distance >= 10000)
                        transform.Translate(direction * 8 * Time.deltaTime);
                }
                if (a.phase == TouchPhase.Ended)
                {
                    BeganPos = Vector2.zero;
                    leftsign = -1;
                }
                if (move.x < 0)
                    animator.SetInteger("direction", -1);
                else if (move.x > 0)
                    animator.SetInteger("direction", 1);
                else
                    animator.SetInteger("direction", 0);
            }
        }
        if (leftsign == -1)
            animator.SetInteger("direction", 0);
    }

    void trigboom()
    {
        if (boomins.booming == false)
        {
            if (uimanager.plboomnum > 0)
            {
                boomaud.Play();
                playerstate = PlayerState.boominvincible;
                boomins.enterboom = true;
                boomins.booming = true;
                uimanager.plboomnum--;
            }
        }
    }

    bool lefthand(Vector2 position)
    {
        if (position.x < 400)
            return true;
        else
            return false;
    }

    bool righthand(Vector2 position)
    {
        if (position.x >= rightrect.anchoredPosition.x && position.x <= rightrect.anchoredPosition.x + rightrect.sizeDelta.x &&
            position.y >= rightrect.anchoredPosition.y && position.y <= rightrect.anchoredPosition.y + rightrect.sizeDelta.y)
            return true;
        else
            return false;
    }

    void reset()
    {
        transform.position = new Vector2(0, -6);
    }
}
