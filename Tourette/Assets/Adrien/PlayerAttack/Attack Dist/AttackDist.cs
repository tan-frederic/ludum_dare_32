using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class AttackDist : BaseAttack
{

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public override void DoDamage(List<DamagableEntity> entities)
    {
        foreach (DamagableEntity item in entities)
        {
            item.InfligeDamage(Damage);
        }
    }
}
