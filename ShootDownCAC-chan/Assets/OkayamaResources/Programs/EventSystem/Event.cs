using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// イベントの抽象クラス
/// </summary>
[System.Serializable]
public abstract class Event
{
    [SerializeField] protected string eventName = "イベント"; //イベント名


    /// <summary>
    /// イベントの内容
    /// </summary>
    /// <returns></returns>
    public abstract IEnumerator Routine();

    /// <summary>
    /// イベント名
    /// </summary>
    /// <value>イベント名</value>
    public string EventName
    {
        get { return this.eventName; }
    }

    /// <summary>
    /// このクラスを文字列にして返す
    /// </summary>
    /// <returns>文字列</returns>
    public override string ToString()
    {
        return string.Format("Event: %s", this.eventName);
    }
}
