using UnityEngine;
using System.Collections;

public class Credit : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetButtonDown("Xbox_StartButton") || Input.GetButtonDown("Xbox_AButton")
            || Input.GetButtonDown("Xbox_BButton"))
            Application.LoadLevel("StartMenu");
	}
}
