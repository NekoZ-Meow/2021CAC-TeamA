using System.Collections;
using System.Collections.Generic;
using System.Collections.Concurrent;
using UnityEngine;

public class Bullets : MonoBehaviour
{
    private static readonly Vector2 outOfScreen = new Vector2(10000, 10000);
    private static ConcurrentDictionary<Bullet, ConcurrentQueue<Bullet>> bulletPool = new ConcurrentDictionary<Bullet, ConcurrentQueue<Bullet>>();
    private static readonly NormalBullet normalBullet = Resources.Load<NormalBullet>("Bullet/NormalBullet");
    private static readonly NormalBullet enemyBullet = Resources.Load<NormalBullet>("Bullet/EnemyBullet1");
    private static readonly HomingBullet homingBullet = Resources.Load<HomingBullet>("Bullet/HomingBullet");

    private static readonly HomingBullet missile = Resources.Load<HomingBullet>("Bullet/Missile");


    public static NormalBullet GetNormalBullet(float damage = 10, float speed = 15, float timeToLive = 0)
    {
        NormalBullet bullet = Instantiate<NormalBullet>(Bullets.normalBullet, outOfScreen, Quaternion.identity);
        bullet.Damage = damage;
        bullet.MoveSpeed = speed;
        bullet.TimeToLive = timeToLive;
        bullet.enabled = false;
        return bullet;
    }
    public static HomingBullet GetHomingBullet(float damage = 10, float speed = 15, float timeToLive = 0, float homingDegree = 5)
    {
        HomingBullet bullet = Instantiate<HomingBullet>(Bullets.homingBullet, outOfScreen, Quaternion.identity);
        bullet.Damage = damage;
        bullet.MoveSpeed = speed;
        bullet.TimeToLive = timeToLive;
        bullet.HomingDegree = homingDegree;
        bullet.enabled = false;
        return bullet;
    }

    public static HomingBullet GetMissile(float damage = 50, float speed = 15, float timeToLive = 0, float homingDegree = 5)
    {
        HomingBullet bullet = Instantiate<HomingBullet>(Bullets.missile, outOfScreen, Quaternion.identity);
        bullet.Damage = damage;
        bullet.MoveSpeed = speed;
        bullet.TimeToLive = timeToLive;
        bullet.HomingDegree = homingDegree;
        bullet.enabled = false;
        return bullet;
    }

    public static NormalBullet GetNormalEnemyBullet(float damage = 1, float speed = 7, float timeToLive = 0)
    {
        NormalBullet bullet = Instantiate<NormalBullet>(Bullets.enemyBullet, outOfScreen, Quaternion.identity);
        bullet.Damage = damage;
        bullet.MoveSpeed = speed;
        bullet.TimeToLive = timeToLive;
        bullet.enabled = false;
        return bullet;
    }
}
