using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class eblist : MonoBehaviour
{
    public static eblist instance;
    public List<ncebulletlife> ncebullet = new List<ncebulletlife>();
    public List<blifeTemplate> cebullet = new List<blifeTemplate>();
    public int ncindex = 0;
    public int cindex = 0;

    void Awake()
    {
        instance = this;
    }
}
