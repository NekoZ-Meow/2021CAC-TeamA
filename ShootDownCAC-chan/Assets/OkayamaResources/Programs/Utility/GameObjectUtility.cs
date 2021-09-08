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

    /// <summary>
    /// 対象のオブジェクトから近い順にN個指定したタグを持つオブジェクトを返す
    /// </summary>
    /// <param name="centerObject">中心となるオブジェクト</param>
    /// <param name="tag">検索対象のタグ</param>
    /// <returns>最も近いオブジェクト</returns>
    public static List<GameObject> FindNearlyNGameObjectsWithTag(GameObject centerObject, string tag, int n = 1)
    {
        List<GameObject> targetObjects = new List<GameObject>(GameObject.FindGameObjectsWithTag(tag));
        if (targetObjects.Count <= n)
        {
            return targetObjects;
        }
        targetObjects.Sort((aGameObject, anotherGameObject) => ((int)(GetDistance(centerObject, aGameObject) - GetDistance(centerObject, anotherGameObject))));
        return targetObjects.GetRange(0, n);
    }

    /// <summary>
    /// リストの中の最も近いターゲットを返す
    /// </summary>
    /// <param name="targetObject">対象のオブジェクト</param>
    /// <param name="gameObjectList">検索対象のリスト</param>
    /// <returns></returns>
    public static GameObject FindNearlyGameObjectInList(GameObject targetObject, List<GameObject> gameObjectList)
    {
        GameObject result = null;
        float minDistance = float.MaxValue;
        gameObjectList.ForEach((aGameObject) =>
        {
            float distance = (aGameObject.transform.position - targetObject.transform.position).magnitude;
            if (minDistance > distance)
            {
                minDistance = distance;
                result = aGameObject;
            }
        });
        return result;
    }

    /// <summary>
    /// 対象との距離を計算する
    /// </summary>
    /// <param name="aGameObject"></param>
    /// <param name="anotherGameObject"></param>
    /// <returns></returns>
    private static float GetDistance(GameObject aGameObject, GameObject anotherGameObject)
    {
        return (aGameObject.transform.position - anotherGameObject.transform.position).magnitude;
    }


}
