using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class FuckYou : BaseAttack {

	// Use this for initialization
	void Start () {
		Destroy (gameObject, 0.3F);
		RadiusDamage = 1;
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public override void DoDamage(List<DamagableEntity> entities)
	{
	}

	public override void DoSingleDamage (DamagableEntity entity)
	{
        Debug.Log("Damage " + Damage);
		entity.InfligeDamage (Damage);
        Destroy(gameObject);
	}
}
