using UnityEngine;
using System.Collections;

[RequireComponent(typeof(CharacterController))]
public class CharacterManager : MonoBehaviour
{
    public float vSpeed = 5.0F;
    public float hSpeed = 6.0F;
    private Vector3 moveDirection = Vector3.zero;
    private Skill xSkill;
    private Skill ySkill;
    private Skill aSkill;
    private Skill bSkill;
    private float AntiSpam = 0.01F;
    private float timer = 0.0F;
    private bool IsAttacking = false;

    public Skill[] SkillTabCac;
    public Skill[] SkillTabDist;

    public Transform sonTransformM;
    public Animator animatorM;

    public Transform sonTransformG;
    public Animator animatorG;

    private bool isTurnLeft;

    float baseY;

    // Use this for initialization
    void Start()
    {
        baseY = transform.position.y;
        aSkill = SkillTabCac[PlayerPrefs.GetInt("TypeAttackA")];
        bSkill = SkillTabCac[PlayerPrefs.GetInt("TypeAttackB")];
        xSkill = SkillTabDist[PlayerPrefs.GetInt("TypeAttackX")];
        ySkill = SkillTabDist[PlayerPrefs.GetInt("TypeAttackY")];
    }


    void Update()
    {
        Vector3 newPos = transform.position;
        newPos.y = baseY;
        transform.position = newPos;
        CharacterController controller = GetComponent<CharacterController>();
        moveDirection = new Vector3(Input.GetAxis("Horizontal") * hSpeed, 0, Input.GetAxis("Vertical") * vSpeed);
        moveDirection = transform.TransformDirection(moveDirection);
        controller.Move(moveDirection * Time.deltaTime);
        if (sonTransformM.gameObject.activeSelf)
            sonTransformM.LookAt(new Vector3(Mathf.Abs(controller.velocity.x) / controller.velocity.x, 0, 0) + sonTransformM.position);
        if (animatorM.gameObject.activeSelf)
            animatorM.SetFloat("Velocity", controller.velocity.magnitude);
        if (sonTransformG.gameObject.activeSelf)
            sonTransformG.LookAt(new Vector3(Mathf.Abs(controller.velocity.x) / controller.velocity.x, 0, 0) + sonTransformG.position);
        if (animatorG.gameObject.activeSelf)
            animatorG.SetFloat("Velocity", controller.velocity.magnitude);
        if (Mathf.Abs(Input.GetAxis("Horizontal")) > 0.1)
        {
            isTurnLeft = (Input.GetAxis("Horizontal")) < 0;
        }
        if (!IsAttacking)
        {
            if (Input.GetButtonDown("Xbox_AButton"))
            {
                if (aSkill)
                {
                    aSkill.LaunchSkill(isTurnLeft);
                    IsAttacking = true;
                }
                return;
            }
            if (Input.GetButtonDown("Xbox_BButton"))
            {
                if (bSkill)
                {
                    bSkill.LaunchSkill(isTurnLeft);
                    IsAttacking = true;
                }
                return;
            }
            if (Input.GetButtonDown("Xbox_XButton"))
            {
                if (xSkill)
                {
                    xSkill.LaunchSkill(isTurnLeft);
                    IsAttacking = true;
                }
                return;
            }
            if (Input.GetButtonDown("Xbox_YButton"))
            {
                if (ySkill)
                {
                    ySkill.LaunchSkill(isTurnLeft);
                    IsAttacking = true;
                }
                return;
            }
        }
        else
        {
            if (timer >= AntiSpam)
            {
                IsAttacking = false;
                timer = 0.0f;
            }
            else
            {
                timer += Time.deltaTime;
            }
        }

    }


}
