using UnityEngine;

/// <summary>
/// 領域の定義
/// </summary>
public static class AreaUtility
{
    /// <summary>
    /// スクリーン領域をのワールド領域で返す
    /// </summary>
    /// <returns>領域</returns>
    public static BoxArea GetScreenArea()
    {
        Vector2 topLeft = Camera.main.ScreenToWorldPoint(Vector3.zero);
        Vector2 bottomRight = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, 0.0f));

        // 上下反転させる
        topLeft.Scale(new Vector3(1f, -1f, 1f));
        bottomRight.Scale(new Vector3(1f, -1f, 1f));

        return new BoxArea(topLeft, bottomRight);
    }

    /// <summary>
    /// メニューを含まない画面の大きさ
    /// </summary>
    /// <returns></returns>
    public static BoxArea GetPlayableArea()
    {
        BoxArea result = Areas.SCREEN_AREA.Copy();
        result.ChangeWidth(result.GetWidth() * 0.7f);
        return result;
    }

    /// <summary>
    /// min<=value<=maxが成り立つかどうか
    /// </summary>
    /// <param name="value">値</param>
    /// <param name="min">最小値</param>
    /// <param name="max">最大値</param>
    /// <returns>成り立つか</returns>
    public static bool WithinRange(float value, float min, float max)
    {
        return (min <= value && value <= max);
    }

}
