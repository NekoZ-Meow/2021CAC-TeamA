using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bullet_controll : MonoBehaviour
{
    [SerializeField] private float speed = 5; //bullet speed

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 bulletPos = transform.position; //現在座標を取得
        bulletPos.y += speed * Time.deltaTime; //y座標にspeedを加算する
        transform.position = bulletPos; //現在座標を更新
    }
}
