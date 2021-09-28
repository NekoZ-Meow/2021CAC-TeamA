using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// タイトルのスタートボタン
/// </summary>
public class StartButton : TitleButton
{
    protected override IEnumerator Routine()
    {
        yield return new WaitUntil(() => Input.GetButtonDown(InputAxes.Shot));
        SceneManager.LoadScene(SceneName.Stage1);
    }
}
