using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] float moveSpeed = 0.5f;
    [SerializeField] float shotInterval = 0.5f;

    private bool isWaitInterval = false;

    private GameObject bullet;

    private Shooting shooting;
    // Start is called before the first frame update
    private void Start()
    {
        this.bullet = Resources.Load<GameObject>("Bullet/NormalBullet");
        this.shooting = new NormalShooting(this.gameObject, this.bullet);
        return;
    }

    private void Move(float xAxis, float yAxis)
    {
        if (xAxis == 0 && yAxis == 0)
        {
            return;
        }
        float rad = Mathf.Atan2(yAxis, xAxis);
        float xMove = this.moveSpeed * Mathf.Cos(rad);
        float yMove = this.moveSpeed * Mathf.Sin(rad);
        this.transform.Translate(xMove, yMove, 0);

        return;
    }

    private void Shot()
    {
        if (!this.isWaitInterval)
        {
            this.shooting.Shoot();
            this.StartCoroutine(this.WaitInterval());
        }
        return;
    }

    private IEnumerator WaitInterval()
    {
        this.isWaitInterval = true;
        yield return new WaitForSeconds(this.shotInterval);
        this.isWaitInterval = false;
        yield break;
    }


    // Update is called once per frame
    private void Update()
    {
        float xAxis = Input.GetAxis("Horizontal");
        float yAxis = Input.GetAxis("Vertical");
        if (Input.GetButton("Shot"))
        {
            this.Shot();
        }

        this.Move(xAxis, yAxis);
    }
}
