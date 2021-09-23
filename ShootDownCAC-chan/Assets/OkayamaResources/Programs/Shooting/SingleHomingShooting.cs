using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 敵単体に対して誘導する射撃システム
/// </summary>
public class SingleHomingShooting : Shooting
{
    private HomingBullet homingBullet;
    private GameObject target;
    private string targetTag;
    public SingleHomingShooting(GameObject shooter, HomingBullet bullet, string targetTag) : base(shooter, bullet)
    {
        this.homingBullet = bullet;
        this.targetTag = targetTag;
        return;
    }

    public override void Shoot()
    {
        HomingBullet bullet = Object.Instantiate<HomingBullet>(this.homingBullet, base.shooter.transform.position, shooter.transform.rotation);
        this.target = GameObjectUtility.FindNearlyGameObjectWithTag(this.shooter, this.targetTag);
        bullet.Target = this.target;
        bullet.enabled = true;

        return;
    }

}
