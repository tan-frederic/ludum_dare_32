using UnityEngine;
using System.Collections;

public class ProvocationPatern : BaseBossPatern
{
    public ParticleSystem provoc;
    public AudioClip clip;
    public AudioSource source;

    public bool OnProvoc;

    public override void StartTask()
    {
        OnProvoc = false;
        base.StartTask();
        Debug.Log(provoc);
        provoc.Play();
        StartCoroutine(StopProvoc());
        source.clip = clip;
        source.Play();
    }

    IEnumerator StopProvoc()
    {
        yield return new WaitForSeconds(2F);
        OnProvoc = true;
    }

    public override BossState Run(bool isInFury)
    {
        if (OnProvoc)
            return BossState.STOP;
        return BossState.EXEC;
    }
}
