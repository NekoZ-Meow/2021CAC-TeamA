using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// オプションの操作
/// </summary>
public class OptionController : MonoBehaviour
{
    [SerializeField] List<OptionBase> optionValues;
    [SerializeField] private GameObject selector;

    private int selectorIndex = 0;

    private bool isLongPress = false;

    // Start is called before the first frame update
    void Start()
    {
        this.optionValues.Sort((aGameObject, anotherGameObject) => -(int)(aGameObject.transform.position.y - anotherGameObject.transform.position.y));

    }

    /// <summary>
    /// オプションが表示されるときの処理
    /// </summary>
    private void OnEnable()
    {
        if (this.optionValues.Count == 0) return;
        this.selectorIndex = 0;
        this.ChangeOption(this.selectorIndex);
    }

    /// <summary>
    /// オプションが非表示になるときの処理
    /// </summary>
    private void OnDisable()
    {
        this.optionValues[this.selectorIndex].dispose();
    }

    /// <summary>
    /// オプションを変更する
    /// </summary>
    /// <param name="nextIndex">次のインデックス番号</param>
    private void ChangeOption(int nextIndex)
    {
        this.selector.transform.position = new Vector3(this.selector.transform.position.x, this.optionValues[nextIndex].transform.position.y, this.selector.transform.position.z);
        this.optionValues[this.selectorIndex].dispose();
        this.optionValues[nextIndex].onSelected();
        this.selectorIndex = nextIndex;
    }

    /// <summary>
    /// セレクターを移動させるインデックスを計算する
    /// </summary>
    /// <param name="yInput">y軸の入力</param>
    private void MoveSelector(float yInput)
    {
        if (this.isLongPress || this.optionValues.Count == 0)
        {
            return;
        }
        this.isLongPress = true;
        int nextIndex = this.selectorIndex;

        if (yInput < 0)
        {
            if (this.selectorIndex == 0)
            {
                nextIndex = this.optionValues.Count - 1;
            }
            else
            {
                nextIndex -= 1;
            }
        }
        else
        {
            if (this.selectorIndex == this.optionValues.Count - 1)
            {
                nextIndex = 0;

            }
            else
            {
                nextIndex += 1;
            }
        }
        this.ChangeOption(nextIndex);

        return;
    }

    // Update is called once per frame
    void Update()
    {
        float yInput = Input.GetAxisRaw("Vertical");
        if (yInput != 0)
        {
            this.MoveSelector(yInput);
        }
        else
        {
            this.isLongPress = false;
        }
    }
}

