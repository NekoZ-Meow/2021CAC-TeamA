using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 直線状に並べて敵を生成する
/// </summary>
public class StraightEnemySpawnEvent : Event
{
    private GameObject enemy;
    private int enemyNumber;
    private float direction;
    private Vector2 spawnPosition;
    private float speed;
    private float space;

    public StraightEnemySpawnEvent(GameObject enemy, int enemyNumber, float direction, Vector2 spawnPosition, string name = "直線敵生成", float speed = 1.5f, float space = 1.5f)
    {
        base.eventName = name;
        this.enemyNumber = enemyNumber;
        this.direction = direction;
        this.spawnPosition = spawnPosition;
        this.speed = speed;
        this.space = space;
        this.enemy = enemy;
        return;
    }

    public override IEnumerator Routine()
    {
        List<GameObject> enemies = new List<GameObject>();
        BoxArea playableArea = AreaUtility.GetPlayableArea();
        float rad = direction * Mathf.Deg2Rad;
        float diffX = this.space * Mathf.Cos(rad);
        float diffY = this.space * Mathf.Sin(rad);
        for (int i = 0; i < this.enemyNumber; i++)
        {
            GameObject enemy = GameObject.Instantiate(this.enemy, new Vector2(this.spawnPosition.x - i * diffX, spawnPosition.y - i * diffY), Quaternion.identity);
            enemy.GetComponent<EnemyMove>().Speed = this.speed;
            enemy.GetComponent<EnemyMove>().Direction = this.direction;
        }

        yield break;
    }
}