using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// ゲームオブジェクトに関する便利な処理
/// </summary>
public class GameObjectUtility
{
    /// <summary>
    /// 対象のオブジェクトから最も近い場所にある指定したタグを持つオブジェクトを返す
    /// </summary>
    /// <param name="centerObject">中心となるオブジェクト</param>
    /// <param name="tag">検索対象のタグ</param>
    /// <returns>最も近いオブジェクト</returns>
    public static GameObject FindNearlyGameObjectWithTag(GameObject centerObject, string tag)
    {
        GameObject result = null;
        GameObject[] targetObjects = GameObject.FindGameObjectsWithTag(tag);

        float minDistance = float.MaxValue;

        foreach (GameObject target in targetObjects)
        {
            float distance = (centerObject.transform.position - target.transform.position).magnitude;
            if (distance < minDistance)
            {
                result = target;
            }
        }
        return result;
    }
}
