using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{
    [SerializeField] private Text scoreValue;
    [SerializeField] private Text weaponName;
    // Start is called before the first frame update
    void Start()
    {

    }

    public void SetScoreValue(int score)
    {
        this.scoreValue.text = score.ToString();

        return;
    }

    public void SetWeaponName(string name)
    {
        this.weaponName.text = name;

        return;
    }
}
