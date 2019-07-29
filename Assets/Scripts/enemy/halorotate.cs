using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class halorotate : MonoBehaviour
{
    void Update()
    {
        transform.Rotate(45 * Time.deltaTime, 45 * Time.deltaTime, 90*Time.deltaTime);
    }
}
