using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyjudge : MonoBehaviour
{
    isenemyexist ex;
    public static GameObject enemy;

    void Start()
    {
        ex = isenemyexist.instance;
    }
    // Update is called once per frame
    void Update()
    {
        GameObject target = GameObject.FindGameObjectWithTag("enemy");
        if (target == null)
            ex.exist = false;
        else
        {
            ex.exist = true;
            enemy = target;
        }
    }
}
