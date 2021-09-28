using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class NormalShooting : Shooting
{

    public NormalShooting(GameObject shooter, Bullet bullet) : base(shooter, bullet)
    {
        return;
    }

    public override void Shoot()
    {
        if (this.bullet == null) return;
        Bullet bullet = Object.Instantiate<Bullet>(base.bullet, base.shooter.transform.position, shooter.transform.rotation);
        bullet.enabled = true;

        return;
    }


}
