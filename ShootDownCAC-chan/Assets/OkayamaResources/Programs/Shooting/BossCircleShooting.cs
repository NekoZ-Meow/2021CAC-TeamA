using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossCircleShooting : Shooting
{
    private float circleAttackDegree = 0;
    public BossCircleShooting(GameObject shooter, Bullet bullet, float circleAttackDegree) : base(shooter, bullet)
    {
        this.circleAttackDegree = circleAttackDegree;
        return;
    }

    public override void Shoot()
    {

    }
}
