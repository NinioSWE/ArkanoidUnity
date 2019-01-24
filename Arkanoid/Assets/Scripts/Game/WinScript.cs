using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class WinScript : MonoBehaviour {

	// Use this for initialization
    private int blockCount;
    public string winText;
    public string winTextUnder;
    public Text winTextObject;
    public Text winTextUnderObject;
    public string PaddleTag = "Paddle";
    public string BallTag = "Ball";
    public string BrickTag = "Brick";
    void Start () {
        blockCount = GameObject.FindGameObjectsWithTag(BrickTag).Length;
	}
	
    public void DeleteBlock()
    {
        blockCount--;
    }
	// Update is called once per frame
	void Update () {
        if (blockCount <= 0)
        {
            winTextObject.text = winText;
            winTextUnderObject.text = winTextUnder;
            GameObject Paddle = GameObject.FindGameObjectWithTag("Paddle");
            GameObject Ball = GameObject.FindGameObjectWithTag("Ball");
            Destroy(Paddle);
            Destroy(Ball);
            if (Input.GetButton("Submit"))
            {
                ScoreScript.score = 0;
                SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            }
        }
	}
}
