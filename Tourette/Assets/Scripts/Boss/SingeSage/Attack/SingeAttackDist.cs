using UnityEngine;
using System.Collections;
using System.Collections.Generic;

[RequireComponent(typeof(TextMesh))]
[RequireComponent(typeof(Collider))]
public class SingeAttackDist : BaseAttack
{
    public ParticleSystem TrailParticle;

    private TextMesh _Text;
    public float _Duration = 5.0f;
    private float _StartDuration;

    private Vector3 EndVelocity = Vector3.zero;
    private bool StopParticle = true;

    // Use this for initialization
    void Start()
    {
        _StartDuration = _Duration;
        _Text = GetComponent<TextMesh>();
        Vector3 point;
        RaycastHit hit;
        if (Physics.Raycast(transform.position, Vector3.down, out hit))
        {
            point = hit.point;
            point += new Vector3(0, 0.5f, 0);
        }
        else
            point = transform.position;
        transform.position = point;
    }

    IEnumerator EndParticle()
    {
        yield return new WaitForSeconds(1.9f);
        TrailParticle.gameObject.transform.parent = null;
        TrailParticle.Stop();
    }

    // Update is called once per frame
    void Update()
    {
        if (_Duration <= 0.0f)
        {
            GetComponent<Rigidbody>().velocity = EndVelocity;
            if (TrailParticle && StopParticle)
                TrailParticle.Stop();
            Destroy(gameObject, 2.0f);
            GetComponent<Collider>().enabled = false;
        }
        else
        {
            GetComponent<Rigidbody>().AddForce(new Vector3(-5F, 0F, 0F));
            Color c = _Text.color;
            c.a = _Duration / _StartDuration;
            _Text.color = c;
            _Duration -= Time.deltaTime;
        }
    }

    public override void DoDamage(List<DamagableEntity> entities)
    {
        GameObject.FindGameObjectWithTag("Player").GetComponent<DamagableEntity>().InfligeDamage(Damage);
        _Duration = 0.0f;
        _Text.color = Color.clear;
        EndVelocity = new Vector3(-5F, 0F, 0F);
        StopParticle = false;
        TrailParticle.simulationSpace = ParticleSystemSimulationSpace.World;
        StartCoroutine(EndParticle());
    }
}
