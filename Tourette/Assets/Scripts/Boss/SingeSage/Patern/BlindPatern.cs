using UnityEngine;
using System.Collections;

public class BlindPatern : BaseBossPatern
{

    public GameObject attack;
    public Transform[] PositionCalmDown;
    public AudioClip clip;
    public AudioSource source;

    private bool StopPaternVal = false;
    private bool HasAttacked = false;

    private bool IsInFury = false;

    private int numberShoot = 4;

    GameObject player;

    public ParticleSystem ps;
    IEnumerator StopPatern()
    {
        yield return new WaitForSeconds((IsInFury) ? 2.5f : 5.0f);
        StopPaternVal = true;
    }

    public override void StartTask()
    {
        base.StartTask();
        StopPaternVal = false;
        HasAttacked = false;
        if (!player)
            player = GameObject.FindGameObjectWithTag("Player");
        ps.Play();
    }

    IEnumerator Shoot()
    {
        yield return new WaitForSeconds((IsInFury) ? Random.Range(0.3F, 0.5F) : Random.Range(0.5F, 0.8F));
        GameObject att = (GameObject)Instantiate(attack, PositionCalmDown[Random.Range(0, PositionCalmDown.Length)].position, new Quaternion());
        att.transform.Rotate(new Vector3(90, 270, 0));
        numberShoot--;
        if (numberShoot >= 0)
            StartCoroutine(Shoot());
        else
            StartCoroutine(StopPatern());
    }

    public override BossState Run(bool isInFury)
    {
        transform.eulerAngles = new Vector3(0, Mathf.Lerp(transform.eulerAngles.y, 240, 4 * Time.deltaTime), 0);
        IsInFury = isInFury;
        if (StopPaternVal)
        {
            return (BossState.STOP);
        }
        else if (!HasAttacked)
        {
            source.clip = clip;
            source.Play();
            if (attack)
            {
                numberShoot = Random.Range(1, 6);
            }
            StartCoroutine(Shoot());
            HasAttacked = true;
        }
        return (BossState.EXEC);
    }
}
