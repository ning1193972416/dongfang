using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class framemanager : MonoBehaviour
{
    public static int framescale;

    // Update is called once per frame
    void Update()
    {
        framescale = (int)Time.timeScale;
    }
}
