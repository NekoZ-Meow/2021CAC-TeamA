using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{
    [SerializeField] private Text scoreValue;
    [SerializeField] private Text weaponName;
    [SerializeField] private GameObject StageUI;
    [SerializeField] private GameObject StageBackGround;
    [SerializeField] private GameObject OptionUI;
    private GameManager gameManager;
    private Text stageTitle;

    // Start is called before the first frame update
    void Start()
    {
        this.gameManager = GameObject.FindWithTag(Tags.GAME_MANAGER).GetComponent<GameManager>();
        this.stageTitle = Resources.Load<Text>("Text/StageTitle");
    }

    /// <summary>
    /// スコアをセットする
    /// </summary>
    /// <param name="score">スコア</param>
    public void SetScoreValue(int score)
    {
        this.scoreValue.text = string.Format("{0:000000}", score);

        return;
    }

    /// <summary>
    /// 武器名をセットする
    /// </summary>
    /// <param name="name">武器名</param>
    public void SetWeaponName(string name)
    {
        this.weaponName.text = name;

        return;
    }

    /// <summary>
    /// オプションを表示する
    /// /// </summary>
    public void ShowOption()
    {
        this.OptionUI.SetActive(true);
        return;
    }

    /// <summary>
    /// オプションを非表示にする
    /// /// </summary>
    public void HideOption()
    {
        this.OptionUI.SetActive(false);
        return;
    }

    /// <summary>
    /// オプションが表示されているなら非表示へ
    /// 非表示なら表示する
    /// </summary>
    public void SwitchOption()
    {
        this.OptionUI.SetActive(!this.OptionUI.activeSelf);
        return;
    }

    public void SetStageBackGround(bool value)
    {
        this.StageBackGround.SetActive(value);
        return;
    }

    public IEnumerator ShowCharactorCenter(Image charactor)
    {
        this.SetStageBackGround(true);
        BoxArea playableArea = AreaUtility.GetPlayableArea();
        Vector2 titlePosition = playableArea.TopLeft + new Vector2(playableArea.GetWidth() / 2, playableArea.GetHeight() / 3);
        titlePosition.Scale(new Vector2(1, -1));
        Vector2 screenPosition = Camera.main.WorldToScreenPoint(titlePosition);
        Vector2 centerPosition = screenPosition - new Vector2(Screen.width / 2, -Screen.height / 2);

        Image createdCharactor = Object.Instantiate<Image>(charactor, parent: this.StageUI.transform);
        createdCharactor.rectTransform.anchoredPosition = screenPosition - new Vector2(Screen.width, -Screen.height / 2);
        Vector2 smoothVelocity = Vector2.zero;
        while (true)
        {
            createdCharactor.rectTransform.anchoredPosition = Vector2.SmoothDamp(createdCharactor.rectTransform.anchoredPosition, centerPosition, ref smoothVelocity, 0.5f);
            if (createdCharactor.rectTransform.anchoredPosition == centerPosition) break;
            yield return new WaitForEndOfFrame();
        }
        yield return null;
    }

    /// <summary>
    /// ステージタイトルを表示する
    /// </summary>
    public IEnumerator ShowStageTitle(string title)
    {
        BoxArea playableArea = AreaUtility.GetPlayableArea();
        Vector2 titlePosition = playableArea.TopLeft + new Vector2(playableArea.GetWidth() / 2, playableArea.GetHeight() / 3);
        titlePosition.Scale(new Vector2(1, -1));

        Text createdStageTitle = Object.Instantiate<Text>(this.stageTitle, parent: this.StageUI.transform);
        Vector2 screenPosition = Camera.main.WorldToScreenPoint(titlePosition);
        screenPosition -= new Vector2(Screen.width / 2, -Screen.height / 2);

        //float scaleFactor = this.StageUI.GetComponent<Canvas>().scaleFactor;

        createdStageTitle.rectTransform.anchoredPosition = screenPosition;
        createdStageTitle.text = title;

        Animator animator = createdStageTitle.GetComponent<Animator>();

        yield return new WaitUntil(() => animator.GetCurrentAnimatorStateInfo(0).normalizedTime >= 1);
    }
}
