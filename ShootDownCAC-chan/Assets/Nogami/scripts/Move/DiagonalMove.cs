using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// /指定したx座標を交互に斜め移動をしながら進む
/// </summary>
public class DiagonalMove : MonoBehaviour
{
    [SerializeField]
    private float firstmovespeed;
    [SerializeField]
    private float secondmovespeed;
    [SerializeField]
    private Vector2 firstposition;
    [SerializeField]
    private float plusxposition;
    [SerializeField]
    private float minusxposition;
    private Vector2 velocity = Vector2.zero;
    private bool endfirstmove = true;
    private bool boolonex = true;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    private void FixedUpdate()
    {
        if(endfirstmove == true)
        {
            this.Firstmove();
        }
        else
        {
            this.Secondmove();
        }
    }
    /// <summary>
    /// 画面外から初期位置に移動する
    /// </summary>
    private void Firstmove()
    {
        this.gameObject.transform.position = Vector2.SmoothDamp(this.transform.position, firstposition, ref velocity, firstmovespeed * Time.fixedDeltaTime);
        if (this.gameObject.transform.position.y - 0.5f <= firstposition.y) endfirstmove = false;
    }
    /// <summary>
    /// 左右交互の移動しながら進む
    /// </summary>
    private void Secondmove()
    {
        if(boolonex == true)
        {
            this.gameObject.transform.position = new Vector2(this.transform.position.x + (secondmovespeed * Time.fixedDeltaTime), this.transform.position.y - (secondmovespeed * Time.fixedDeltaTime) / 5f);
            if (this.gameObject.transform.position.x >= plusxposition) boolonex = false;
        }
        else
        {
            this.gameObject.transform.position = new Vector2(this.transform.position.x - (secondmovespeed * Time.fixedDeltaTime), this.transform.position.y - (secondmovespeed * Time.fixedDeltaTime) / 5f);
            if (this.gameObject.transform.position.x <= minusxposition) boolonex = true;
        }
    }
}
