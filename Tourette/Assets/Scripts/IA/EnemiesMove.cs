using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Animator))]
[RequireComponent(typeof(NavMeshAgent))]
public class EnemiesMove : MonoBehaviour
{
    public GameObject Attack;

    private bool CanAttack = true;

	private	NavMeshAgent agent;
    private Animator anim;
    private GameObject player;

    // Use this for initialization
    void Start()
    {
        anim = GetComponent<Animator>();
    	agent = GetComponent<NavMeshAgent>();
        player = GameObject.FindWithTag("Player");
    }

    IEnumerator ResetAttack()
    {
        CanAttack = false;
        yield return new WaitForSeconds(2.0f);
        CanAttack = true;
    }

    // Update is called once per frame
    void Update()
    {
        agent.SetDestination(player.transform.position);
        anim.SetFloat("Velocity", agent.velocity.magnitude);
        transform.LookAt(new Vector3(player.transform.position.x, transform.position.y, player.transform.position.z));
        if (CanAttack && (player.transform.position - transform.position).magnitude <= 3.0f)
        {
            Instantiate(Attack, transform.position + transform.forward + new Vector3(0, 1.0f, 0), new Quaternion());
            StartCoroutine(ResetAttack());
        }
    }
}
