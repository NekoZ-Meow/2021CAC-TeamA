using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 敵のモデル
/// </summary>
public class EnemyModel : MonoBehaviour
{
    [SerializeField] private float hp = 100; //敵の体力
    [SerializeField] private float moveSpeed = 1f; // 敵の速度


    /// <summary>
    /// 弾丸に命中した時
    /// </summary>
    /// <param name="collision">衝突したコライダ</param>
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == Tags.PLAYER_BULLET)
        {
            int score = GameObject.FindGameObjectWithTag(Tags.PLAYER).GetComponent<PlayerStatus>().score += (int)collision.GetComponent<Bullet>().Damage;
            GameObject.FindGameObjectWithTag(Tags.UI_CONTROLLER).GetComponent<UIController>().SetScoreValue(score);
            this.TakeDamage(collision.GetComponent<Bullet>().Damage);
        }
    }

    private void Start()
    {
        StartCoroutine(this.GetComponent<EnemyAttack>().Attack());
        return;
    }

    /// <summary>
    /// このオブジェクトを破壊する
    /// </summary>
    private void DestoryThisObject()
    {
        this.StopAllCoroutines();
        Object.Destroy(this.gameObject);
    }

    /// <summary>
    /// ダメージを与える
    /// </summary>
    /// <param name="value"></param>
    public void TakeDamage(float value)
    {
        this.Hp -= value;
        return;
    }

    public float Hp
    {
        get { return this.hp; }
        set
        {
            this.hp = value;
            if (this.hp <= 0)
            {
                this.DestoryThisObject();
            }
        }
    }

    public float MoveSpeed
    {
        get { return this.moveSpeed; }
        set { this.moveSpeed = value; }
    }
}
