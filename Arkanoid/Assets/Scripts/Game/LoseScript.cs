using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LoseScript : MonoBehaviour {

    public string ballTag = "Ball";
    public GameObject player;
    private bool gameOver = false;
    public string GameOverText;
    public string GameOverTextUnder;
    public Text GameOverTextObject;
    public Text GameOverTextUnderObject;
    // Use this for initialization
    void Start () {
        gameOver = false;
    }
	
	// Update is called once per frame
	void Update () {
        if (gameOver)
        {
            GameOverTextObject.text = GameOverText;
            GameOverTextUnderObject.text = GameOverTextUnder;
            Destroy(player.gameObject);
            if (Input.GetButton("Submit")) {
                 Debug.Log("Nanni");
                ScoreScript.score = 0;
                SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            }
        }
	}
    void OnTriggerExit2D(Collider2D col)
    {
        if (col.transform.tag == ballTag)
        {
            gameOver = true;

        }
    }
}
