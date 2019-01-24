using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaddleStickyPowerUp : MonoBehaviour 
{
    List<Bouncy> Balls = new List<Bouncy>();
    Bouncy[] allBalls;
    public string ballTag = "Ball";
    public float aliveTime;
    private float startTime;
    // Use this for initialization
    void Start()
    {
        allBalls = UnityEngine.Object.FindObjectsOfType<Bouncy>();
        setHaloEffectOnBall(true);
        startTime = 0;
    }
    public void restartTimer()
    {
        startTime = 0;
    }

    // Update is called once per frame
    void Update()
    {

        if (startTime < aliveTime)
        {
            startTime += Time.deltaTime;
        }
        else
        {
            setHaloEffectOnBall(false);
            foreach (var b in Balls)
            {
                b.transform.SetParent(null);
                b.setNewDirection();
                b.isStuck = false;
            }
            Destroy(this);
        }

        if (Input.GetButtonDown("Fire1"))
        {
            foreach (var b in Balls)
            {
                b.transform.SetParent(null);
                b.setNewDirection();
                b.isStuck = false;
                /*if (b.isInWall)
                {
                    Debug.Log("getchanceandluck");
                    b.BounceLeftAndRight();
                    b.isInWall = false;
                }*/
            }

        }
    }

    void setHaloEffectOnBall(bool onOrOff)
    {
        foreach (var ball in allBalls)
        {
            ball.gameObject.GetComponent("Halo").GetType().GetProperty("enabled").SetValue(ball.gameObject.GetComponent("Halo"), onOrOff, null);
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
