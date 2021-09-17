using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// プレイヤー射撃のアニメーションを管理する
/// </summary>
public class PlayerShootingAnimation : MonoBehaviour
{
    [SerializeField] private GameObject maker;
    [SerializeField] private bool isAnimate = false;
    private PlayerAudio playerAudio;
    // Start is called before the first frame update
    void Start()
    {
        this.playerAudio = this.GetComponent<PlayerAudio>();
    }

    /// <summary>
    /// ロックオンマークのアニメーションを開始する
    /// </summary>
    /// <param name="targetNumber">最大ターゲット数</param>
    /// <param name="maxDistance">最大距離</param>
    public void StartLockOnAnimation(int targetNumber, float maxDistance)
    {
        this.isAnimate = true;
        this.StartCoroutine(this.LockOnAnimation(targetNumber, maxDistance));
    }

    /// <summary>
    /// アニメーションを止める
    /// </summary>
    public void StopAnimation()
    {
        this.isAnimate = false;

        return;
    }

    /// <summary>
    /// ロックオンした対象にマークをつける
    /// 別のクラスに移動するかも
    /// </summary>
    /// <param name="targetNumber">ロックオンの数</param>
    /// <returns></returns>
    public IEnumerator LockOnAnimation(int targetNumber, float maxDistance)
    {
        List<GameObject> makers = new List<GameObject>();
        HashSet<GameObject> beforeTargets = new HashSet<GameObject>();
        for (int i = 0; i < targetNumber; i++)
        {
            GameObject maker = Object.Instantiate(this.maker);
            maker.SetActive(false);
            makers.Add(maker);
        }
        while (this.isAnimate)
        {
            List<GameObject> targets = GameObjectUtility.FindNearlyNGameObjectsWithTag(this.gameObject, Tags.ENEMY, targetNumber, maxDistance);
            for (int i = 0; i < targets.Count; i++)
            {
                makers[i].SetActive(true);
                makers[i].transform.position = targets[i].transform.position;
                if (!beforeTargets.Contains(targets[i]))
                {
                    makers[i].GetComponent<Animator>().Play("LockOnAnimation", 0, 0);
                    this.playerAudio.PlayLockOnSound();
                }
            }
            for (int i = targets.Count; i < targetNumber; i++)
            {
                makers[i].SetActive(false);
            }
            beforeTargets = new HashSet<GameObject>(targets);
            yield return new WaitForEndOfFrame();
        }
        makers.ForEach(maker => Object.Destroy(maker.gameObject));
    }
}
