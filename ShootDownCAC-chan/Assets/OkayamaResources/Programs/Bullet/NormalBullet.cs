using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 直進する弾丸を表すクラス
/// </summary>
public class NormalBullet : Bullet
{

    /// <summary>
    /// このオブジェクトを指定した方向に指定したスピードで移動させる
    /// </summary>
    protected override void Move()
    {
        float rad = base.MoveDirection * Mathf.Deg2Rad;
        float xMove = base.MoveSpeed * Mathf.Cos(rad);
        float yMove = base.MoveSpeed * Mathf.Sin(rad);
        this.transform.position += new Vector3(xMove*Time.fixedDeltaTime, yMove*Time.fixedDeltaTime, 0);

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
        this.Move();

        return;
    }
}
