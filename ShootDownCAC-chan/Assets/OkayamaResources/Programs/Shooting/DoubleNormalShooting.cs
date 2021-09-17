using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoubleNormalShooting : Shooting
{

    public DoubleNormalShooting(GameObject shooter, Bullet bullet) : base(shooter, bullet)
    {
        return;
    }

    public override void Shoot()
    {
        Bullet bullet = Object.Instantiate<Bullet>(base.bullet, base.shooter.transform.position, shooter.transform.rotation);
        bullet.transform.position += new Vector3(0.2f, 0, 0);
        bullet.enabled = true;
        bullet = Object.Instantiate<Bullet>(base.bullet, base.shooter.transform.position, shooter.transform.rotation);
        bullet.transform.position -= new Vector3(0.2f, 0, 0);
        this.PlaySound();
        bullet.enabled = true;
        return;
    }

}
