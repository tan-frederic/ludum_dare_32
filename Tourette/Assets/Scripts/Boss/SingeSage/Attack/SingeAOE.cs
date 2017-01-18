using UnityEngine;
using System.Collections;
using System.Collections.Generic;

[RequireComponent(typeof(AudioSource))]
public class SingeAOE : BaseAttack
{
    public GameObject Text;
    public GameObject DeclInst;
    public float Radius;
    public AudioClip OnExplode;
    public AudioClip PrepareExplode;

    public float _Duration = 5.0f;
    private float _StartDuration;
    private AudioSource source;

    IEnumerator AOETrigger()
    {
        source.clip = PrepareExplode;
        source.Play();
        yield return new WaitForSeconds(1.5f);
        source.clip = OnExplode;
        source.Play();
        for (int i = 0; i < 8; i++)
        {
            float RandomAngle = i * Mathf.PI * 2 / 8F;
            Vector3 SpawnPosition = new Vector3(transform.position.x + Mathf.Cos(RandomAngle) * Radius, transform.position.y, transform.position.z + Mathf.Sin(RandomAngle) * Radius);
            Instantiate(Text, SpawnPosition, new Quaternion());
        }
        if (DeclInst)
            Instantiate(DeclInst, transform.position, new Quaternion());
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        if ((player.transform.position - transform.position).magnitude <= Radius)
        {
            player.GetComponent<DamagableEntity>().InfligeDamage(Damage);
        }
        Destroy(gameObject, 1.5f);
    }

    void Start()
    {
        source = GetComponent<AudioSource>();
        StartCoroutine(AOETrigger());
    }
}
