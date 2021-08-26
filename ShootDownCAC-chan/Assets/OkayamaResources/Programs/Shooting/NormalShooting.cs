using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NormalShooting : Shooting
{

    public NormalShooting(GameObject player, GameObject bullet)
    {
        if (!bullet.GetComponent<Bullet>())
        {
            throw new MissingComponentException();
        }
        base.player = player;
        base.Bullet = bullet;

        return;
    }

    public override void Shot()
    {
        Object.Instantiate(base.bullet, player.transform.position, Quaternion.identity);

        return;
    }


}
