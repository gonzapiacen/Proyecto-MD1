using UnityEngine;

public class VoiceController : MonoBehaviour
{
    [SerializeField] private AudioSource vozSource;
    [SerializeField] private AudioClip vozInicio;
    [SerializeField] private AudioClip vozReliquia;
    [SerializeField] private AudioClip vozDamage;
    [SerializeField] private AudioSource sfxSource;
    [SerializeField] private AudioClip sfxReliquia;

    private bool vozDamageReproducida = false;

    void Start()
    {
        vozSource.PlayOneShot(vozInicio);
    }

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.CompareTag("Reliquia"))
        {
            vozSource.PlayOneShot(vozReliquia);
            sfxSource.PlayOneShot(sfxReliquia);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Enemy") && !vozDamageReproducida)
        {
            vozSource.PlayOneShot(vozDamage);
            vozDamageReproducida = true;
        }
    }
}
