﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// 2方向に攻撃を行うタイミングを設定する
/// </summary>
public class EnemyTwowayAttack : MonoBehaviour
{
    private float time = 0;
    [SerializeField]
    private float intervaltime;
    private float damage;
    private Shooting shooting;
    // Start is called before the first frame update
    void Start()
    {
        this.damage = this.GetComponent<EnemyStatus>().getDamage();
        this.shooting = new TwowayShooting(this.gameObject, Bullets.GetNormalBullet(10, 20));
    }

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;
        if (intervaltime <= time)
        {
            time = 0;
            this.shooting.Shoot();
        }
    }
}
