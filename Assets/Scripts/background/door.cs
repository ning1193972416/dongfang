using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class door : MonoBehaviour
{
    public Transform maindoor;
    public Vector3 offset;
    public float angle;
    float time;
    void Start()
    {
        time = Time.time;
    }
    void Update()
    {
        if(Time.time>=time+3)
        {
            angle = -angle;
            time = Time.time;
        }
        transform.RotateAround(maindoor.position + offset, Vector3.up, angle * Time.deltaTime);
    }
}
