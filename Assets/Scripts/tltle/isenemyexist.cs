using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class isenemyexist : MonoBehaviour
{
    public bool exist = false;
    public static isenemyexist instance;
    void Awake()
    {
        instance = this;
    }
}
