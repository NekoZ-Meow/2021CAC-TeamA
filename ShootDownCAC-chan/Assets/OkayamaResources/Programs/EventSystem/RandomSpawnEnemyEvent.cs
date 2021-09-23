using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// ランダムに敵を生成するイベント
/// </summary>
[System.Serializable]
public class RandomSpawnEnemyEvent : Event
{
    [SerializeField] private GameObject enemy;
    [SerializeField] private float enemySpeed;
    [SerializeField] private float spawnInterval;
    public RandomSpawnEnemyEvent(GameObject enemy, string name = "ランダム敵生成",
    int enemyNumber = 10, float enemySpeed = 1.5f, float spawnInterval = 1)
    {
        base.eventName = name;
        this.enemySpeed = enemySpeed;
        this.enemy = enemy;
        this.spawnInterval = spawnInterval;
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
            enemy.GetComponent<EnemyMove>().Speed = this.enemySpeed;
            yield return new WaitForSeconds(this.spawnInterval);
        }

        yield break;
    }
}

