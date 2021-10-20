using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowMessageWindowEvent : Event
{
    private UIController uiController;
    public ShowMessageWindowEvent(string name = "メッセージウィンドウ表示")
    {
        base.eventName = name;
        this.uiController = GameObject.FindWithTag(Tags.UI_CONTROLLER).GetComponent<UIController>();
        return;
    }
    public override IEnumerator Routine()
    {
        this.uiController.SetMessageWindow(true);
        yield return null;
    }
}
