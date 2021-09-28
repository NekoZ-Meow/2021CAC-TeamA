using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TitleOptionButton : TitleButton
{
    [SerializeField] GameObject OptionUI;
    protected override IEnumerator Routine()
    {
        while (true)
        {
            if (Input.GetButtonDown(InputAxes.Shot))
            {
                this.controller.IsMovable = false;
                this.OptionUI.SetActive(true);
            }
            if (Input.GetButtonDown(InputAxes.Cancel))
            {
                this.controller.IsMovable = true;
                this.OptionUI.SetActive(false);
            }
            yield return null;
        }
    }

}
