using UnityEngine;
using System.Collections;

public class CheckSex : MonoBehaviour {

    public int Sex;
    public int test;

    // Use this for initialization
    void Start ()
    {
        if (Sex != PlayerPrefs.GetInt("PlayerSelected"))
            gameObject.SetActive(false);
	}
	
	// Update is called once per frame
	void Update () {

        test = PlayerPrefs.GetInt("PlayerSelected");
    }
}
