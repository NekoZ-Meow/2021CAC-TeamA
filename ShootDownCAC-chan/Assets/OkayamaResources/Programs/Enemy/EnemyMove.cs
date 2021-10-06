using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMove : MonoBehaviour
{
    [SerializeField] private Queue<Vector2> moveQueue = new Queue<Vector2>(); //移動する座標のキュー
    [SerializeField] private Vector2 nextPosition; //次に移動する座標

    private bool isMoveFinished = false;
    private EnemyModel model;

    // Start is called before the first frame update
    void Start()
    {
        this.model = this.GetComponent<EnemyModel>();
        if (this.moveQueue.Count != 0)
        {
            this.nextPosition = this.moveQueue.Dequeue();
        }
        else
        {
            this.isMoveFinished = true;
        }

        return;
    }

    /// <summary>
    /// 移動点を追加する
    /// </summary>
    public void AddMovePoint(Vector2 point)
    {
        this.moveQueue.Enqueue(point);
        this.isMoveFinished = false;
        return;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (this.isMoveFinished)
        {
            if (!AreaUtility.GetPlayableArea().IsInTheArea(this.transform.position))
            {
                Object.Destroy(this.gameObject);
            }
            return;
        }
        float speed = this.model.MoveSpeed * Time.fixedDeltaTime;
        float diffX = this.nextPosition.x - this.transform.position.x;
        float diffY = this.nextPosition.y - this.transform.position.y;
        float direction = Mathf.Atan2(diffY, diffX);
        float rad = direction * Mathf.Deg2Rad;
        this.transform.position = Vector2.MoveTowards(this.transform.position, this.nextPosition, speed);

        if (this.nextPosition.Equals(this.transform.position))
        {
            if (this.moveQueue.Count == 0)
            {
                this.isMoveFinished = true;
                return;
            }
            this.nextPosition = this.moveQueue.Dequeue();
        }

        return;
    }
}
