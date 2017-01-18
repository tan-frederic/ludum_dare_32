using UnityEngine;
using System.Collections;

public class MutePatern : BaseBossPatern
{
    private bool StopPaternVal = false;
    private bool HasAttacked = false;
    public AudioClip clip;
    public AudioSource source;

    private bool IsInFury = false;

    GameObject player;

    public ParticleSystem ps;

    IEnumerator StopPatern()
    {
        HasAttacked = true;
        yield return new WaitForSeconds((IsInFury) ? 10.0f : 7.0f);
        StopPaternVal = true;
    }

    public override void StartTask()
    {
        source.clip = clip;
        source.Play();
        base.StartTask();
        StopPaternVal = false;
        HasAttacked = false;
        if (!player)
            player = GameObject.FindGameObjectWithTag("Player");
        ps.Play();
    }

    public override BossState Run(bool isInFury)
    {
        transform.eulerAngles = new Vector3(0, Mathf.Lerp(transform.eulerAngles.y, 0, 4 * Time.deltaTime), 0);
        IsInFury = isInFury;
        if (StopPaternVal)
        {
            return (BossState.STOP);
        }
        else if (!HasAttacked)
        {
            StartCoroutine(StopPatern());
        }
        return (BossState.EXEC);
    }
}
