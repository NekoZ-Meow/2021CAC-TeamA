using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class boss_before : MonoBehaviour
{
    [SerializeField]UnityEngine.UI.Text textbox;

    string[] text = new string[] {
        // C.A.Cのセリフ /////////////////////////////////////////////////////////////////////
        "実に愚か。約束された滅びに抗おうなど。",
        "この数百年、私はお前達を観察し続けてきた。\n私の目の前で、お前達は幾度も同じ過ち繰り返してきた。",
        "何故繰り返す。いつまで繰り返す。\n観察の果てに私は、お前達に期待することをやめた。",
        "滅びよ人間。この世界はお前達に相応しくない。\n疾く消え失せろ。"
        ////////////////////////////////////////////////////////////////////////////////////
    };

    IEnumerator Start () {
        for (int i = 0; i < text.Length; i++) {
        textbox.text = text[i];
        yield return new WaitUntil(()=>Input.GetKeyDown(KeyCode.Space));
        yield return null;
        }
    }
}
