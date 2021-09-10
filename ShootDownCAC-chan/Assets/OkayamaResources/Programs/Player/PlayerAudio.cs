using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class PlayerAudio : MonoBehaviour
{
    [SerializeField] Sounds sounds;

    private AudioSource audioSource;

    [System.SerializableAttribute]
    class Sounds
    {
        public AudioClip lockOn;
    }

    void Start()
    {
        this.audioSource = this.GetComponent<AudioSource>();
    }

    /// <summary>
    /// ロックオンの音を再生する
    /// </summary>
    public void PlayLockOnSound()
    {
        this.audioSource.PlayOneShot(this.sounds.lockOn);
    }
}
