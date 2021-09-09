using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CircleShooting : Shooting
{
    public CircleShooting(GameObject shooter, GameObject bullet)
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
        for(int i = 0;i < 360; i += 15)
        {
            this.Bullet.GetComponent<Bullet>().MoveDirection = i;
            Object.Instantiate(base.bullet, base.shooter.transform.position, Quaternion.identity);
        }

        return;
    }
}
