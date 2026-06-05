using UnityEngine;
using UnityEngine.AI;

public class AudioEnte : MonoBehaviour
{
    private AudioSource audioSource;
    private NavMeshAgent agent;
    private Animator anim;
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        agent = GetComponent<NavMeshAgent>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        bool targetattack = anim.GetBool("Target_Attack");

        if(agent.velocity.magnitude > 0.5f && !targetattack)
        {
            if (!audioSource.isPlaying)
            {
                audioSource.Play();
            }
        }
        else
        {
            audioSource.Stop();
        }
    }
}
