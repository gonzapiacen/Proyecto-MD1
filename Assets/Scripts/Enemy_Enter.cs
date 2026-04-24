using UnityEngine;
using UnityEngine.AI;

public class Enemy_Enter : MonoBehaviour
{
    NavMeshAgent Agente;
    [SerializeField] Transform Target;
    private Animator anim;
    private bool TrueTarget;
    [SerializeField] private float RangAt = 2f;

    private bool stunned = false;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Agente = GetComponent<NavMeshAgent>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {

        if (!stunned)
        {
            if (Target != null)
            {
                Agente.SetDestination(Target.position);
                TrueTarget = true;
            }
            else
            {
                TrueTarget = false;
                if (Agente.hasPath)
                {
                    Agente.ResetPath();
                }
            }
            AttackEnemy();
        }
        Animation();
    }

    public void Animation()
    {
        if (TrueTarget != false && !stunned)
        {
            anim.SetBool("Target_lock", true);
        }
        else
        {
            anim.SetBool("Target_lock", false);
        }


    }

    public void AttackEnemy()
    {
        if (Target != null)
        {
            float _distancia = Vector3.Distance(transform.position, Target.position);

            if (_distancia <= RangAt)
            {
                anim.SetBool("Target_Attack", true);
            }
            else
            {
                anim.SetBool("Target_Attack", false);
            }

        }

    }

    public void GetStun()
    {
        stunned = true;
        Agente.isStopped = true;
        Debug.Log("Enemy Stun");
        Invoke("UnStun", 7f);
    }

    private void UnStun()
    {
        stunned = false;
        Agente.isStopped = false;
        Debug.Log("Enemy Unstun");
    }
}
