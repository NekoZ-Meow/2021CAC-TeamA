using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NormalBullet : Bullet
{
    protected override void Move()
    {
        float rad = base.moveDirection * Mathf.Deg2Rad;
        float xMove = base.moveSpeed * Mathf.Cos(rad);
        float yMove = base.moveSpeed * Mathf.Sin(rad);
        this.transform.Translate(xMove, yMove, 0);

        return;
    }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        this.Move();
    }
}
