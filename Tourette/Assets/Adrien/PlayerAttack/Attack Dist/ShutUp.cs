using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ShutUp : BaseAttack
{

	// Use this for initialization
	void Start()
	{
		RadiusDamage = 0.5F;
		Destroy (gameObject, 3);
	}
	
	// Update is called once per frame
	void Update()
	{
		
	}

	public override void DoSingleDamage (DamagableEntity entity)
	{
		entity.InfligeDamage (Damage);
		Destroy (gameObject);
	}
}
