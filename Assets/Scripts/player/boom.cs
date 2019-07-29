using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class boom : MonoBehaviour
{
    public Transform player;
    public SpriteRenderer sp1;
    public SpriteRenderer sp2;

    float time;

    [HideInInspector]
    public bool enterboom = false;
    [HideInInspector]
    public bool booming = false;

    // Update is called once per frame
    void Update()
    {
        if(enterboom)
        {
            transform.position = player.position;
            time = Time.time;
            sp1.enabled = true;
            sp2.enabled = true;
            sp1.GetComponent<rotate>().enabled = true;
            sp2.GetComponent<rotate>().enabled = true;
            enterboom = false;
        }
        if (booming)
        {
            if (Time.time <= time + 1)
                transform.localScale += new Vector3(4, 4, 4) * Time.deltaTime;
            else if (Time.time >= time + 3 && Time.time < time + 5)
            {
                sp1.color -= new Color(0, 0, 0, 0.5f * Time.deltaTime);
                sp2.color -= new Color(0, 0, 0, 0.5f * Time.deltaTime);
            }
            else if (Time.time >= time + 5)
            {
                transform.localScale = new Vector3(0, 0, 0);
                sp1.color = Color.white;
                sp2.color = Color.white;
                sp1.enabled = false;
                sp2.enabled = false;
                sp1.GetComponent<rotate>().enabled = false;
                sp2.GetComponent<rotate>().enabled = false;
                booming = false;
            }
        }
    }

    void OnTriggerStay2D(Collider2D other)
    {
        if (bossbehaviour.instance.cardnum % 2 == 0)
            bossbehaviour.instance.lifeval -= 10 * Time.deltaTime;
        else
            bossbehaviour.instance.lifeval -= 2 * Time.deltaTime;
    }
}
