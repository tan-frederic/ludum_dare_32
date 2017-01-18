using UnityEngine;
using System.Collections;

public class MovePatern : BaseBossPatern
{
    private GameObject player;

    public float RadiusMove = 2.0f;
    public float SpeedMove = 10.0f;

    private bool IsMoving = false;

    private bool IsInFury = false;
    private float CurrentAngle = 0.0f;

    IEnumerator StopPatern()
    {
        yield return new WaitForSeconds((IsInFury) ? 15.0f : 10.0f);
        IsMoving = false;
    }

    public override void StartTask()
    {
        base.StartTask();
        IsMoving = true;
        if (!player)
            player = GameObject.FindGameObjectWithTag("Player");
        CurrentAngle = Vector3.Angle(player.transform.forward, (transform.position - player.transform.position));
        StartCoroutine(StopPatern());
    }

    public override BossState Run(bool isInFury)
    {
        IsInFury = isInFury;
        CurrentAngle += Time.deltaTime * SpeedMove * 10F;
        if (CurrentAngle >= 360.0f)
            CurrentAngle -= 360.0f;
        float TmpAngle = CurrentAngle * Mathf.PI / 180;
        Vector3 TargetPosition = player.transform.position + new Vector3(Mathf.Cos(TmpAngle) * RadiusMove, 0, Mathf.Sin(TmpAngle) * RadiusMove);
        TargetPosition.y = transform.position.y;
        transform.position = Vector3.MoveTowards(this.transform.position,
            TargetPosition,
            SpeedMove * Time.deltaTime);
        transform.LookAt(new Vector3(player.transform.position.x, transform.position.y, player.transform.position.z));
        return ((IsMoving) ? BossState.EXEC : BossState.STOP);
    }
}
