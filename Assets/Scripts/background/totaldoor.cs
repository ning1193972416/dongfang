using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class totaldoor : MonoBehaviour
{
    public Transform camera1;
    public SpriteRenderer sp1;
    public SpriteRenderer sp2;
    public SpriteRenderer sp3;
    Color c1;
    Color c2;
    Color c3;

    void Start()
    {
        c1 = sp1.color;
        c2 = sp2.color;
        c3 = sp3.color;
    }
    void Update()
    {
        if (transform.position.z < -16)
            transform.Translate(0, 0, 30);
        else
            transform.Translate(0, 0, -6 * Time.deltaTime);
        float bright = 1 - (transform.position - camera1.position).magnitude / 20;
        sp1.color = c1 * bright;
        sp2.color = c2 * bright;
        sp3.color = c3 * bright;
    }
}
