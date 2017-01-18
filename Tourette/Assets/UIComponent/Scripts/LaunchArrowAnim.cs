using UnityEngine;
using System.Collections;

public class LaunchArrowAnim : MonoBehaviour {

    public Animator anim;
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.Space))
            anim.SetTrigger("GoNext");
	}
}
