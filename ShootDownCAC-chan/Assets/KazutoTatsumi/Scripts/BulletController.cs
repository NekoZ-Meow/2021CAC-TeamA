using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour
{
    [SerializeField] private float speed = 5; //弾丸の速度

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 bulletPos = transform.position;
        bulletPos.y += speed * Time.deltaTime;
        this.transform.position = bulletPos;
    }
}
