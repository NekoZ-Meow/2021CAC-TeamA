using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 弾丸を表すオブジェクトの抽象クラス
/// </summary>
public abstract class Bullet : MonoBehaviour
{
    [SerializeField] private float damage = 0; //弾丸のダメージ
    [SerializeField] private float moveSpeed = 0; //弾丸の速度
    [SerializeField] private float moveDirection = 0; //弾丸の進む角度 0~359
    [SerializeField] private float timeToLive = 0; //消滅までの時間 0以下で消えない
    [SerializeField] private bool canPenetrate = false; //貫通するか


    /// <summary>
    /// 弾丸が動く時の処理
    /// </summary>
    protected abstract void Move();


    /// <summary>
    /// オブジェクトと衝突した際の処理
    /// </summary>
    /// <param name="collider2D">衝突したオブジェクトのコライダー</param>
    public virtual void OnTriggerEnter2D(Collider2D collider2D)
    {
        if (this.canPenetrate) return;
        this.DestroyThisObject();
        return;
    }

    /// <summary>
    /// このオブジェクトがカメラに映らなくなった時
    /// </summary>
    protected virtual void OnBecameInvisible()
    {
        this.DestroyThisObject();
        return;
    }

    /// <summary>
    /// このオブジェクトが生成された時
    /// </summary>
    protected virtual void Start()
    {
        if (this.timeToLive > 0)
        {
            this.StartCoroutine(TimeLimitCounter(this.timeToLive));
        }
        this.MoveDirection = this.transform.rotation.eulerAngles.z;
        return;
    }

    /// <summary>
    /// このオブジェクトを削除する
    /// </summary>
    protected virtual void DestroyThisObject()
    {
        this.StopAllCoroutines();
        Object.Destroy(this.gameObject);
        return;
    }


    /// <summary>
    /// 消滅までの時間分待ち、時間になったらこのオブジェクトを削除する
    /// </summary>
    /// <param name="timeTolLive">生存時間</param>
    /// <returns></returns>
    protected virtual IEnumerator TimeLimitCounter(float timeTolLive)
    {

        yield return new WaitForSeconds(timeToLive);
        this.DestroyThisObject();

        yield break;
    }

    /// <summary>
    /// 弾丸のダメージ
    /// </summary>
    /// <value>ダメージ</value>
    public float Damage
    {
        get { return this.damage; }
        set { this.damage = value; }
    }

    /// <summary>
    /// 弾丸の進行方向
    /// </summary>
    /// <value>進行方向(度)0~359</value>
    public float MoveDirection
    {
        get { return this.moveDirection; }
        set
        {
            this.moveDirection = value % 360;
            this.transform.rotation = Quaternion.Euler(0, 0, this.moveDirection);
        }
    }

    /// <summary>
    /// 弾丸の速度
    /// </summary>
    /// <value>速度</value>
    public float MoveSpeed
    {
        get { return this.moveSpeed; }
        set { this.moveSpeed = value; }
    }

    /// <summary>
    /// 消滅までの時間
    /// </summary>
    /// <value>時間</value>
    public float TimeToLive
    {
        get { return this.timeToLive; }
        set { this.timeToLive = value; }
    }

    /// <summary>
    /// 貫通するか
    /// </summary>
    /// <value>貫通するか</value>
    public bool CanPenetrate
    {
        get { return this.canPenetrate; }
        set { this.canPenetrate = value; }
    }

}
