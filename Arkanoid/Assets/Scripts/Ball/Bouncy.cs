using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bouncy : MonoBehaviour
{
    public float speed = 20;
    [HideInInspector] public Vector2 dir;
    [HideInInspector] public Rigidbody2D rb;
    public string paddleTag = "Paddle";
    public Vector2 startdirection;
    // private int vertical = 0;
    //private int horizontal = 0;
    // private float shortestRay = 0;
    [HideInInspector] public bool isStuck = false;
    private GameObject player;
    //[HideInInspector] public bool isInWall = false;
    // public LayerMask notIgnoreLayer;
    void Start()
    {
        dir = startdirection;
        rb = GetComponent<Rigidbody2D>();
        setNewDirection();
        gameObject.GetComponent("Halo").GetType().GetProperty("enabled").SetValue(gameObject.GetComponent("Halo"), false, null);
        player = GameObject.FindGameObjectWithTag(paddleTag);
    }

   /* void BounceUpAndDown()
    {
        dir.Set(dir.x, -dir.y);
        setNewDirection();
    }

    public void BounceLeftAndRight()
    {
        dir.Set(-dir.x, dir.y);
        setNewDirection();
    }*/


    public void setNewDirection()
    {
        dir.Normalize();
        rb.velocity = Vector2.zero;
        rb.velocity = dir * speed;
    }
        void Update()
    {
       // Physics2D.IgnoreCollision(player.GetComponent<Collider2D>(), GetComponent<Collider2D>());
    }


    void OnCollisionEnter2D(Collision2D other)
    {
        float angleTopOrBottom = 0;
        float angleLeftOrRight = 0;
        if (!isStuck) {
            if (other.transform.tag != paddleTag) {
                if (Vector2.Angle(other.contacts[0].normal, Vector2.down) < Vector2.Angle(other.contacts[0].normal, Vector2.up))
                {
                    angleTopOrBottom = Vector2.Angle(other.contacts[0].normal, Vector2.down);
                }
                else
                {
                    angleTopOrBottom = Vector2.Angle(other.contacts[0].normal, Vector2.up);
                }
                if (Vector2.Angle(other.contacts[0].normal, Vector2.left) < Vector2.Angle(other.contacts[0].normal, Vector2.right))
                {
                    angleLeftOrRight = Vector2.Angle(other.contacts[0].normal, Vector2.left);
                }
                else
                {
                    angleLeftOrRight = Vector2.Angle(other.contacts[0].normal, Vector2.right);
                }
                if (angleTopOrBottom < angleLeftOrRight)
                {
                    float top = Vector2.Angle(other.contacts[0].normal, Vector2.up);
                    float bottom = Vector2.Angle(other.contacts[0].normal, Vector2.down);
                    if (top < bottom)
                    {
                        dir.Set(dir.x, Mathf.Abs(dir.y));
                        setNewDirection();
                    }
                    else
                    {
                        dir.Set(dir.x, -Mathf.Abs(dir.y));
                        setNewDirection();
                    }
                }
                else
                {
                    float left = Vector2.Angle(other.contacts[0].normal, Vector2.left);
                    float right = Vector2.Angle(other.contacts[0].normal, Vector2.right);
                    if (left < right)
                    {
                        dir.Set(-Mathf.Abs(dir.x), dir.y);
                        setNewDirection();
                    }
                    else
                    {
                        dir.Set(Mathf.Abs(dir.x), dir.y);
                        setNewDirection();
                    }
                }
            }
        }
    }
}
