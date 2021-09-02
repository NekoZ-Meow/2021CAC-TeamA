using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HomingBullet : Bullet
{
    [SerializeField] protected GameObject target = null; // 誘導対象
    [SerializeField] private float homingDegree = 5f; // 誘導角度

    /// <summary>
    /// このオブジェクトを指定した方向に指定したスピードで移動させる
    /// </summary>
    protected override void Move()
    {
        float rad = base.MoveDirection * Mathf.Deg2Rad;
        float xMove = base.MoveSpeed * Mathf.Cos(rad);
        float yMove = base.MoveSpeed * Mathf.Sin(rad);
        this.transform.position += new Vector3(xMove * Time.fixedDeltaTime, yMove * Time.fixedDeltaTime, 0);

        return;
    }

    /// <summary>
    /// 誘導対象に向かって誘導する
    /// </summary>
    private void HormingTarget()
    {
        Debug.Log(this.target);
        if (!target)
        {
            return;
        }
        Vector3 direction = this.target.transform.position - this.transform.position;
        Quaternion targetRotation = Quaternion.LookRotation(direction);
        Quaternion nextRotation = Quaternion.RotateTowards(this.transform.rotation, targetRotation, this.homingDegree * Time.fixedDeltaTime);
        this.MoveDirection = nextRotation.eulerAngles.z;

        return;
    }

    /// <summary>
    /// オブジェクトの生成時に実行されるメソッド
    /// </summary>
    protected override void Start()
    {
        base.Start();

        return;
    }

    /// <summary>
    /// 一定時間ごとに実行されるメソッド
    /// </summary>
    void FixedUpdate()
    {
        this.HormingTarget();
        this.Move();

        return;
    }

    /// <summary>
    /// 誘導対象
    /// </summary>
    /// <value>対象のゲームオブジェクト</value>
    public GameObject Target
    {
        get { return this.target; }
        set { this.target = value; }
    }

    /// <summary>
    /// 1フレーム毎に誘導する角度
    /// </summary>
    /// <value>角度(度)</value>
    public float HomingDegree
    {
        get { return this.homingDegree; }
        set { this.homingDegree = value; }
    }
}
