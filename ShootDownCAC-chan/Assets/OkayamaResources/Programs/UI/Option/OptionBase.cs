using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// オプションのウィジェットの抽象クラス
/// </summary>
public abstract class OptionBase : MonoBehaviour
{
    protected IEnumerator routine;
    /// <summary>
    /// 選択された
    /// </summary>
    public virtual void onSelected()
    {
        this.routine = this.Routine();
        StartCoroutine(this.routine);
    }

    /// <summary>
    /// 選択が解除された時
    /// </summary>
    public virtual void dispose()
    {
        if (this.routine is null) return;
        StopCoroutine(this.routine);

        return;
    }

    /// <summary>
    /// オプション展開時の初期化処理
    /// </summary>
    public abstract void initialize();

    /// <summary>
    /// 選択された時の処理
    /// </summary>
    /// <returns></returns>
    protected abstract IEnumerator Routine();

}
