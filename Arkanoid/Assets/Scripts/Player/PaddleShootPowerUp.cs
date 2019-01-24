using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaddleShootPowerUp : MonoBehaviour {
    public GameObject bullet;
    public float bulletSpeed;
    public float fireRate;
    public int bulletDmg;
    private float nextFire;
    public float aliveTime;
    private float startTime;
    // Use this for initialization
    void Start () {
        startTime = 0;
    }
    public void restartTimer()
    {
        startTime = 0;
    }

    // Update is called once per frame
    void Update () {

        if (startTime < aliveTime)
        {
            startTime += Time.deltaTime;
        }
        else
        {
            Destroy(this);
        }


        if (Input.GetButton("Fire1") && nextFire < Time.time)
        {
            nextFire = Time.time + fireRate;
            GameObject temp = Instantiate(bullet,new Vector3(transform.GetComponent<BoxCollider2D>().bounds.min.x,transform.position.y),Quaternion.identity);
            GameObject temp2 = Instantiate(bullet, new Vector3(transform.GetComponent<BoxCollider2D>().bounds.max.x, transform.position.y), Quaternion.identity);
            BulletScript tempBS1 = temp.GetComponent<BulletScript>();
            BulletScript tempBS2 = temp2.GetComponent<BulletScript>();
            tempBS1.speed = bulletSpeed;
            tempBS2.speed = bulletSpeed;
            tempBS1.dmg = bulletDmg;
            tempBS2.dmg = bulletDmg;
        }
	}
}
