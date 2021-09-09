using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThreewayShooting : Shooting
{
    public ThreewayShooting(GameObject shooter, GameObject bullet)
    {
        if (!bullet.GetComponent<Bullet>())
        {
            throw new MissingComponentException();
        }
        base.shooter = shooter;
        base.Bullet = bullet;

        return;
    }

    public override void Shoot()
    {
        this.Bullet.GetComponent<Bullet>().MoveDirection = 225;
        Object.Instantiate(base.bullet, base.shooter.transform.position, Quaternion.identity);
        this.Bullet.GetComponent<Bullet>().MoveDirection = 270;
        Object.Instantiate(base.bullet, base.shooter.transform.position, Quaternion.identity);
        this.Bullet.GetComponent<Bullet>().MoveDirection = 315;
        Object.Instantiate(base.bullet, base.shooter.transform.position, Quaternion.identity);

        return;
    }
}
