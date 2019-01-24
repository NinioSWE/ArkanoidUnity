using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaddleSizePower : MonoBehaviour
{

    public int sizeLevel = 1; // MAX 5
    public List<Sprite> spriteLevels = new List<Sprite>();
    public float aliveTime;
    private float startTime;
    // Use this for initialization
    void Start()
    {
        checkSize();
        updateSize();
        startTime = 0;
    }

    // Update is called once per frame
    void Update()
    {
        checkSize();

        if (startTime < aliveTime)
        {
            startTime += Time.deltaTime;
        }
        else if(sizeLevel > 1)
        {
            sizeLevel --;
            checkSize();
            updateSize();
            restartTimer();
        }
    }
    private void checkSize()
    {
        if (sizeLevel >= spriteLevels.Count)
        {
            sizeLevel = spriteLevels.Count;
        }
        else if (sizeLevel <= 0)
        {
            sizeLevel = 1;
        }
    }
    public void restartTimer()
    {
        startTime = 0;
    }
    public void updateSize()
    {
        var sr = GetComponent<SpriteRenderer>();
        var bc = GetComponent<BoxCollider2D>();
        int index = 1;
        foreach (var spriteLevel in spriteLevels)
        {
            if (sizeLevel == index)
            {
                sr.sprite = spriteLevel;
                bc.size = new Vector2(spriteLevel.bounds.size.x, spriteLevel.bounds.size.y);
            }
            index++;
        }
    }

    /*void OnTriggerEnter2D(Collider2D col)
    {
        if (col.transform.tag == "SizePowerUp")
        {
            Debug.Log("test1");
            sizeLevel++;
            if (sizeLevel >= 5)
            {
                sizeLevel = 5;
            }
            updateSize();
            Destroy(col.gameObject);
        }
        if (col.transform.tag == "StickyPowerUp")
        {
            transform.gameObject.AddComponent<PaddleStickyPowerUp>();
            Destroy(col.gameObject);
        }

    }*/
}
