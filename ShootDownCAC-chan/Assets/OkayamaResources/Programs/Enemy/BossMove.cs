using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(BossAttack))]
public class BossMove : MonoBehaviour
{


    private BossAttack bossAttack;

    private BoxArea playableArea;

    private List<Vector2> positions = new List<Vector2>();

    private int positionIndex = 0;

    private EnemyModel model;

    // Start is called before the first frame update
    void Start()
    {
        this.bossAttack = this.GetComponent<BossAttack>();
        this.model = this.GetComponent<EnemyModel>();
        this.playableArea = AreaUtility.GetPlayableArea();
        Vector2 topPosition = new Vector2(this.playableArea.TopLeft.x + this.playableArea.GetWidth() / 2, this.playableArea.TopLeft.y / 1.5f);
        this.positions.Add(topPosition);
        float diffX = 3.5f;
        float diffY = 3f;
        this.positions.Add(topPosition - new Vector2(diffX, diffY));
        this.positions.Add(topPosition - new Vector2(-diffX, diffY));



        StartCoroutine(this.Move());
    }
    private IEnumerator Move()
    {
        while (true)
        {
            if (!this.model.CanMove)
            {
                yield return new WaitForEndOfFrame();
                continue;
            }
            Vector2 nextPosition = this.positions[this.positionIndex];
            Vector2 currentVelocity = Vector2.zero;
            while (true)
            {
                if (!this.model.CanMove)
                {
                    yield return new WaitForEndOfFrame();
                    continue;
                }
                this.transform.position = Vector2.SmoothDamp(this.transform.position, nextPosition, ref currentVelocity, 1f);
                if (currentVelocity.magnitude < 0.01f)
                {
                    break;
                }
                yield return new WaitForEndOfFrame();
            }
            this.positionIndex = (this.positionIndex + 1) % this.positions.Count;
            yield return new WaitForSeconds(2);
        }
    }

}
