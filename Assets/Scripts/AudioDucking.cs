using UnityEngine;
using UnityEngine.Audio;

public class AudioDucking : MonoBehaviour
{
    [SerializeField] private AudioMixer mixer;
    public float volumenNormal = 0f;
    public float volumenDucking = -20f;
    public float velocidad = 5f;

    private float targetVolume;
    private AudioSource[] vozSources;

    void Start()
    {
        AudioSource[] todos = FindObjectsOfType<AudioSource>();
        System.Collections.Generic.List<AudioSource> vozList = new System.Collections.Generic.List<AudioSource>();

        foreach (AudioSource source in todos)
        {
            if (source.outputAudioMixerGroup != null && source.outputAudioMixerGroup.name == "Voice")
            {
                vozList.Add(source);
            }
        }

        vozSources = vozList.ToArray();
    }

    void Update()
    {
        bool vozSonando = false;
        foreach (AudioSource source in vozSources)
        {
            if (source.isPlaying)
            {
                vozSonando = true;
                break;
            }
        }

        targetVolume = vozSonando ? volumenDucking : volumenNormal;

        float currentVolume;
        mixer.GetFloat("MusicVolume", out currentVolume);
        float nuevoVolumen = Mathf.Lerp(currentVolume, targetVolume, Time.deltaTime * velocidad);
        mixer.SetFloat("MusicVolume", nuevoVolumen);
    }
}
