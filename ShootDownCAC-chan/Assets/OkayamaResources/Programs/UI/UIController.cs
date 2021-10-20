using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Text;

public class UIController : MonoBehaviour
{
    [SerializeField] private Text scoreValue;
    [SerializeField] private Text weaponName;

    [SerializeField] private GameObject messageWindow;
    [SerializeField] private GameObject StageUI;
    [SerializeField] private GameObject StageBackGround;
    [SerializeField] private GameObject OptionUI;
    private GameManager gameManager;
    private Text stageTitle;
    private Text messageBody;
    private Text messageName;

    // Start is called before the first frame update
    void Start()
    {
        this.gameManager = GameObject.FindWithTag(Tags.GAME_MANAGER).GetComponent<GameManager>();
        this.stageTitle = Resources.Load<Text>("Text/StageTitle");
        this.messageBody = this.messageWindow.transform.Find("MessageBody").GetComponent<Text>();
        this.messageName = this.messageWindow.transform.Find("MessageName").GetComponent<Text>();
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

    public void SetMessageWindow(bool value)
    {
        this.messageWindow.SetActive(value);
        return;
    }

    public void SetMessageName(string name)
    {
        this.messageName.text = name;

        return;
    }

    /// <summary>
    /// メッセージウィンドウにメッセージを表示する
    /// </summary>
    /// <param name="message">メッセージ</param>
    /// <param name="speed">表示速度</param>
    /// <returns></returns>
    public IEnumerator ShowMessage(string message, float speed = 0.1f)
    {
        StringBuilder builder = new StringBuilder();
        bool allMessageDisplayed = false;

        IEnumerator SkipHandler()
        {
            while (!allMessageDisplayed)
            {
                if (Input.GetButtonDown(InputAxes.Shot))
                {
                    speed = 0;
                }
                yield return null;
            }
        }
        yield return new WaitForEndOfFrame();
        StartCoroutine(SkipHandler());
        foreach (char aChar in message)
        {
            builder.Append(aChar);
            this.messageBody.text = builder.ToString();
            yield return new WaitForSeconds(speed);
        }
        allMessageDisplayed = true;
        yield return new WaitUntil(() => Input.GetButtonDown(InputAxes.Shot));
    }

    /// <summary>
    /// キャラクターを中心に表示する
    /// </summary>
    /// <param name="charactor"></param>
    /// <returns></returns>
    public IEnumerator ShowCharactorCenter(Image charactor)
    {
        this.SetStageBackGround(true);
        BoxArea playableArea = AreaUtility.GetPlayableArea();
        Vector2 charactorPosition = playableArea.TopLeft + new Vector2(playableArea.GetWidth() / 2, playableArea.GetHeight() / 3);
        charactorPosition.Scale(new Vector2(1, -1));
        Vector2 screenPosition = Camera.main.WorldToScreenPoint(charactorPosition);
        Vector2 centerPosition = screenPosition - new Vector2(Screen.width / 2, -Screen.height / 1.8f);

        charactor.transform.SetParent(this.StageUI.transform, false);
        charactor.transform.position = new Vector3(0, 0, 0);
        charactor.rectTransform.anchoredPosition = screenPosition - new Vector2(Screen.width, -Screen.height / 1.8f);
        Vector2 smoothVelocity = Vector2.zero;
        while (true)
        {
            charactor.rectTransform.anchoredPosition = Vector2.SmoothDamp(charactor.rectTransform.anchoredPosition, centerPosition, ref smoothVelocity, 0.5f);
            if (smoothVelocity.magnitude < 1f)
            {
                charactor.rectTransform.anchoredPosition = centerPosition;
                break;
            }
            yield return new WaitForEndOfFrame();
        }
        yield return null;
    }

    /// <summary>
    /// キャラクターを退場させる
    /// </summary>
    /// <param name="charactor"></param>
    /// <returns></returns>
    public IEnumerator HideCharactorEvent(Image charactor)
    {
        BoxArea playableArea = AreaUtility.GetPlayableArea();
        Vector2 charactorPosition = playableArea.TopLeft + new Vector2(playableArea.GetWidth() / 2, playableArea.GetHeight() / 3);
        charactorPosition.Scale(new Vector2(1, -1));
        Vector2 screenPosition = Camera.main.WorldToScreenPoint(charactorPosition);
        Vector2 outPosition = screenPosition + new Vector2(Screen.width / 3, Screen.height / 1.8f);
        int speed = 100;
        while (true)
        {
            charactor.rectTransform.anchoredPosition = Vector2.MoveTowards(charactor.rectTransform.anchoredPosition, outPosition, speed * Time.deltaTime);
            if (charactor.rectTransform.anchoredPosition.Equals(outPosition))
            {
                break;
            }
            speed += 100;
            yield return new WaitForEndOfFrame();
        }
        Object.Destroy(charactor.gameObject);
        this.SetStageBackGround(false);
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
