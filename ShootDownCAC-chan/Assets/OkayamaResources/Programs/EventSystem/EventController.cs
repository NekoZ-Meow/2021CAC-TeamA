using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// イベントの実行を管理するクラス
/// 
/// オブジェクトにアッタッチして使用する
/// </summary>
public class EventController : MonoBehaviour
{
    [SerializeField] private bool isPlaying = false; // 現在再生中か
    [SerializeReference] List<Event> events = new List<Event>(); // イベント
    [SerializeField] private int nowIndex = 0; // 現在のインデックス
    private IEnumerator nowRoutine = null; // 現在のルーチン


    void Start()
    {
        this.AddEvent(new SpawnEnemyEvent("敵生成"));
        this.events.Add(new WaitUntilAllEnemiesAreDestroyed());
        this.events.Add(new TestEvent("テスト1"));
        this.Play();
        return;
    }

    /// <summary>
    /// イベントを追加する
    /// </summary>
    /// <param name="anEvent">イベント</param>
    public void AddEvent(Event anEvent)
    {
        this.events.Add(anEvent);
        return;
    }

    /// <summary>
    /// イベントを再生する
    /// </summary>
    public void Play()
    {
        if (this.isPlaying)
        {
            return;
        }

        if (this.nowRoutine == null)
        {
            this.nowRoutine = this.events[nowIndex].Routine();
        }

        IEnumerator StartEvent()
        {
            while (true)
            {
                yield return this.StartCoroutine(this.nowRoutine);
                if (!this.isPlaying)
                {
                    Debug.Log("Already Stopped");
                    yield break;
                };
                this.nowIndex += 1;
                if (this.nowIndex == this.events.Count)
                {
                    Debug.Log("All Events Finished");
                    this.isPlaying = false;
                    yield break;
                }
                else
                {
                    this.nowRoutine = this.events[nowIndex].Routine();
                }
            }
        }

        this.isPlaying = true;
        this.StartCoroutine(StartEvent());

        return;
    }

    /// <summary>
    /// イベントの再生を停止する
    ///
    /// 現状停止した後再生するとその次のyieldが実行される
    /// </summary>
    public void Stop()
    {
        this.isPlaying = false;
        if (!this.isPlaying | this.nowRoutine == null)
        {
            this.StopCoroutine(this.nowRoutine);
        }
    }
}