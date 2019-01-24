using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpSticky : MonoBehaviour, PowerUpBaseClass
{
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
            if (col.GetComponent<PaddleStickyPowerUp>() == null)
            {
                col.transform.gameObject.AddComponent<PaddleStickyPowerUp>();
                col.GetComponent<PaddleStickyPowerUp>().aliveTime = aliveTime;
            }
            else
            {
                col.GetComponent<PaddleStickyPowerUp>().restartTimer();
                col.GetComponent<PaddleStickyPowerUp>().aliveTime = aliveTime;
            }
            /*Debug.Log(transform.GetComponents<PowerUpBaseClass>().Length);
            if (transform.GetComponents<PowerUpBaseClass>().Length > 2)
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
