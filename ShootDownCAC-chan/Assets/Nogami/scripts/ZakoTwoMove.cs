using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZakoTwoMove : MonoBehaviour
{
    [SerializeField]
    private float movespeed;
    [SerializeField]
    private Vector2 firstposition;
    private Vector2 velocity = Vector2.zero;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Firstmove();
    }
    /// <summary>
    /// 画面外から初期位置に移動する
    /// </summary>
    private void Firstmove()
    {
        this.gameObject.transform.position = Vector2.SmoothDamp(this.transform.position, firstposition, ref velocity, movespeed);
    }
}
