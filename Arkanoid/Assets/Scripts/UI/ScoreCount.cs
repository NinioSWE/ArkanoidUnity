using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreCount : MonoBehaviour {
    private Text scoreText;
    public string standardText;
	// Use this for initialization
	void Start () {
        scoreText = transform.GetComponent<Text>();
	}
	
	// Update is called once per frame
	void Update () {
        scoreText.text = standardText + ScoreScript.score;

    }
}
