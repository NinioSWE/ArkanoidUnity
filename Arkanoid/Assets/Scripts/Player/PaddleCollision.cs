using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[ExecuteInEditMode]
public class PaddleCollision : MonoBehaviour
{
    [Tooltip("hej")] public List<Bouncy> Balls = new List<Bouncy>();
    public float angle1;
    public float angle2;
    public string BallTag = "Ball";
    // Use this for initialization
    void Start()
    {

    }
    void OnDrawGizmosSelected()
    {
        float right = transform.position.x +(GetComponent<BoxCollider2D>().bounds.size.x / 4);
        float left = transform.position.x - (GetComponent<BoxCollider2D>().bounds.size.x / 4);
        Vector3 angleLeft1 = new Vector3(-angle1, 1);
        Vector3 angleLeft2 = new Vector3(-angle2, 1);
        Vector3 angleRight1 = new Vector3(angle1, 1);
        Vector3 angleRight2 = new Vector3(angle2, 1);

        Gizmos.color = Color.blue;
        Gizmos.DrawLine(transform.position, transform.position + angleLeft1.normalized);
        Gizmos.DrawLine(new Vector3(left, transform.position.y), new Vector3(left, transform.position.y) + angleLeft2.normalized);
        Gizmos.DrawLine(transform.position, transform.position + angleRight1.normalized);
        Gizmos.DrawLine(new Vector3(right, transform.position.y), new Vector3(right, transform.position.y) + angleRight2.normalized);
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.transform.tag == BallTag)
        {
            Balls.ForEach(b =>
            {
                if (col.gameObject == b.gameObject)
                {
                    if (transform.position.y < b.transform.position.y ) {
                        float posDistance = (this.transform.position.x - b.transform.position.x) / ((GetComponent<BoxCollider2D>().bounds.size.x / 2));
                        if (posDistance < 0.5 && posDistance > 0)
                        {
                            posDistance = angle1;
                        }
                        else if (posDistance > -0.5 && posDistance < 0)
                        {
                            posDistance = -angle1;
                        }
                        else if (posDistance <= -0.5)
                        {
                            posDistance = -angle2;
                        }
                        else if (posDistance >= 0.5)
                        {
                            posDistance = angle2;
                        }
                        //Debug.Log(posDistance);


                        b.dir.y = 1;
                        b.dir.x = -posDistance;
                        b.setNewDirection();
                    }
                }
            });
        }

    }
}
