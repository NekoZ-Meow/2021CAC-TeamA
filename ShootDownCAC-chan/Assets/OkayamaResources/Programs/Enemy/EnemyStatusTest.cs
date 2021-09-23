using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStatusTest : MonoBehaviour
{
    [SerializeField] private float hp = 100;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == Tags.PLAYER_BULLET)
        {
            int score = GameObject.FindGameObjectWithTag(Tags.PLAYER).GetComponent<PlayerStatus>().score += (int)collision.GetComponent<Bullet>().Damage;
            GameObject.FindGameObjectWithTag(Tags.UI_CONTROLLER).GetComponent<UIController>().SetScoreValue(score);
            this.CauseDamage(collision.GetComponent<Bullet>().Damage);
        }
    }

    private void DestoryThisObject()
    {
        this.StopAllCoroutines();
        Object.Destroy(this.gameObject);
    }

    public void CauseDamage(float value)
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
}
