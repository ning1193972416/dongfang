using UnityEngine;
using UnityEngine.UI;

public class bossbehaviour : MonoBehaviour
{
    delegate void execute();

    public static bossbehaviour instance;

    public RectTransform lifet;
    public Image life;
    public AudioSource aud;
    public Transform face;
    public GameObject cardground;
    public nsshooter nsshooter1;
    public nsshooter nsshooter2;

    public float lifeval = 100;                        //生命值
    public int cardnum = 0;                            //符卡序号
    int nextcardnum;
    int stateframe = 0;                                //状态帧(从进入一个符卡开始从0递增）
    bool DisplayfaceOrNot = false;                     //是否展示立绘
    float movetime;
    Vector2 bossdirect=new Vector2(5,5);
    bool locklifeornot = false;
    float lockedlifeval = 0;

    int audiodelay = 0;
    int audframe = 0;
    int shootframe = 0;
    int shootdelay = 3;
    float angle1;
    float angle2;
    Vector3 rotate1;
    Vector3 rotate2;
    Vector3 localdirect = new Vector3(0, 5);

    void Awake()
    {
        instance = this;
        movetime = Time.time;
    }
    void Update()
    {
        life.fillAmount = lifeval / 100;

        if (locklifeornot)
            locklifeval();
        bossmove();
        Vector2 screen_xy = Camera.main.WorldToScreenPoint(transform.position);
        lifet.anchoredPosition = screen_xy;

        displayface();

        if(cardnum==-1)                                           //符卡击破僵直状态
        { }
        else if (cardnum == 0)
        {
            ExecuteAndNextState(20, false,
                stay: new execute(nsshooter1.launchnc0) + new execute(nsshooter2.launchnc0),
                exit: entercardground);
        }
        else if (cardnum == 1)
        {
            ExecuteAndNextState(0, true,
                enter: new execute(entercard1),
                stay: new execute(executecard1),
                exit: exitcardground);
        }
        else if (cardnum == 2)
        {
            ExecuteAndNextState(20, false,
                enter: new execute(lifefull),
                stay: new execute(nsshooter1.launchnc0) + new execute(nsshooter2.launchnc0),
                exit: entercardground);
        }
        else if (cardnum == 3)
        {
            ExecuteAndNextState(0, true,
                stay: new execute(nsshooter1.launchnc0) + new execute(nsshooter2.launchnc0),
                exit: exitcardground);
        }
        else if (cardnum == 4)
        {
            ExecuteAndNextState(20, false,
                enter: new execute(entercard4) + new execute(lifefull),
                stay: new execute(executecard4),
                exit: entercardground);
        }
        else if (cardnum == 5)
        {
            ExecuteAndNextState(0, true,
                enter: new execute(entercard4),
                stay: new execute(executecard4),
                exit: exitcardground);
        }
    }

    void ExecuteAndNextState(float require_lessthanval, bool cardornot,
        execute enter = null,
        execute stay = null,
        execute exit = null)
    {
        if (stateframe == 0)
        {
            if (enter != null)
                enter();                                  //第一帧执行
        }

        if (stay != null)
            stay();                                       //日常执行

        if (lifeval<=require_lessthanval)
        {
            if (exit != null)
                exit();                                   //最后一帧执行
            if (!cardornot)                               //击破非符
                cardnum++;
            else                                          //击破符卡
            {
                nextcardnum = cardnum + 1;
                cardnum = -1;
                Invoke("nextcard", 2);
            }
            stateframe = 0;
        }
        else
            stateframe++;
    }

    void displayface()
    {
        if(DisplayfaceOrNot)
        {
            if (face.position.y <= -1)
                face.Translate(0, 20 * Time.deltaTime, 0);
            else if (face.position.y <= 1)
                face.Translate(0, 2 * Time.deltaTime, 0);
            else if (face.position.y <= 9)
                face.Translate(0, 20 * Time.deltaTime, 0);
            else
            {
                face.position = new Vector2(0, -9);
                face.GetComponent<SpriteRenderer>().enabled = false;
                DisplayfaceOrNot = false;
            }
        }
    }

    void entercardground()
    {
        face.GetComponent<SpriteRenderer>().enabled = true;
        DisplayfaceOrNot = true;
        cardground.SetActive(true);
        locklifeornot = true;
        lockedlifeval = lifeval;
        Invoke("unlocklife", 3);
    }

    void exitcardground()
    {
        cardground.SetActive(false);
    }

    void bossmove()
    {
        if (Time.time >= movetime + 3 && Time.time < movetime + 4.5)
        {
            transform.Translate(bossdirect * Time.deltaTime);
            bossdirect = bossdirect * 0.8f;
        }
        else if (Time.time >= movetime + 4.5)
        {
            movetime = Time.time;
            int i = Random.Range(0, 3);
            if (i == 0)
                bossdirect = new Vector2(-5, 5);
            else if (i == 1)
                bossdirect = new Vector2(-5, -5);
            else if (i == 2)
                bossdirect = new Vector2(5, -5);
            else if (i == 3)
                bossdirect = new Vector2(5, 5);
        }
    }
    
    void locklifeval()
    {
        lifeval = lockedlifeval;
    }

    void unlocklife()
    {
        locklifeornot = false;
    }

    void lifefull()
    {
        lifeval = 100;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        uimanager.score += 3000;

        //音频播放
        if (audframe == audiodelay)
        {
            audframe = 0;
            aud.Play();
        }
        else
            audframe++;
    }

    void entercard1()
    {
        angle1 = 7;
        rotate1 = new Vector3(0, 0, -120);
    }
    void executecard1()
    {
        shootframe += framemanager.framescale;
        if (shootframe == shootdelay)
        {
            shootframe = 0;
            SpellcardShooter.instance.shootscard1(angle1, ref rotate1, localdirect, transform);
        }
    }

    void entercard4()
    {
        angle1 = 9;
        rotate1 = new Vector3(0, 0, -120);
        angle2 = -7;
        rotate2 = new Vector3(0, 0, -30);
    }
    void executecard4()
    {
        shootframe += framemanager.framescale;
        if (shootframe == shootdelay)
        {
            shootframe = 0;
            SpellcardShooter.instance.shootnscard4(angle1, ref rotate1, localdirect, transform);
            SpellcardShooter.instance.shootnscard4(angle2, ref rotate2, localdirect, transform);
        }
    }

    void cardnumplus()
    {
        cardnum++;
    }

    void nextcard()
    {
        cardnum = nextcardnum;
    }
}