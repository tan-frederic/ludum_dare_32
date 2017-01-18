using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class BaseAttack : MonoBehaviour {

    [Range(0, 1000)]
    public float Damage;
    [Range(0, 60)]
    public float Cooldown;
    public ParticleSystem EndParticle;

    protected float RadiusDamage;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	    
	}

    void OnCollisionEnter(Collision	col)
    {
        Debug.Log("collision "+col.gameObject.ToString());
		Collider[] cols = Physics.OverlapSphere (transform.position, RadiusDamage, 10);
        List<DamagableEntity> ret = new List<DamagableEntity>();
        foreach (Collider item in cols)
        {
            DamagableEntity de = item.gameObject.GetComponent<DamagableEntity>();
            if (de != null)
                ret.Add(de);
        }
        DoDamage(ret);
        DoSingleDamage (col.gameObject.GetComponent<DamagableEntity> ());
        if (EndParticle)
        {
            EndParticle.Play();
            Destroy(gameObject, EndParticle.time);
        }
        else
            Destroy(gameObject, 2F);
    }

    public virtual void DoDamage(List<DamagableEntity> entities)
    {
    }

	public virtual void DoSingleDamage(DamagableEntity entity)
	{

	}
}
