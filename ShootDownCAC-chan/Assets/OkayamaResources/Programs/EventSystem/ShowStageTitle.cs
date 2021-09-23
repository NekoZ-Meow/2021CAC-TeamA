using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowStageTitle : Event
{
    private string title;
    private UIController uiController;
    // Start is called before the first frame update
    public ShowStageTitle(string title, string name = "ステージタイトル表示")
    {
        base.eventName = name;
        this.title = title;
        this.uiController = GameObject.FindWithTag(Tags.UI_CONTROLLER).GetComponent<UIController>();

    }

    public override IEnumerator Routine()
    {
        yield return this.uiController.ShowStageTitle(this.title);
    }
}
