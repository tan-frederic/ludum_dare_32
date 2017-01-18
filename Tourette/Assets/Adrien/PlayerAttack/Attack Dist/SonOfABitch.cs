using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class SonOfABitch : BaseAttack
{
	private float size = 1F;
	private float exp = 0.2F;

	// Use this for initialization
	void Start()
	{
		Destroy (gameObject, 5);
		RadiusDamage = 0.5F;
	}
	
	// Update is called once per frame
	void Update()
	{
		transform.localScale = new Vector3 (size, size, size);
		size = size + exp * Time.deltaTime;
		exp = exp + exp * Time.deltaTime;
	}

	public override void DoSingleDamage (DamagableEntity entity)
	{
		entity.InfligeDamage (Damage);
	}
}
