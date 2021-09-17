using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThreewayShooting : Shooting
{
    public ThreewayShooting(GameObject shooter, Bullet bullet) : base(shooter, bullet)
    {
        return;
    }

    public override void Shoot()
    {
        Bullet bullet = Object.Instantiate(base.bullet, base.shooter.transform.position, shooter.transform.rotation);
        bullet.MoveDirection -= 45;
        bullet.enabled = true;
        bullet = Object.Instantiate(base.bullet, base.shooter.transform.position, shooter.transform.rotation);
        bullet.enabled = true;
        bullet = Object.Instantiate(base.bullet, base.shooter.transform.position, shooter.transform.rotation);
        bullet.MoveDirection += 45;
        bullet.enabled = true;

        return;
    }
}
