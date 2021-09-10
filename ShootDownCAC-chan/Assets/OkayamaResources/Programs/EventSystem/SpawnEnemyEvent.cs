using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEnemyEvent : Event
{
    private GameObject enemy = Resources.Load<GameObject>("Enemy/TestEnemy");
    private float speed;
    public SpawnEnemyEvent(string name, float speed = 1.5f)
    {
        base.eventName = name;
        this.speed = speed;

        return;
    }

    public override IEnumerator Routine()
    {
        BoxArea playableArea = AreaUtility.GetPlayableArea();
        for (int i = 0; i < 10; i++)
        {
            float x = Random.Range(playableArea.TopLeft.x, playableArea.BottomRight.x);
            Vector2 position = new Vector2(x, 6);
            GameObject enemy = GameObject.Instantiate(this.enemy, position, Quaternion.identity);
            enemy.GetComponent<EnemyMove>().Speed = this.speed;
            yield return new WaitForSeconds(1);
        }

        yield break;
    }
}


public class StraightEnemySpawnEvent : Event
{
    private GameObject enemy = Resources.Load<GameObject>("Enemy/TestEnemy");
    private int enemyNumber;
    private float direction;
    private Vector2 spawnPosition;
    private float speed;
    public StraightEnemySpawnEvent(string name, int enemyNumber, float direction, Vector2 spawnPosition, float speed = 1.5f)
    {
        base.eventName = name;
        this.enemyNumber = enemyNumber;
        this.direction = direction;
        this.spawnPosition = spawnPosition;
        this.speed = speed;
        return;
    }

    public override IEnumerator Routine()
    {
        List<GameObject> enemies = new List<GameObject>();
        BoxArea playableArea = AreaUtility.GetPlayableArea();
        float rad = direction * Mathf.Deg2Rad;
        float diffX = 1.5f * Mathf.Cos(rad);
        float diffY = 1.5f * Mathf.Sin(rad);
        for (int i = 0; i < 5; i++)
        {
            GameObject enemy = GameObject.Instantiate(this.enemy, new Vector2(this.spawnPosition.x - i * diffX, spawnPosition.y - i * diffY), Quaternion.identity);
            enemy.GetComponent<EnemyMove>().Speed = this.speed;
            enemy.GetComponent<EnemyMove>().Direction = this.direction;
        }

        yield break;
    }
}