using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class story1 : MonoBehaviour
{
    [SerializeField]UnityEngine.UI.Text textbox;
    IEnumerator Start () {
        //スペースで文章が1行進む
        textbox.text = "おはよう";
        yield return new WaitUntil(()=>Input.GetKeyDown(KeyCode.Space));
        yield return null;

        textbox.text = "こんにちは";
        yield return new WaitUntil(()=>Input.GetKeyDown(KeyCode.Space));
        yield return null;

        textbox.text = "さようなら";
        yield return new WaitUntil(()=>Input.GetKeyDown(KeyCode.Space));
        yield return null;
    }

    //会話が終われば戦闘シーンへ移動
    SceneManager.LoadScene("Scenes/OkayamaTestScene");
}
