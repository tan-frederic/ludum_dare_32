using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class MotherFucker : BaseAttack
{
	
	// Use this for initialization
	void Start()
	{
		Destroy (gameObject, 5);
		RadiusDamage = 0.5F;
	}
	
	// Update is called once per frame
	void Update()
	{
		
	}
	
	public override void DoSingleDamage (DamagableEntity entity)
	{
		entity.InfligeDamage (Damage);
	}
}
