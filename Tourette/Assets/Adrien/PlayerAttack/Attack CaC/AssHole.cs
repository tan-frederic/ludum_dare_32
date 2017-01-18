using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class AssHole : BaseAttack {

	void Start () {
		Destroy (gameObject, 0.4F);
		RadiusDamage = 1;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public override void DoSingleDamage (DamagableEntity entity)
	{
		entity.InfligeDamage (Damage);
	}
}
