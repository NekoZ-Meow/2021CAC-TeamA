using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class TestEvent : Event
{
    public TestEvent(string name)
    {
        base.eventName = name;

        return;
    }

    public override IEnumerator Routine()
    {
        Debug.Log(this.eventName + " 開始");
        yield return new WaitForSeconds(3);
        Debug.Log(this.eventName + " 1");
        yield return new WaitForSeconds(3);
        Debug.Log(this.eventName + " 2");
        yield return new WaitForSeconds(3);
        Debug.Log(this.eventName + " 終了");
    }
}
