using UnityEngine;
using System.Collections;

public class MoveAttackDist1 : MonoBehaviour {
	
	public float speed;
	
	// Use this for initialization
	void Start () {
		speed = speed / 10;
	}
	
	// Update is called once per frame
	void Update () {
		transform.Translate (Vector3.right * speed, Space.Self);
	}
}
