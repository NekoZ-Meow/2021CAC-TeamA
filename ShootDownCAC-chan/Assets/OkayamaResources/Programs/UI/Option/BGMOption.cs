using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// BGMのオプションを管理する
/// </summary>
public class BGMOption : OptionBase
{
    [SerializeField] private float volumeMax = 20; //デシベルなので注意
    [SerializeField] private float volumeMin = -80;//デシベルなので注意
    private Slider bgmSlider;
    private GameManager gameManager;

    private bool isLongPress = false;

    /// <summary>
    /// 初期化処理
    /// </summary>
    public override void initialize()
    {
        this.gameManager = GameObject.FindWithTag(Tags.GAME_MANAGER).GetComponent<GameManager>();
        this.bgmSlider = this.gameObject.GetComponentInChildren<Slider>();
        this.bgmSlider.maxValue = this.volumeMax;
        this.bgmSlider.minValue = this.volumeMin;
        this.bgmSlider.value = this.gameManager.BGMVolume;
        return;
    }

    protected override IEnumerator Routine()
    {
        while (true)
        {

            if (this.isLongPress)
            {
                yield return new WaitForSecondsRealtime(0.01f);
            }
            else
            {
                yield return new WaitForEndOfFrame();
            }

            float xAxis = Input.GetAxisRaw("Horizontal");
            if (xAxis == 0)
            {
                this.isLongPress = false;

            }
            else if (xAxis < 0)
            {
                float nextVolume = Mathf.Clamp(this.gameManager.BGMVolume - 1, this.volumeMin, this.volumeMax);
                this.bgmSlider.value = nextVolume;
                this.gameManager.SetBGMVolume(nextVolume);
                this.isLongPress = true;
            }
            else
            {
                float nextVolume = Mathf.Clamp(this.gameManager.BGMVolume + 1, this.volumeMin, this.volumeMax);
                this.bgmSlider.value = nextVolume;
                this.gameManager.SetBGMVolume(nextVolume);
                this.isLongPress = true;
            }

        }
    }
}
