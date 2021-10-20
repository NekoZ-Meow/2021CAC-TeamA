using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetPlayerStatusEvent : Event
{
    private PlayerStatus playerStatus;
    private bool canShot;
    private bool canMove;
    public SetPlayerStatusEvent(bool canShot, bool canMove, string name = "プレイヤー状態変更")
    {
        base.eventName = name;
        this.canMove = canMove;
        this.canShot = canShot;
        this.playerStatus = GameObject.FindWithTag(Tags.PLAYER).GetComponent<PlayerStatus>();
        return;
    }

    public override IEnumerator Routine()
    {
        this.playerStatus.CanMove = this.canMove;
        this.playerStatus.CanShoot = this.canShot;
        yield return null;
    }
}
