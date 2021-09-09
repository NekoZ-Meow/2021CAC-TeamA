using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] float moveSpeed = 0.5f;
    [SerializeField] float shotInterval = 0.5f;

    private bool isWaitInterval = false;

    private Bullet bullet;

    private Shooting shooting;

    // Start is called before the first frame update
    private void Start()
    {
        this.shooting = new DoubleNormalShooting(this.gameObject, Bullets.GetNormalBullet(10, 20));
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
        Vector2 movedPosition = this.transform.position + new Vector3(xMove * Time.deltaTime, yMove * Time.deltaTime, 0);
        if (!(Areas.SCREEN_AREA.topLeft.x <= movedPosition.x && movedPosition.x <= Areas.SCREEN_AREA.bottomRight.x)) xMove = 0;
        if (!(Areas.SCREEN_AREA.bottomRight.y <= movedPosition.y && movedPosition.y <= Areas.SCREEN_AREA.topLeft.y)) yMove = 0;
        this.transform.position += new Vector3(xMove * Time.deltaTime, yMove * Time.deltaTime, 0);
        return;
    }

    private void Shot()
    {
        if (!this.isWaitInterval)
        {
            this.shooting.Shoot();
            //Instantiate(this.bullet, this.transform.position, this.transform.rotation);
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

    private void ChangeShooting()
    {
        if (this.shooting.GetType() == typeof(MultiHomingShooting))
        {
            return;
        }
        this.shooting = new MultiHomingShooting(this.gameObject, Bullets.GetHomingBullet(5, 15, 0, 15), 3);
    }


    // Update is called once per frame
    private void Update()
    {
        float xAxis = Input.GetAxis("Horizontal");
        float yAxis = Input.GetAxis("Vertical");
        if (Input.GetKey(KeyCode.R))
        {
            this.ChangeShooting();
        }
        if (Input.GetButton("Shot"))
        {
            this.Shot();
        }

        this.Move(xAxis, yAxis);
    }
}
