using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnBossEvent : Event
{
    [SerializeField] private GameObject boss;
    public SpawnBossEvent(GameObject boss, string name = "ボス敵生成")
    {
        this.boss = boss;
        return;
    }

    public override IEnumerator Routine()
    {

        BoxArea playableArea = AreaUtility.GetPlayableArea();
        Vector2 topPosition = new Vector2(playableArea.TopLeft.x + playableArea.GetWidth() / 2, playableArea.TopLeft.y / 1.5f);
        Vector2 spawnPoint = topPosition + new Vector2(0, 5f);
        this.boss.transform.position = spawnPoint;
        Vector2 currentVelocity = Vector2.zero;
        while (true)
        {
            this.boss.transform.position = Vector2.SmoothDamp(this.boss.transform.position, topPosition, ref currentVelocity, 0.5f);
            if (currentVelocity.magnitude < 0.01f)
            {
                break;
            }
            yield return new WaitForEndOfFrame();
        }
        yield break;
    }
}
