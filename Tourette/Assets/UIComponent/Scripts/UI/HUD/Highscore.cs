using UnityEngine;
using UnityEngine.UI;
using System.Collections;

[RequireComponent(typeof(Text))]
public class Highscore : MonoBehaviour {

    private Text hightscore;

    void Awake()
    {
        hightscore = this.GetComponent<Text>();
    }

	void Update ()
    {
        hightscore.text = "Hightscore : " + PlayerPrefs.GetInt("Score");
	}
}
