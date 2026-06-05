using UnityEngine;
using UnityEngine.Audio;

public class SnapshotController : MonoBehaviour
{
    [SerializeField] private AudioMixer mixer;
    [SerializeField] private Transform agente;
    [SerializeField] private AudioMixerSnapshot normal;
    [SerializeField] private AudioMixerSnapshot peligro;

    [SerializeField] private float distanciaPeligro;
    [SerializeField] private float tiempoTransicion;

    void Update()
    {
        float distancia = Vector3.Distance(transform.position, agente.position);

        if (distancia <= distanciaPeligro)
            peligro.TransitionTo(tiempoTransicion);
        else
            normal.TransitionTo(tiempoTransicion);
    }
}