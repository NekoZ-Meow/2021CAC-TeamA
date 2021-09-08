using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEnemyEvent : Event
{
    private GameObject enemy = Resources.Load<GameObject>("Enemy/TestEnemy");
    public SpawnEnemyEvent(string name)
    {
        base.eventName = name;

        return;
    }

    public override IEnumerator Routine()
    {
        for (int i = 0; i < 10; i++)
        {
            float x = Random.Range(Areas.SCREEN_AREA.topLeft.x, Areas.SCREEN_AREA.bottomRight.x);
            Vector2 position = new Vector2(x, 6);
            GameObject.Instantiate(enemy, position, Quaternion.identity);
            yield return new WaitForSeconds(1);
        }

        yield break;
    }
}
