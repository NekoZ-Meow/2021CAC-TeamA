using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
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
        this.shooting = new NormalBullet(this.gameObject, bullet);
    }

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;
        if(intervaltime <= time)
        {
            time = 0;
            this.shooting.Shoot();
        }
    }
}
