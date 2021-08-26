using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player_controll : MonoBehaviour
{
    // Start is called before the first frame update

    Vector3 pos; //プレイヤーの座標を保持する変数
    [SerializeField] private GameObject bullet;
    [SerializeField] private Transform attackPoint;
    void Start()
    {
        pos = transform.position; //プレイヤーの現在座標を取得
    }

    // Update is called once per frame
    void Update()
    {
        float yoko = Input.GetAxis("Horizontal");
        float tate = Input.GetAxis("Vertical");
        pos.x += yoko;
        pos.y += tate;
        transform.position = pos;

        Attack();
    }

    void Attack() {
        if (Input.GetKeyDown(KeyCode.X)) {
            Instantiate(bullet, attackPoint.position, Quaternion.identity);
        }
    }
}
