using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveTypeTwo : MonoBehaviour
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
        this.gameObject.transform.position = Vector2.SmoothDamp(this.transform.position, firstposition, ref velocity, firstmovespeed);
        if (this.gameObject.transform.position.y - 0.5f <= firstposition.y) endfirstmove = false;
    }
    /// <summary>
    /// 左右交互の移動しながら進む
    /// </summary>
    private void Secondmove()
    {
        if(boolonex == true)
        {
            this.gameObject.transform.position = new Vector2(this.transform.position.x + secondmovespeed, this.transform.position.y - secondmovespeed / 5f);
            if (this.gameObject.transform.position.x >= plusxposition) boolonex = false;
        }
        else
        {
            this.gameObject.transform.position = new Vector2(this.transform.position.x - secondmovespeed, this.transform.position.y - secondmovespeed / 5f);
            if (this.gameObject.transform.position.x <= minusxposition) boolonex = true;
        }
    }
}
