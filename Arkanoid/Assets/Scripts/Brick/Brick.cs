using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Brick : MonoBehaviour {

    // Use this for initialization
    [SerializeField]
    List<someting> list = new List<someting>();
    public string ballTag = "Ball";
    public int score;
    public int life;
    private WinScript winscr;

    void Start() {
        winscr = GetComponentInParent<WinScript>();
    }

    // Update is called once per frame
    void Update() {
        if (life <= 0)
        {
            ScoreScript.score += score;
            SpawnPowerUp();
            winscr.DeleteBlock();
            Destroy(gameObject);
        }
    }
    void SpawnPowerUp()
    {
        int allDropChances = 0;
        list.ForEach(listan =>
        {
            allDropChances += (int)listan.dropChance;
        });

        int random = Random.Range(0, allDropChances);
        //Debug.Log("Random :" +random);
        int index = 0;
        int dropChanceIndex = 0;
        list.ForEach(listan =>
        {
           // Debug.Log("dropChanceIndex " + dropChanceIndex + "NewDropChanceIndex " + (int)listan.dropChance);
            if (random >= dropChanceIndex && random < ((int)listan.dropChance + dropChanceIndex))
            {
                if (listan.powerup != null)
                {
                    Instantiate(listan.powerup, transform.position, transform.rotation);
                }
            }
            dropChanceIndex += (int)listan.dropChance;
            index++;
        });
    }
    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.transform.tag == ballTag)
        {
            life--;
        }
    }
}
[System.Serializable]
struct someting
{
    public Transform powerup;
    public uint dropChance;

}