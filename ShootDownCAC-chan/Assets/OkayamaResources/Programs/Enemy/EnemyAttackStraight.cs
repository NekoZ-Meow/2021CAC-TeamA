using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttackStraight : EnemyAttack
{
    [SerializeField] float bulletSpeed = 3f;
    [SerializeField] float damage = 1f;

    private Bullet bullet;

    /// <summary>
    /// 直線上に弾を発射する
    /// </summary>
    /// <returns></returns>
    public override IEnumerator Attack()
    {
        this.bullet = Bullets.GetNormalBullet(damage: 1, speed: 8);
        Shooting normalShooting = new NormalShooting(this.gameObject, this.bullet);

        while (true)
        {
            normalShooting.Shoot();
            yield return new WaitForSeconds(0.5f);
        }
    }

    void onDestory()
    {
        Object.Destroy(this.bullet);
    }
}
