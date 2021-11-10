using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// イベントの実行を管理するクラス
/// 
/// オブジェクトにアッタッチして使用する
/// </summary>
public class EventController : MonoBehaviour
{
    [SerializeField] private bool isPlaying = false; // 現在再生中か
    [SerializeReference] private List<Event> events = new List<Event>(); // イベント
    [SerializeField] private int nowIndex = 0; // 現在のインデックス
    private IEnumerator nowRoutine = null; // 現在のルーチン

    void Start()
    {
        GameObject enemy = Resources.Load<GameObject>("Enemy/TestEnemy");
        GameObject boss = Instantiate(Resources.Load<GameObject>("Enemy/BossEnemy"), new Vector3(999, 999, 999), Quaternion.identity);
        boss.GetComponent<EnemyModel>().CanAttack = false;
        boss.GetComponent<EnemyModel>().CanMove = false;
        Image bossImage = Object.Instantiate<Image>(Resources.Load<Image>("Enemy/BossCharactor"), new Vector3(999, 999, 999), Quaternion.identity);
        this.AddEvent(new ShowStageTitle("ステージ1"));
        // this.AddEvent(new RandomSpawnEnemyEvent(enemy, "敵生成", enemySpeed: 2f));
        // this.AddEvent(new WaitUntilAllEnemiesAreDestroyed());
        this.AddEvent(new SetPlayerStatusEvent(canShot: false, canMove: false));
        this.AddEvent(new SpawnBossEvent(boss));
        this.AddEvent(new ShowCharactorEvent(bossImage));
        this.AddEvent(new ShowMessageWindowEvent());
        this.AddEvent(new ShowMessageEvent("実に愚か。約束された滅びに抗おうなど。", "CACちゃん", 0.05f));
        this.AddEvent(new ShowMessageEvent("この数百年、私はお前達を観察し続けてきた。私の目の前で、お前達は幾度も同じ過ち繰り返してきた。何故繰り返す。", "CACちゃん", 0.05f));
        this.AddEvent(new ShowMessageEvent("滅びよ人間。この世界はお前達に相応しくない。疾く消え失せろ。", "CACちゃん", 0.05f));
        this.AddEvent(new HideMessageWindowEvent());
        this.AddEvent(new HideCharactorEvent(bossImage));
        this.AddEvent(new SetPlayerStatusEvent(canShot: true, canMove: true));
        this.AddEvent(new SetBossStatusEvent(boss, true, true));
        // this.AddEvent(new RandomSpawnEnemyEvent(enemy, "敵生成", enemySpeed: 2f));
        // this.AddEvent(new WaitUntilAllEnemiesAreDestroyed());
        // this.AddEvent(new StraightEnemySpawnEvent(enemy, 5, 180, new Vector2(Areas.SCREEN_AREA.BottomRight.x + 3, 3), speed: 2.5f));
        // this.AddEvent(new StraightEnemySpawnEvent(enemy, 5, 0, new Vector2(Areas.SCREEN_AREA.TopLeft.x - 5, 1), speed: 2.5f));
        // this.AddEvent(new WaitUntilAllEnemiesAreDestroyed());
        // this.AddEvent(new StraightEnemySpawnEvent(enemy, 5, 330, new Vector2(Areas.SCREEN_AREA.TopLeft.x - 3, 5), speed: 2));
        // this.AddEvent(new StraightEnemySpawnEvent(enemy, 5, 210, new Vector2(Areas.SCREEN_AREA.BottomRight.x + 3, 4), speed: 2));
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