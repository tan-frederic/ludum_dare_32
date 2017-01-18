using UnityEngine;
using System.Collections;

public class MovePOS : MonoBehaviour {

	public float speed;
	public GameObject first;
	public GameObject second;
	private float timer = 0F;
	public float damage = 100F;
	
	// Use this for initialization
	void Start () {
		speed = speed / 10;
	}
	
	// Update is called once per frame
	void Update () {
		if (timer >= 0.3F && timer < 2F)
		{
			first.GetComponent<Rigidbody> ().isKinematic = false;
			second.GetComponent<Rigidbody> ().isKinematic = false;
			first.AddComponent<POS>().Damage = damage;
			second.AddComponent<POS>().Damage = damage;
		}
		else if (timer >= 2F)
		{
			Destroy (gameObject);
		}
		else
			transform.Translate (Vector3.up * speed, Space.Self);
		timer += Time.deltaTime;
	}
}
