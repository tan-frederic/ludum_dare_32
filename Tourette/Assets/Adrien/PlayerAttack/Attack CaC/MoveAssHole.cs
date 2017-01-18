using UnityEngine;
using System.Collections;

public class MoveAssHole : MonoBehaviour {

	public float speed;
	
	// Use this for initialization
	void Start () {
		speed = speed / 10;
	}
	
	// Update is called once per frame
	void Update () {
		//transform.localPosition = new Vector3 (x, y + speed, z);
		transform.Translate (Vector3.up * speed, Space.Self);
	}
}
