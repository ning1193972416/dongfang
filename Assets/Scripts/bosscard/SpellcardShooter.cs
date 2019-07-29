using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpellcardShooter : MonoBehaviour
{
    [HideInInspector]
    public static SpellcardShooter instance;

    void Awake()
    {
        instance = this;
    }

    public void shootnscard0(float angle,ref Vector3 rotate,Vector3 localdirect,Transform shootertrans)
    {
        rotate = rotate + new Vector3(0, 0, angle);
        if (rotate.z >= 360)
            rotate.z -= 360;
        else if (rotate.z <= -360)
            rotate.z += 360;
        for (int i = 0; i < 5; i++, eblist.instance.ncindex++)
        {
            if (eblist.instance.ncindex >= eblist.instance.ncebullet.Count)
                eblist.instance.ncindex = 0;
            eblist.instance.ncebullet[eblist.instance.ncindex].direct = localdirect;
            eblist.instance.ncebullet[eblist.instance.ncindex].transform.position = shootertrans.position;
            eblist.instance.ncebullet[eblist.instance.ncindex].transform.eulerAngles = rotate;
            eblist.instance.ncebullet[eblist.instance.ncindex].sprite.enabled = true;
            eblist.instance.ncebullet[eblist.instance.ncindex].col.enabled = true;
            eblist.instance.ncebullet[eblist.instance.ncindex].ani.Play("pink");
            localdirect *= 1.1f;
        }
    }

    public void shootscard1(float angle, ref Vector3 rotate, Vector3 localdirect, Transform shootertrans)
    {
        rotate = rotate + new Vector3(0, 0, angle);
        if (rotate.z >= 360)
            rotate.z -= 360;
        else if (rotate.z <= -360)
            rotate.z += 360;
        for (int i = 0; i < 3; i++, eblist.instance.cindex++)
        {
            if (eblist.instance.cindex >= eblist.instance.cebullet.Count)
                eblist.instance.cindex = 0;
            eblist.instance.cebullet[eblist.instance.cindex].GetComponent<card1bulletlife>().direct = localdirect;
            eblist.instance.cebullet[eblist.instance.cindex].transform.position = shootertrans.position;
            eblist.instance.cebullet[eblist.instance.cindex].transform.eulerAngles = rotate;
            eblist.instance.cebullet[eblist.instance.cindex].sprite.enabled = true;
            eblist.instance.cebullet[eblist.instance.cindex].col.enabled = true;
            eblist.instance.cebullet[eblist.instance.cindex].ani.Play("purple");
            localdirect *= 1.1f;
        }
    }

    public void shootnscard4(float angle, ref Vector3 rotate, Vector3 localdirect, Transform shootertrans)
    {
        rotate = rotate + new Vector3(0, 0, angle);
        Vector3 rotate2 = rotate + new Vector3(0, 0, 180);
        float initdirecty = localdirect.y;
        if (rotate.z >= 360)
            rotate.z -= 360;
        else if (rotate.z <= -360)
            rotate.z += 360;
        for (int i = 0; i < 3; i++, eblist.instance.ncindex++)
        {
            if (eblist.instance.ncindex >= eblist.instance.ncebullet.Count)
                eblist.instance.ncindex = 0;
            eblist.instance.ncebullet[eblist.instance.ncindex].direct = localdirect;
            eblist.instance.ncebullet[eblist.instance.ncindex].transform.position = shootertrans.position;
            eblist.instance.ncebullet[eblist.instance.ncindex].transform.eulerAngles = rotate;
            eblist.instance.ncebullet[eblist.instance.ncindex].sprite.enabled = true;
            eblist.instance.ncebullet[eblist.instance.ncindex].col.enabled = true;
            localdirect *= 1.1f;
        }
        localdirect.y = initdirecty;
        for (int i = 0; i < 3; i++, eblist.instance.ncindex++)
        {
            if (eblist.instance.ncindex >= eblist.instance.ncebullet.Count)
                eblist.instance.ncindex = 0;
            eblist.instance.ncebullet[eblist.instance.ncindex].direct = localdirect;
            eblist.instance.ncebullet[eblist.instance.ncindex].transform.position = shootertrans.position;
            eblist.instance.ncebullet[eblist.instance.ncindex].transform.eulerAngles = rotate2;
            eblist.instance.ncebullet[eblist.instance.ncindex].sprite.enabled = true;
            eblist.instance.ncebullet[eblist.instance.ncindex].col.enabled = true;
            localdirect *= 1.1f;
        }
    }
}
