using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Shooting
{
    protected Bullet bullet; //発射する弾丸

    protected GameObject shooter; //射手

    public Shooting(GameObject shooter, Bullet bullet)
    {
        this.bullet = bullet;
        this.shooter = shooter;

        return;
    }

    /// <summary>
    /// 弾丸を発射する
    /// </summary>
    public abstract void Shoot();

    /// <summary>
    /// 発射する弾丸
    /// </summary>
    /// <value>弾丸のオブジェクト</value>
    public Bullet Bullet
    {
        get { return this.bullet; }
        set
        {
            if (value.GetComponent<Bullet>())
            {
                this.bullet = value;
            }
        }

    }


}
