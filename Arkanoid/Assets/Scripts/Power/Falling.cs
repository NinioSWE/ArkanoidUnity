using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Falling : MonoBehaviour {

    public float speed;
    private float time;
	// Use this for initialization
	void Start () {
        time = 0;
	}
	
	// Update is called once per frame
	void Update () {
        time += Time.deltaTime;
        if (time > 5)
        {
            Destroy(transform.gameObject);
        }
        float down = -speed* Time.deltaTime;
        transform.Translate(new Vector2(0, down));
	}
}
