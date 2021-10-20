using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 敵の攻撃の抽象クラス
/// </summary>
public abstract class EnemyAttack : MonoBehaviour
{
    /// <summary>
    /// 攻撃を行う
    /// </summary>
    /// <returns></returns>
    public abstract IEnumerator Attack();
}
