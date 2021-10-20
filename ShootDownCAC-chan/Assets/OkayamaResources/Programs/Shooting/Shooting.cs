using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public abstract class Shooting
{
    protected Bullet bullet; //発射する弾丸

    protected GameObject shooter; //射手

    protected AudioSource audioSource = null;

    public Shooting(GameObject shooter, Bullet bullet)
    {
        this.bullet = bullet;
        this.shooter = shooter;
        this.audioSource = this.shooter.GetComponent<AudioSource>();
        this.bullet.ShooterTag = shooter.tag;

        return;
    }

    /// <summary>
    /// 弾丸を発射する
    /// </summary>
    public abstract void Shoot();

    /// <summary>
    /// 発射音を再生する
    /// </summary>
    public virtual void PlaySound(float volume = 1)
    {
        if (this.audioSource != null && this.bullet.Sound != null)
        {
            this.audioSource.PlayOneShot(this.bullet.Sound, volume);
        }
        return;
    }

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
                if (this.bullet != null)
                {
                    Bullet oldBullet = this.bullet;
                    this.bullet = value;
                    Object.Destroy(oldBullet);
                }
                else
                {
                    this.bullet = value;
                }
            }
        }

    }

}
