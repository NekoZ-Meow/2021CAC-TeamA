using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowMessageEvent : Event
{
    private UIController uiController;
    private string messageName;
    private string messageBody;
    private float speed;
    public ShowMessageEvent(string messageBody, string messageName, float speed = 0.1f, string name = "メッセージ表示")
    {
        base.eventName = name;
        this.messageBody = messageBody;
        this.messageName = messageName;
        this.speed = speed;
        this.uiController = GameObject.FindWithTag(Tags.UI_CONTROLLER).GetComponent<UIController>();
        return;
    }
    public override IEnumerator Routine()
    {
        this.uiController.SetMessageName(this.messageName);

        yield return this.uiController.ShowMessage(this.messageBody, this.speed);
    }
}
