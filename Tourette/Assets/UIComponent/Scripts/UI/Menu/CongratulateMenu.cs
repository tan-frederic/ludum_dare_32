using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class CongratulateMenu : MonoBehaviour {

    public Text score;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        score.text = "Your score is : " + PlayerPrefs.GetInt("score");
        if (Input.GetButtonDown("Xbox_StartButton"))
            Application.LoadLevel("StartMenu");
	}
}
