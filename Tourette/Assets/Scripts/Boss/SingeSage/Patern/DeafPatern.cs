using UnityEngine;
using System.Collections;

public class DeafPatern : BaseBossPatern
{
    public GameObject attack;
    public AudioClip clip;
    public AudioSource source;

    private bool StopPaternVal = false;
    private bool HasAttacked = false;

    private bool IsInFury = false;

    GameObject player;

    public ParticleSystem ps;

    IEnumerator StopPatern()
    {
        HasAttacked = true;
        yield return new WaitForSeconds((IsInFury) ? 1.5f : 3.0f);
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

    public override BossState Run(bool isInFury)
    {
        transform.eulerAngles = new Vector3(0, Mathf.Lerp(transform.eulerAngles.y, 120, 4 * Time.deltaTime), 0);
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
                GameObject att = (GameObject)Instantiate(attack);
                att.transform.position = player.transform.position - new Vector3(0F, 0.5f, 0F);
                att = (GameObject)Instantiate(attack);
                att.transform.position = new Vector3(Random.insideUnitCircle.x * Random.Range(5F, 10F), 0, Random.insideUnitCircle.y * Random.Range(5F, 10F)) + player.transform.position;
                att = (GameObject)Instantiate(attack);
                att.transform.position = new Vector3(Random.insideUnitCircle.x * Random.Range(5F, 10F), 0, Random.insideUnitCircle.y * Random.Range(5F, 10F)) + player.transform.position;
                att = (GameObject)Instantiate(attack);
                att.transform.position = new Vector3(Random.insideUnitCircle.x * Random.Range(5F, 10F), 0, Random.insideUnitCircle.y * Random.Range(5F, 10F)) + player.transform.position;
                att = (GameObject)Instantiate(attack);
                att.transform.position = new Vector3(Random.insideUnitCircle.x * Random.Range(5F, 10F), 0, Random.insideUnitCircle.y * Random.Range(5F, 10F)) + player.transform.position;
            }
            StartCoroutine(StopPatern());
        }
        return (BossState.EXEC);
    }
}
