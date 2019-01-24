using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScript : MonoBehaviour {

	// Use this for initialization
    public float speed = 1f;
    public int dmg = 0;
    public string playerTag = "Paddle";
    public string brickTag = "Brick";
    public string wallTag = "Wall";
    void Start () {
        GetComponent<Rigidbody2D>().velocity = new Vector2(0,speed);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.transform.tag != playerTag && (col.transform.tag == brickTag || col.transform.tag == wallTag))
        {
            if (col.transform.tag == brickTag)
            {
                col.transform.GetComponent<Brick>().life -= dmg;
            }
            Destroy(this.gameObject);
        }
    }
}
