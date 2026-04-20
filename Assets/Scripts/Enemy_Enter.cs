using UnityEngine;
using UnityEngine.AI;

public class Enemy_Enter : MonoBehaviour
{
    NavMeshAgent Agente;
    public Transform Target;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Agente = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        Agente.destination = Target.position; 
    }
}
