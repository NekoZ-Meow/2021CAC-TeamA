using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TwowayShooting : Shooting
{
    public TwowayShooting(GameObject shooter, Bullet bullet) : base(shooter, bullet)
    {
        return;
    }

    public override void Shoot()
    {
        this.Bullet.GetComponent<Bullet>().MoveDirection = 225;
        Object.Instantiate(base.bullet, base.shooter.transform.position, Quaternion.identity);
        this.Bullet.GetComponent<Bullet>().MoveDirection = 315;
        Object.Instantiate(base.bullet, base.shooter.transform.position, Quaternion.identity);
        bullet.enabled = true;

        return;
    }

}
