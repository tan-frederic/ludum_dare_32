using UnityEngine;
using System.Collections;

public class FloatingPaternContinuous : BaseBossPatern {

    public float FloatingHeight = 1.0f;
    [Range(0F, 10F)]
    public float Speed = 1.0f;

    float StartY;

    public override void StartTask()
    {
        StartY = transform.position.y;
        base.StartTask();
    }

    public override BossState Run(bool isInFury)
    {
        Vector3 NewPos = transform.position;
        NewPos.y = StartY + Mathf.Cos(Time.time * Speed) * FloatingHeight / 2F;
        transform.position = NewPos;
        return base.Run(isInFury);
    }
}
