using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PlayerUi : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI textbox;
    [SerializeField]
    private TextMeshProUGUI namebox;
    [SerializeField]
    private int[] namenumbers;
    private int textnumber = 0;
    public string[] texts;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //マウスクリックかつ、textnumberがテキストの要素数を超えないなら
        if (Input.GetMouseButtonDown(0) && texts.Length > textnumber)
        {
            TextView();
        }
    }
    /// <summary>
    /// テキスト表示
    /// </summary>
    private void TextView()
    {
        textbox.text = texts[textnumber];
        this.ChangeName();
        textnumber++;
    }
    /// <summary>
    /// 名前変更
    /// </summary>
    private void ChangeName()
    {
        switch (namenumbers[textnumber])
        {
            case 1:
                namebox.text = "C.A.C";
                break;
            case 2:
                namebox.text = "自分";
                break;
            case 3:
                namebox.text = "";
                break;
        }
    }
}
