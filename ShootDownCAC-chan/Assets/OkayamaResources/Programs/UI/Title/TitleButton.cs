using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// タイトルボタンの抽象クラス
/// </summary>
public abstract class TitleButton : OptionBase
{
    protected Animator animator;

    public override void initialize()
    {
        this.animator = this.GetComponent<Animator>();
    }

    public override void onSelected(OptionController controller)
    {
        base.onSelected(controller);
        this.animator.SetBool("isSelected", true);
    }

    public override void dispose()
    {
        base.dispose();
        this.animator.SetBool("isSelected", false);

    }
}
