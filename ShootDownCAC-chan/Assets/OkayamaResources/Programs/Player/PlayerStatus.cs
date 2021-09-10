using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStatus : MonoBehaviour
{
    [SerializeField] private float hp { get; set; } = 0;
    [SerializeField] private float moveSpeed { get; set; } = 0.1f;
    [SerializeField] private bool canMove {get;set;} =true;
    [SerializeField] private Shooting shooting { get; set; }

    // Start is called before the first frame update
    void Start()
    {
        this.shooting = new DoubleNormalShooting(this.gameObject, new NormalBullet());
    }
}
