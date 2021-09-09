using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/// <summary>
/// 全ての敵が消滅するまで待つ
/// </summary>
public class WaitUntilAllEnemiesAreDestroyed : Event
{
    public WaitUntilAllEnemiesAreDestroyed()
    {
        base.eventName = "敵消滅待ち";
    }

    /// <summary>
    /// 敵が存在しなくなるまで待つ
    /// </summary>
    /// <returns></returns>
    public override IEnumerator Routine()
    {
        yield return new WaitUntil(() => GameObject.FindWithTag(Tags.ENEMY) == null);
    }
}
