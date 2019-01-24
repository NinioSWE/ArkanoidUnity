using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpBigger : MonoBehaviour , PowerUpBaseClass
{
    public int levelAmount;
    public string paddleTag = "Paddle";
    public float aliveTime;
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.tag == paddleTag)
        {
            PaddleSizePower temp = col.GetComponent<PaddleSizePower>();
            temp.restartTimer();
            temp.aliveTime = aliveTime;
            temp.sizeLevel += levelAmount;
            temp.updateSize();
            //Debug.Log(transform.GetComponents<PowerUpBaseClass>().Length);
           /* if (transform.GetComponents<PowerUpBaseClass>().Length > 2)
            {
                Destroy(this);
            }
            else
            {*/
                Destroy(this.gameObject);
            //}
        }
    }
}
