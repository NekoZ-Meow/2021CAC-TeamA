using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class SEOption : OptionBase
{
    [SerializeField] private float volumeMax = 20; //デシベルなので注意
    [SerializeField] private float volumeMin = -80;//デシベルなので注意
    private UIController uiController;
    private GameManager gameManager;

    private Slider seSlider;

    private bool isLongPress = false;


    // Start is called before the first frame update
    void Start()
    {
        this.uiController = GameObject.FindWithTag(Tags.UI_CONTROLLER).GetComponent<UIController>();
        this.gameManager = GameObject.FindWithTag(Tags.GAME_MANAGER).GetComponent<GameManager>();
        this.seSlider = this.gameObject.GetComponentInChildren<Slider>();
        this.seSlider.maxValue = this.volumeMax;
        this.seSlider.minValue = this.volumeMin;
    }

    /// <summary>
    /// 初期化処理
    /// </summary>
    public override void initialize()
    {
        this.seSlider.value = this.gameManager.SEVolume;
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
                float nextVolume = Mathf.Clamp(this.gameManager.SEVolume - 1, this.volumeMin, this.volumeMax);
                this.seSlider.value = nextVolume;
                this.gameManager.SetSEVolume(nextVolume);
                this.isLongPress = true;
            }
            else
            {
                float nextVolume = Mathf.Clamp(this.gameManager.SEVolume + 1, this.volumeMin, this.volumeMax);
                this.seSlider.value = nextVolume;
                this.gameManager.SetSEVolume(nextVolume);
                this.isLongPress = true;
            }

        }
    }
}
