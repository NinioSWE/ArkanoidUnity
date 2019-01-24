using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{

    [SerializeField]
    float Speed;
    float xMin;
    float xMax;

    // Use this for initialization
    void Start()
    {
        RaycastHit2D left = Physics2D.Raycast(transform.GetComponent<BoxCollider2D>().bounds.min - new Vector3(1,0,0), Vector2.left, 100f);
        RaycastHit2D right = Physics2D.Raycast(transform.GetComponent<BoxCollider2D>().bounds.max + new Vector3(1,0,0), Vector2.right, 100f);
        Debug.DrawLine(transform.GetComponent<BoxCollider2D>().bounds.min, left.point, Color.white, 10);
        Debug.DrawLine(transform.GetComponent<BoxCollider2D>().bounds.max, right.point, Color.white, 10);
        if (left.collider && right.collider)
        {
            xMin = left.point.x;
            xMax = right.point.x;
        }
        else
        {
            xMax = 100f;
            xMin = 100f;
        }
    }

    // Update is called once per frame
    void Update()
    {
        float size = transform.GetComponent<BoxCollider2D>().bounds.size.x;
        var input = new Vector2(Input.GetAxisRaw("Horizontal"), 0) * Speed * Time.deltaTime;
        transform.Translate(input);
         if (transform.position.x - (size/2) < xMin)
         {
             //Debug.Log("left");
             transform.position = new Vector2(xMin + (size / 2), transform.position.y);

         }
         else if (transform.position.x + (size / 2) > xMax)
         {
             //Debug.Log("Right");
             transform.position = new Vector2(xMax - (size / 2), transform.position.y);
         }
    }
}
