using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class floorroll : MonoBehaviour
{
    // Update is called once per frame
    void Update()
    {
        if (transform.position.z < -16)
            transform.Translate(0, 0, 30);
        else
            transform.Translate(0, 0, -6 * Time.deltaTime);
    }
}
