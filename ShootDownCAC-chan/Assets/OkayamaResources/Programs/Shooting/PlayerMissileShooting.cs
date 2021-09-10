using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Threading.Tasks;

public class PlayerMissileShooting : Shooting
{
    private HomingBullet homingBullet;
    private string targetTag;
    private int targetNumber;
    private float waitTime;

    private float maxDistance;

    private float shooterWidth;
    public PlayerMissileShooting(GameObject shooter, HomingBullet bullet, string targetTag, int targetNumber = 1, float waitTime = 0.15f, float maxDistance = -1) : base(shooter, bullet)
    {
        this.homingBullet = bullet;
        this.targetTag = targetTag;
        this.targetNumber = targetNumber;
        this.waitTime = waitTime;
        this.maxDistance = maxDistance;
        this.shooterWidth = shooter.GetComponent<SpriteRenderer>().bounds.size.x;
        return;
    }

    public async override void Shoot()
    {
        List<Bullet> bullets = new List<Bullet>();
        List<GameObject> enemies = GameObjectUtility.FindNearlyNGameObjectsWithTag(this.shooter, this.targetTag, this.targetNumber, this.maxDistance);
        float offset = this.shooterWidth / 2.5f;
        foreach (GameObject aGameObject in enemies)
        {
            HomingBullet bullet = Object.Instantiate<HomingBullet>(this.homingBullet, base.shooter.transform.position + new Vector3(offset, 0, 0), shooter.transform.rotation);
            bullet.Target = aGameObject;
            bullet.WaitHomingTime = this.waitTime;
            bullets.Add(bullet);
            offset *= -1;
            this.PlaySound(0.3f);
            bullet.enabled = true;
            await Task.Delay(80);
        }
        return;
    }

}
