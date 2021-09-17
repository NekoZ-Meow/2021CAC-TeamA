using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 矩形の領域を表すクラス
/// </summary>
[System.Serializable]
public class BoxArea
{
    [SerializeField] private Vector2 topLeft = Vector2.zero;
    [SerializeField] private Vector2 bottomRight = Vector2.zero;

    /// <summary>
    /// コンストラクタ
    /// </summary>
    /// <param name="topLeft">左上の座標</param>
    /// <param name="bottomRight">右下の座標</param>
    public BoxArea(Vector2 topLeft, Vector2 bottomRight)
    {
        if (topLeft.x > bottomRight.x)
        {
            throw new System.ArgumentException("topLeft.x > bottomRight.x");
        }
        else if (topLeft.y < bottomRight.y)
        {
            throw new System.ArgumentException("topLeft.y < bottomRight.y");
        }

        this.topLeft = topLeft;
        this.bottomRight = bottomRight;

        return;
    }

    /// <summary>
    /// 指定した幅になるように右下の座標を変更する
    /// </summary>
    /// <param name="width">幅</param>
    public void ChangeWidth(float width)
    {
        this.bottomRight.x = this.topLeft.x + width;
        return;
    }

    /// <summary>
    /// 指定した幅になるように右下の座標を変更する
    /// </summary>
    /// <param name="height">幅</param>
    public void ChangeHeight(float height)
    {
        this.bottomRight.y = this.topLeft.y - height;
        return;
    }

    /// <summary>
    /// 幅を取得する
    /// </summary>
    /// <returns>幅</returns>
    public float GetWidth()
    {
        return Mathf.Abs(this.bottomRight.x - this.topLeft.x);
    }

    /// <summary>
    /// 高さを取得する
    /// </summary>
    /// <returns>高さ</returns>
    public float GetHeight()
    {
        return Mathf.Abs(this.bottomRight.y - this.topLeft.y);
    }

    /// <summary>
    /// 面積を取得する
    /// </summary>
    /// <returns>面積</returns>
    public float GetArea()
    {
        return this.GetWidth() * this.GetHeight();
    }

    /// <summary>
    /// 与えられた座標が領域内にあるか
    /// 境界線を含む
    /// </summary>
    /// <param name="position">座標</param>
    /// <returns>存在する場合はtrue それ以外はfalse</returns>
    public bool IsInTheArea(Vector2 position)
    {
        return (this.topLeft.x <= position.x && position.x <= this.bottomRight.x) &&
            (this.bottomRight.y <= position.y && position.y <= this.topLeft.y);
    }

    /// <summary>
    /// 領域を移動させる
    /// </summary>
    /// <param name="x">x軸の移動量</param>
    /// <param name="y">y軸の移動量</param>
    public void Transform(float x, float y)
    {
        this.topLeft.x += x;
        this.bottomRight.x += x;
        this.topLeft.y += y;
        this.bottomRight.y += y;

        return;
    }

    /// <summary>
    /// このエリアのコピーを返す
    /// <summary>
    /// <returns>エリアのコピー</returns>
    public BoxArea Copy()
    {
        return new BoxArea(this.topLeft, this.bottomRight);
    }

    public Vector2 TopLeft
    {
        get { return this.topLeft; }
    }
    public Vector2 BottomRight
    {
        get { return this.bottomRight; }
    }

}
