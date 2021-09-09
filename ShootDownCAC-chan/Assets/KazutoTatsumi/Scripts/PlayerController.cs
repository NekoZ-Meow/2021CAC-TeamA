using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private float playerSpeed = 1.0f; //プレイヤーの移動速度
    [SerializeField] Vector3 playerPos;
    [SerializeField] private GameObject bullet;
    [SerializeField] private Transform attackPoint;

    [SerializeField] private float maxX, minX, maxY, minY; //移動制限範囲
    private void Start()
    {
        playerPos = transform.position;
    }

    // Update is called once per frame
    private void Update()
    {
        this.PlayerMove(); //プレイヤを動かすメソッド
        this.Attack(); //spaceを押されたら弾丸を発射するメソッド
        //this.PlayerLimit(); //移動制限メソッド
    }

    private void Attack() {
        if (Input.GetButton("Shot")) {
            Instantiate(this.bullet, this.attackPoint.position, Quaternion.identity);
        }
        return;
    }

    private void PlayerMove() {
        float xAxis = Input.GetAxisRaw("Horizontal");
        float yAxis = Input.GetAxisRaw("Vertical");
        playerPos.x += playerSpeed * xAxis * Time.deltaTime;
        playerPos.y += playerSpeed * yAxis * Time.deltaTime;
        this.transform.position = playerPos;
        this.PlayerLimit(playerPos);
        return;
    }

    private void PlayerLimit(Vector3 PlayerPos) {
        if(maxY < playerPos.y) {
            playerPos.y = maxY;
            this.transform.position = playerPos;
        }
        else if(minY > playerPos.y) {
            playerPos.y = minY;
            this.transform.position = playerPos;
        }
        else if(maxX < playerPos.x) {
            playerPos.x = maxX;
            this.transform.position = playerPos;
        }
        else if(minX > playerPos.x) {
            playerPos.x = minX;
            this.transform.position = playerPos;
        }
        return;
    }
}
