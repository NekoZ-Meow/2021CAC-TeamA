using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Bullet : MonoBehaviour
{
    [SerializeField] protected float moveSpeed = 0; //弾丸の速度
    [SerializeField] protected float moveDirection = 0; //弾丸の進む角度 0~359
    [SerializeField] protected float timeToLive = 0; //消滅までの時間

    /// <summary>
    /// オブジェクトと衝突した際の処理
    /// </summary>
    /// <param name="collider2D">衝突したオブジェクトのコライダー</param>
    public virtual void OnTriggerEnter2D(Collider2D collider2D)
    {
        Destroy(this.gameObject);
        return;
    }

    void OnWillRenderObject()
    {
        if (Camera.current.Equals(Camera.main))
        {

        }
    }

    /// <summary>
    /// 弾丸が動く時の処理
    /// </summary>
    protected abstract void Move();
}
