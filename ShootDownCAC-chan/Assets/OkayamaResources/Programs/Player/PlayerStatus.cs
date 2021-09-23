using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStatus : MonoBehaviour
{
    [SerializeField] private float hp = 0;
    [SerializeField] private float moveSpeed = 5f;
    [SerializeField] private float damageRate = 1f;
    [SerializeField] float shotInterval = 0.1f;
    [SerializeField] private bool canMove = true;
    [SerializeField] private bool canShoot = true;
    [SerializeField] private Shooting shooting;
    [SerializeField] private BoxArea playerMovableArea;
    public int score { get; set; } = 0; //消す！！
    private SpriteRenderer spriteRenderer;

    // Start is called before the first frame update
    void Start()
    {
        this.spriteRenderer = this.GetComponent<SpriteRenderer>();
        Vector3 imageSize = this.spriteRenderer.bounds.size;
        this.playerMovableArea = Areas.SCREEN_AREA;
        this.playerMovableArea.ChangeWidth(this.playerMovableArea.GetWidth() * 0.7f - imageSize.x);
        this.playerMovableArea.ChangeHeight(this.playerMovableArea.GetHeight() - imageSize.y);
        this.playerMovableArea.Transform(imageSize.x / 2, -imageSize.y / 2);

        return;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == Tags.ENEMY_BULLET)
        {
            this.Hp -= collision.GetComponent<Bullet>().Damage;
        }
    }

    public float Hp
    {
        get { return this.hp; }
        set { this.hp = value; }
    }

    public float MoveSpeed
    {
        get { return this.moveSpeed; }
        set { this.moveSpeed = value; }
    }

    public float ShotInterval
    {
        get { return this.shotInterval; }
        set { this.shotInterval = value; }
    }

    public bool CanMove
    {
        get { return this.canMove; }
        set { this.canMove = value; }
    }
    public bool CanShoot
    {
        get { return this.canShoot; }
        set { this.canShoot = value; }
    }

    public Shooting Shooting
    {
        get { return this.shooting; }
        set { this.shooting = value; }
    }

    public BoxArea MovableArea
    {
        get { return this.playerMovableArea; }
    }
}
