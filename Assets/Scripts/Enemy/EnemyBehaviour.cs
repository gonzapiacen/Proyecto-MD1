using UnityEngine;
using UnityEngine.AI;

public class EnemyBehaviour: MonoBehaviour
{
    //IGUAL QUE OTRO CODIGO PERO PARA EVITAR ERRORES HICE ESTE.
    //AGREGA MOVIEMIENTO y PERSECUCION.

    NavMeshAgent Agente;
    [SerializeField] Transform Target;
    [SerializeField] Transform Target2;


    [SerializeField] private Animator anim;
    private bool TrueTarget = true;

    [SerializeField] private float RangAt = 2f;
    [SerializeField] private float SpeedEnemy = 1f;
    [SerializeField] private float AccelarationEnemy = 4f;

    [SerializeField] float RangodeVision = 10;

    public PlayerMovement PlayerisSafe;

    private bool stunned = false;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Agente = GetComponent<NavMeshAgent>();
        anim = GetComponent<Animator>();
        ControlEnemy();
        PlayerisSafe = Target.GetComponent<PlayerMovement>();
    }


    // Update is called once per frame
    void Update()
    {
        /*
        if(PlayerisSafe.GetZoneSafeBool())
        {
   
            Debug.Log("ENCONTRO PLAYER");

            if (!stunned)
            {
                if (Target != null)
                {
                    
                    Agente.SetDestination(Target.position);
                    TrueTarget = true;
                    if(PlayerisSafe.GetZoneSafeBool() || !Agente.hasPath)
                    {
                        Agente.ResetPath();
                    }
                }
                else
                {
                    TrueTarget = false;
                    if (!Agente.hasPath)
                    {
                        Agente.ResetPath();
                    }
                }
                AttackEnemy();
            }
                
        }
        else
        {
            Debug.Log("NO SE ENCONTRO PLAYER");
            Agente.SetDestination(Target2.position);
        }
        */

        if(PlayerisSafe != null && PlayerisSafe.playerissafe)
        {
            if(!stunned && Target2 != null)
            {
                if(Agente.destination != Target2.position)
                {
                    Agente.SetDestination(Target2.position);
                    Debug.Log("NO SE ENCONTRO PLAYER");
                }
            }
        }
        else
        {
            if(!stunned && Target != null)
            {
                Debug.Log("ENCONTRO PLAYER");
                Agente.SetDestination(Target.position);

                AttackEnemy();
            }
            else
            {
                if(!Agente.hasPath)
                {
                    TrueTarget = false;
                    Agente.ResetPath();
                    Debug.Log("NO SE ENCONTRO PLAYER");
                }
            }
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

    public void CheckAttack()
    {
        float _distancia = Vector3.Distance(transform.position, Target.position);
        if(_distancia <= 2)
        {
            Target.GetComponent<PlayerHealth>().SetHealth(1);
        }
    }
    
    public void ControlEnemy()
    {
        Agente.speed = SpeedEnemy;
        Agente.acceleration = AccelarationEnemy;
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