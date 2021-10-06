using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShowCharactorEvent : Event
{
    private Image charactor;
    private UIController uiController;
    public ShowCharactorEvent(Image charactor, string name = "キャラクター表示")
    {
        base.eventName = name;
        this.charactor = charactor;
        this.uiController = GameObject.FindWithTag(Tags.UI_CONTROLLER).GetComponent<UIController>();
        return;
    }

    public override IEnumerator Routine()
    {
        yield return this.uiController.ShowCharactorCenter(charactor);
    }
}
