using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

/// <summary>
/// ゲームの情報を保存する
/// シングルトン
/// </summary>
public class GameManager : MonoBehaviour
{
    [SerializeField] private AudioMixer audioMixer;
    [SerializeField] private float bgmVolume = 0; //デシベル注意
    [SerializeField] private float seVolume = 0; //デシベル注意
    [SerializeField] private bool isPause = false; //ポーズ中か

    private static GameManager instance;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
        else
        {
            Destroy(this.gameObject);
        }
    }

    /// <summary>
    /// BGMのボリュームを設定する
    /// </summary>
    /// <param name="volume">音量</param>
    public void SetBGMVolume(float volume)
    {
        this.bgmVolume = volume;
        audioMixer.SetFloat(AudioMixserParam.BGMVolume, volume);

        return;
    }

    /// <summary>
    /// SEのボリュームを設定する
    /// </summary>
    /// <param name="volume">音量</param>
    public void SetSEVolume(float volume)
    {
        this.seVolume = volume;
        audioMixer.SetFloat(AudioMixserParam.SEVolume, volume);

        return;
    }

    /// <summary>
    /// 一時停止の開始、終了
    /// /// </summary>
    /// <param name="isPause"></param>
    public void SetPause(bool isPause)
    {
        this.isPause = isPause;
        if (isPause)
        {
            Time.timeScale = 0;
        }
        else
        {
            Time.timeScale = 1;
        }
    }

    public float BGMVolume
    {
        get { return this.bgmVolume; }
    }

    public float SEVolume
    {
        get { return this.seVolume; }
    }

    public bool IsPause
    {
        get { return this.isPause; }
    }
}
