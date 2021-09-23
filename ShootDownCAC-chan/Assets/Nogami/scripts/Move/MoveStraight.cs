using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// 直線に移動する
/// </summary>
public class MoveStraight : MonoBehaviour
{
    [SerializeField]
    private float movespeed;
    private Vector2 velocity = Vector2.zero;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Straightmove();
    }
    /// <summary>
    /// 画面外から直進する
    /// </summary>
    private void Straightmove()
    {
        this.gameObject.transform.position = new Vector2(this.transform.position.x, this.transform.position.y - movespeed * Time.fixedDeltaTime);
    }
}
