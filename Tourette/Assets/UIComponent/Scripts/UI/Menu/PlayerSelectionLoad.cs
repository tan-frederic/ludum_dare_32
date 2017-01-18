using UnityEngine;
using System.Collections;

public class PlayerSelectionLoad : MonoBehaviour {

    int position;
	
    void Awake()
    {
        position = 0;
    }

	// Update is called once per frame
	void Update () {
        if (Input.GetButtonDown("Xbox_BButton"))
            --position;
        if (Input.GetButtonDown("Xbox_AButton"))
            ++position;
        if (position == -1 && Input.GetButtonDown("Xbox_BButton"))
            Application.LoadLevel("StartMenu");
        if (position == 2 && Input.GetButtonDown("Xbox_AButton"))
            Application.LoadLevel("InputSelection");
    }
}
