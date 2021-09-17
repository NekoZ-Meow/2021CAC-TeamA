using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveTypeOne : MonoBehaviour
{
    [SerializeField]
    private float movespeed;
    private Vector2 velocity = Vector2.zero;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Straightmove();
    }
    /// <summary>
    /// 画面外から直進する
    /// </summary>
    private void Straightmove()
    {
        this.gameObject.transform.position = new Vector2(this.transform.position.x, this.transform.position.y - movespeed);
    }
}
