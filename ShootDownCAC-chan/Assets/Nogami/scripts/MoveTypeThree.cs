using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveTypeThree : MonoBehaviour
{
    [SerializeField]
    private float firstmovespeed;
    [SerializeField]
    private float secondmovespeed;
    [SerializeField]
    private Vector2 firstposition;
    [SerializeField]
    private List<Vector2> secondposition = new List<Vector2>();
    private Vector2 velocity = Vector2.zero;
    private bool endfirstmove = true;
    private int movecount = 0;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    private void FixedUpdate()
    {
        if (endfirstmove == true)
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
    /// 指定した位置を順番に移動したのち直線に移動する
    /// </summary>
    private void Secondmove()
    {
        if(movecount < secondposition.Count)
        {
            this.gameObject.transform.position = Vector2.MoveTowards(this.gameObject.transform.position, secondposition[movecount], secondmovespeed);
            if (this.gameObject.transform.position.Equals(secondposition[movecount])) movecount++;
        }
        else
        {
            this.gameObject.transform.position = new Vector2(this.transform.position.x, this.transform.position.y - secondmovespeed);
        }
    }
}
