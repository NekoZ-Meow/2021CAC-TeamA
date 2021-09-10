using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// プレイヤーの射撃を管理する
/// </summary>
public class PlayerShootingController : MonoBehaviour
{
    [SerializeField] private PlayerShooting nowShooting;
    private PlayerStatus playerStatus;

    private PlayerShootingAnimation shootingAnimation;

    private UIController uiController;


    // Start is called before the first frame update
    void Start()
    {
        this.playerStatus = this.GetComponent<PlayerStatus>();
        this.shootingAnimation = this.GetComponent<PlayerShootingAnimation>();
        this.uiController = GameObject.FindWithTag(Tags.UI_CONTROLLER).GetComponent<UIController>();
        this.ChangeNormalShooting();

        return;
    }

    /// <summary>
    /// プレイヤーの射撃を切り替える
    /// </summary>
    /// <param name="kindOfShooting">射撃の種類</param>
    public void ChangeShootingSystem(PlayerShooting kindOfShooting)
    {
        if (this.nowShooting == kindOfShooting) return;
        this.nowShooting = kindOfShooting;
        this.shootingAnimation.StopAnimation();
        switch (kindOfShooting)
        {
            case PlayerShooting.Normal:
                this.ChangeNormalShooting();
                break;
            case PlayerShooting.Missile:
                this.ChangeMissileShooting();
                break;
        }
    }

    /// <summary>
    /// ノーマル射撃に変化する
    /// </summary>
    private void ChangeNormalShooting()
    {
        uiController.SetWeaponName("Normal");
        this.playerStatus.Shooting = new DoubleNormalShooting(this.gameObject, Bullets.GetNormalBullet());
        this.playerStatus.ShotInterval = 0.1f;

        return;
    }

    /// <summary>
    /// 誘導射撃に変化する
    /// </summary>
    private void ChangeMissileShooting()
    {
        float maxDistance = 8;
        int targetNumber = 5;
        uiController.SetWeaponName("Multi Missile");
        this.playerStatus.Shooting = new PlayerMissileShooting(this.gameObject, Bullets.GetMissile(30, 20, 0, 15), Tags.ENEMY,
                                                                targetNumber: targetNumber, maxDistance: maxDistance, waitTime: 0.05f);
        this.playerStatus.ShotInterval = 0.5f;
        this.shootingAnimation.StartLockOnAnimation(targetNumber, maxDistance);

        return;
    }
}

/// <summary>
/// 射撃の種類
/// </summary>
public enum PlayerShooting
{
    Normal,
    Homing,
    Missile,
}