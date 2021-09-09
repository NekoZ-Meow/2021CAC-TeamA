using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CircleShooting : Shooting
{
    public CircleShooting(GameObject shooter, Bullet bullet) : base(shooter, bullet)
    {
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
