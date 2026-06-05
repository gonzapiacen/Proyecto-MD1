using UnityEngine;

public class PasosJugador : MonoBehaviour
{
    private AudioSource audioSource;
    public float Normalpitch = 1f;
    public float Sprintpitch = 2f;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    void Update()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");
        bool moviendose = horizontal != 0 || vertical != 0;
        bool sprint = Input.GetKey(KeyCode.LeftShift);

        if (moviendose)
        {

            if (!audioSource.isPlaying)
            {
                audioSource.Play();
            }
            else if (sprint)
            {
                audioSource.pitch = Sprintpitch;
            }
            else
            {
                audioSource.pitch = Normalpitch;
            }

        }
        else
        {
            audioSource.Stop();
        }
    }
}
