using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HideCharactorEvent : Event
{
    private Image charactor;
    private UIController uiController;
    public HideCharactorEvent(Image charactor, string name = "キャラクター非表示")
    {
        base.eventName = name;
        this.charactor = charactor;
        this.uiController = GameObject.FindWithTag(Tags.UI_CONTROLLER).GetComponent<UIController>();
        return;
    }
    public override IEnumerator Routine()
    {
        yield return this.uiController.HideCharactorEvent(this.charactor);
    }
}
