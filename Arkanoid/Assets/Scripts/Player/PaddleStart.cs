using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaddleStart : MonoBehaviour
{
    List<Bouncy> Balls = new List<Bouncy>();
    public string ballTag = "Ball";
    // Use this for initialization
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            foreach (var b in Balls)
            {
                b.transform.SetParent(null);
                b.setNewDirection();
                b.isStuck = false;
            }
            Destroy(this);
        }
    }
    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.transform.tag == ballTag)
        {
            var bouncy = col.transform.GetComponent<Bouncy>();
            var rb = col.transform.GetComponent<Rigidbody2D>();
            if (rb.velocity.y > 0)
            {
                col.transform.SetParent(transform);
                bouncy.isStuck = true;
                Balls.Add(bouncy);
                rb.velocity = Vector2.zero;
            }

        }
    }
}
