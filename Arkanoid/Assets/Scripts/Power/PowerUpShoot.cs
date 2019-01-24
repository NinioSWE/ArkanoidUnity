using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpShoot : MonoBehaviour, PowerUpBaseClass
{
    public string paddleTag = "Paddle";
    public GameObject bullet;
    public float bulletSpeed;
    public float fireRate;
    public int bulletDmg;
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
            if (col.GetComponent<PaddleShootPowerUp>() == null)
            {
                col.transform.gameObject.AddComponent<PaddleShootPowerUp>();
                PaddleShootPowerUp temp = col.GetComponent<PaddleShootPowerUp>();
                temp.bullet = bullet;
                temp.bulletSpeed = bulletSpeed;
                temp.fireRate = fireRate;
                temp.bulletDmg = bulletDmg;
                temp.aliveTime = aliveTime;
            }
            else
            {
                PaddleShootPowerUp temp = col.GetComponent<PaddleShootPowerUp>();
                temp.restartTimer();
                temp.bullet = bullet;
                temp.bulletSpeed = bulletSpeed;
                temp.fireRate = fireRate;
                temp.bulletDmg = bulletDmg;
                temp.aliveTime = aliveTime;
            }
           /* Debug.Log(transform.GetComponents<PowerUpBaseClass>().Length);
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
