using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetBossStatusEvent : Event
{
    [SerializeField] private GameObject boss;
    private bool canAttack = false;
    private bool canMove = false;
    public SetBossStatusEvent(GameObject boss, bool canAttack, bool canMove, string name = "ボスステータス変更")
    {
        this.boss = boss;
        this.canAttack = canAttack;
        this.canMove = canMove;
        return;
    }

    public override IEnumerator Routine()
    {
        EnemyModel enemyModel = this.boss.GetComponent<EnemyModel>();
        enemyModel.CanAttack = this.canAttack;
        enemyModel.CanMove = this.canMove;
        yield break;
    }
}
