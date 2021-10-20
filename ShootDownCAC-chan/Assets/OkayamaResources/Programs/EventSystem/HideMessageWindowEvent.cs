using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HideMessageWindowEvent : Event
{
    private UIController uiController;
    public HideMessageWindowEvent(string name = "メッセージウィンドウ非表示")
    {
        base.eventName = name;
        this.uiController = GameObject.FindWithTag(Tags.UI_CONTROLLER).GetComponent<UIController>();
        return;
    }
    public override IEnumerator Routine()
    {
        this.uiController.SetMessageWindow(false);
        yield return null;
    }
}
