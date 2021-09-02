using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullets : MonoBehaviour
{


    public static GameObject GetNormalBullet()
    {
        return Resources.Load<GameObject>("Bullet/NormalBullet");
    }

    public static GameObject GetHomingBullet()
    {
        return Resources.Load<GameObject>("Bullet/HomingBullet");
    }
}
