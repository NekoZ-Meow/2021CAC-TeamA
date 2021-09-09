using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStatusTest : MonoBehaviour
{
    [SerializeField] private float hp = 0;
    [SerializeField] private Shooting shooting;
    // Start is called before the first frame update
    void Start()
    {
        this.shooting = new ThreewayShooting(this.gameObject, Resources.Load<Bullet>("Bullet/NormalBullet"));
    }

    public Shooting Shooting
    {
        get { return this.shooting; }
        set { this.shooting = value; }
    }
}
