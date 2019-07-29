using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rotate : MonoBehaviour
{
    public float rotateangle;
    void Update()
    {
        transform.Rotate(0, 0, rotateangle * Time.deltaTime);
    }
}
