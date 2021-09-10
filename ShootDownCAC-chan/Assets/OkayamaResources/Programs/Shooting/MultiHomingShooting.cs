using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Threading.Tasks;

/// <summary>
/// 複数の敵に対して誘導する射撃システム
/// </summary>
public class MultiHomingShooting : Shooting
{
    private HomingBullet homingBullet;
    private string targetTag;
    private int targetNumber;
    private float maxDegree;
    private float waitTime;
    public MultiHomingShooting(GameObject shooter, HomingBullet bullet, string targetTag, int targetNumber = 1, float maxDegree = 60, float waitTime = 0.15f, float maxDistance = -1) : base(shooter, bullet)
    {
        this.homingBullet = bullet;
        this.targetTag = targetTag;
        this.targetNumber = targetNumber;
        this.maxDegree = maxDegree;
        this.waitTime = waitTime;
        return;
    }

    public override void Shoot()
    {
        List<Bullet> bullets = new List<Bullet>();
        List<GameObject> enemies = GameObjectUtility.FindNearlyNGameObjectsWithTag(this.shooter, this.targetTag, this.targetNumber);
        enemies.ForEach((aGameObject) =>
        {
            HomingBullet bullet = Object.Instantiate<HomingBullet>(this.homingBullet, base.shooter.transform.position, shooter.transform.rotation);
            bullet.Target = aGameObject;
            bullet.WaitHomingTime = this.waitTime;
            bullets.Add(bullet);
            bullet.enabled = true;
        });

        float degree = this.maxDegree * 2 / bullets.Count;
        for (int i = 0; i < bullets.Count / 2; i += 2)
        {
            bullets[i].MoveDirection += degree;
            bullets[i + 1].MoveDirection -= degree;
        }

        return;
    }
}
