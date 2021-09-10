using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private bool isWaitInterval = false;
    private PlayerStatus playerStatus;
    private PlayerShootingController shootingController;

    // Start is called before the first frame update
    private void Start()
    {
        this.playerStatus = this.GetComponent<PlayerStatus>();
        this.shootingController = this.GetComponent<PlayerShootingController>();
        return;
    }

    private void Move(float xAxis, float yAxis)
    {
        if (xAxis == 0 && yAxis == 0) return;
        if (!this.playerStatus.CanMove) return;

        float rad = Mathf.Atan2(yAxis, xAxis);
        float xMove = this.playerStatus.MoveSpeed * Mathf.Cos(rad);
        float yMove = this.playerStatus.MoveSpeed * Mathf.Sin(rad);
        Vector2 movedPosition = this.transform.position + new Vector3(xMove * Time.deltaTime, yMove * Time.deltaTime, 0);
        if (!(this.playerStatus.MovableArea.TopLeft.x <= movedPosition.x && movedPosition.x <= this.playerStatus.MovableArea.BottomRight.x)) xMove = 0;
        if (!(this.playerStatus.MovableArea.BottomRight.y <= movedPosition.y && movedPosition.y <= this.playerStatus.MovableArea.TopLeft.y)) yMove = 0;
        this.transform.Translate(xMove * Time.deltaTime, yMove * Time.deltaTime, 0, Space.World);
        return;
    }

    private void Shot()
    {
        if (this.isWaitInterval || !this.playerStatus.CanShoot)
        {
            return;
        }
        this.playerStatus.Shooting.Shoot();
        this.StartCoroutine(this.WaitInterval());

        return;
    }

    private IEnumerator WaitInterval()
    {
        this.isWaitInterval = true;
        yield return new WaitForSeconds(this.playerStatus.ShotInterval);
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
        if (Input.GetKey(KeyCode.R))
        {
            this.shootingController.ChangeShootingSystem(PlayerShooting.Missile);
        }
        if (Input.GetKey(KeyCode.E))
        {
            this.shootingController.ChangeShootingSystem(PlayerShooting.Normal);
        }

        this.Move(xAxis, yAxis);
    }
}
