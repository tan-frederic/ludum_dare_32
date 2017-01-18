using UnityEngine;
using System.Collections;

[RequireComponent(typeof(DamagableEntity))]
public class BossExec : MonoBehaviour
{

    [System.Serializable]
    public class BossPaternData
    {
        public BaseBossPatern Patern;
        [Range(0, 100)]
        public float PurcentChance;
        [Range(0, 100)]
        public float PurcentChanceFury;
    }

    public BaseBossPatern[] ContinuousPaterns;
    public BossPaternData[] Paterns;
    [Range(0, 100)]
    public float FuryPurcentLife = 20F;
    public Transform ReturnPlace = null;

    private bool _IsInFury = false;
    private BaseBossPatern _CurrentPatern = null;

    private bool IsReturningPlace = false;

    private DamagableEntity DamageEntityComp;

    public GameObject ToEnable;

    void Start()
    {
        if (ReturnPlace)
            transform.position = ReturnPlace.position;
        float MaxPurcentChance = 0F;
        float MaxPurcentChanceFury = 0F;
        foreach (BossPaternData item in Paterns)
        {
            MaxPurcentChance += item.PurcentChance;
            MaxPurcentChanceFury += item.PurcentChanceFury;
        }
        foreach (BossPaternData item in Paterns)
        {
            item.PurcentChance = item.PurcentChance * 100 / MaxPurcentChance;
            item.PurcentChanceFury = item.PurcentChanceFury * 100 / MaxPurcentChanceFury;
        }
        DamageEntityComp = GetComponent<DamagableEntity>();
        ChoosePatern();
        foreach (BaseBossPatern item in ContinuousPaterns)
        {
            item.StartTask();
        }
    }

    void Update()
    {
        if (DamageEntityComp.Life / DamageEntityComp.MaxLife * 100 <= FuryPurcentLife && _IsInFury == false)
        {
            ToEnable.SetActive(true);
            _IsInFury = true;
        }
        foreach (BaseBossPatern item in ContinuousPaterns)
        {
            item.Run(_IsInFury);
        }
        if (_CurrentPatern)
        {
            if (_CurrentPatern.Run(_IsInFury) == BaseBossPatern.BossState.STOP)
            {
                if (ReturnPlace)
                {
                    IsReturningPlace = true;
                }
                else
                    ChoosePatern();
            }
        }
        if (IsReturningPlace)
        {
            transform.position = Vector3.MoveTowards(transform.position, ReturnPlace.position, 30 * Time.deltaTime);
            if ((transform.position - ReturnPlace.position).magnitude < 0.5f)
            {
                IsReturningPlace = false;
                ChoosePatern();
            }
        }
    }

    void ChoosePatern()
    {
        if (_CurrentPatern && _CurrentPatern.NextPatern)
            _CurrentPatern = _CurrentPatern.NextPatern;
        else
        {
            float randvalue = Random.Range(0, 100);
            float lastvalue = 0;
            foreach (BossPaternData item in Paterns)
            {
                float purcentChanceValue = (_IsInFury) ? item.PurcentChanceFury : item.PurcentChance;
                if (randvalue >= lastvalue && randvalue <= lastvalue + purcentChanceValue)
                {
                    _CurrentPatern = item.Patern;
                    break;
                }
                lastvalue += purcentChanceValue;
            }
        }
        Debug.Log(_CurrentPatern);
        _CurrentPatern.StartTask();
    }
}
