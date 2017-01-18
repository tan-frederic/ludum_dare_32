using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class POS : BaseAttack {

	void Start () {
		RadiusDamage = 0.4F;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public override void DoSingleDamage (DamagableEntity entity)
	{
		entity.InfligeDamage (Damage);
        Destroy(gameObject);
	}
}
