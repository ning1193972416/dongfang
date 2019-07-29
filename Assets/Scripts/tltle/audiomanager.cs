using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class audiomanager : MonoBehaviour
{
    public static audiomanager instance;
    public AudioSource grazeaud;

    void Awake()
    {
        instance = this;
    }
}
