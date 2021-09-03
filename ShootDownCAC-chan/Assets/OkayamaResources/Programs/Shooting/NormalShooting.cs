using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NormalShooting : Shooting
{

    public NormalShooting(GameObject shooter, GameObject bullet)
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
        Object.Instantiate(base.bullet, base.shooter.transform.position, Quaternion.identity);

        return;
    }


}
