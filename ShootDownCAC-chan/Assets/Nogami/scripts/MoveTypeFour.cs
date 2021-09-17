using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveTypeFour : MonoBehaviour
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
    private bool countup = true;
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
    /// ��ʊO���珉���ʒu�Ɉړ�����
    /// </summary>
    private void Firstmove()
    {
        this.gameObject.transform.position = Vector2.SmoothDamp(this.transform.position, firstposition, ref velocity, firstmovespeed);
        if (this.gameObject.transform.position.y - 0.5f <= firstposition.y) endfirstmove = false;
    }
    /// <summary>
    /// �w�肵���ʒu�����ԂɈړ�����
    /// </summary>
    private void Secondmove()
    {
        this.gameObject.transform.position = Vector2.MoveTowards(this.gameObject.transform.position, secondposition[movecount], secondmovespeed);
        if (this.gameObject.transform.position.Equals(secondposition[movecount]))
        {
            if (countup == true) movecount++;
            else movecount--;
            if (movecount == secondposition.Count - 1) countup = false;
            else if (movecount == 0) countup = true;
        } 
    }
}
