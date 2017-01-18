using UnityEngine;
using System.Collections;

[RequireComponent(typeof(BossExec))]
public class BaseBossPatern : MonoBehaviour {

    public bool DisableLifeSystem = true;
    private DamagableEntity dam;

    public enum BossState
    {
        EXEC,
        STOP
    };

    public BaseBossPatern NextPatern;

    void Awake()
    {
        dam = GetComponent<DamagableEntity>();
    }

    public virtual void StartTask()
    {
        Debug.Log("LifeSystem" + DisableLifeSystem.ToString());
        if (DisableLifeSystem)
            dam.enabled = false;
        else
            dam.enabled = true;

    }
	
    public virtual BossState Run(bool isInFury)
    {
        return (BossState.STOP);
    }
}
