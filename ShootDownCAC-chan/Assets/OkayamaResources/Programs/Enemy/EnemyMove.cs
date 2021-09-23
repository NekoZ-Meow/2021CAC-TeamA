using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMove : MonoBehaviour
{
    [SerializeField] float direction = 270;
    [SerializeField] float speed = 5f;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        float rad = this.direction * Mathf.Deg2Rad;
        float x = this.speed * Mathf.Cos(rad) * Time.fixedDeltaTime;
        float y = this.speed * Mathf.Sin(rad) * Time.fixedDeltaTime;
        this.transform.Translate(x, y, 0);

        if (this.transform.position.y < Areas.SCREEN_AREA.BottomRight.y - 2)
        {
            Destroy(this.gameObject);
        }
    }

    public float Direction
    {
        get { return this.direction; }
        set { this.direction = value; }
    }
    public float Speed
    {
        get { return this.speed; }
        set { this.speed = value; }
    }
}
