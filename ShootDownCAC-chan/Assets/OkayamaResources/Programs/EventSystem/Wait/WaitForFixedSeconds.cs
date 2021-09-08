using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 指定された時間にできるだけ正確に待つ
/// </summary>
public class WaitForFixedSeconds : Event
{
    [SerializeField] private double waitFrame = 0; //待つフレーム数
    private long waitFixedFrameCount = 0; //フレーム数

    /// <summary>
    /// コンストラクタ
    /// </summary>
    /// <param name="seconds">待つ時間。Time.fixedDeltaTimeの倍数であるとより正確</param>
    public WaitForFixedSeconds(float seconds)
    {
        base.eventName = "";
        this.waitFrame = Mathf.Ceil(seconds / Time.fixedDeltaTime);
    }

    /// <summary>
    /// 正確な時間で一定時間待つ
    /// </summary>
    /// <returns></returns>
    public override IEnumerator Routine()
    {
        while (true)
        {
            if (this.waitFixedFrameCount >= this.waitFrame)
            {
                break;
            }
            yield return new WaitForFixedUpdate();
            this.waitFixedFrameCount += 1;
        }
        yield break;
    }
}
