using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossAttack : EnemyAttack
{
    [SerializeField] float circleAttackDegree = 8f;
    [SerializeField] float circleBulletSpeed = 1f;
    [SerializeField] float attackInterval = 5f;
    private Bullet enemyBullet;
    private EnemyModel model;

    // Start is called before the first frame update
    void Start()
    {
        this.enemyBullet = Bullets.GetCircleEnemyBullet(1, this.circleBulletSpeed);
        this.model = this.GetComponent<EnemyModel>();
    }

    public IEnumerator StraightAttack()
    {

        yield return null;
    }

    public IEnumerator CircleAttack()
    {
        for (float degree = 0; degree < 360; degree += this.circleAttackDegree)
        {
            Debug.Log(degree);
            Bullet bullet = Instantiate<Bullet>(this.enemyBullet, this.transform.position, Quaternion.identity);
            bullet.ShooterTag = this.tag;
            bullet.MoveDirection = degree;
            bullet.enabled = true;
            yield return new WaitForSeconds(0f);
        }
        yield return null;
    }

    public override IEnumerator Attack()
    {
        while (true)
        {
            if (!this.model.CanAttack)
            {
                yield return new WaitForEndOfFrame();
                continue;
            }
            yield return this.CircleAttack();
            yield return new WaitForSeconds(this.attackInterval);
            yield return StraightAttack();
            yield return new WaitForSeconds(this.attackInterval);
        }
    }

    void OnDestory()
    {
        Destroy(this.enemyBullet.gameObject);
    }
}
