using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine;

public class LFO : MonoBehaviour
{
    public AudioClip inputAudioClip;  // El audio que se pasa como parámetro.
    public float lfoFrequencyPitch = 5f;   // Frecuencia del LFO.
    public float lfoDepthPitch = 0.5f;     // Amplitud de la modulación del LFO.

    public float lfoFrequencyVolume = 5f;   // Frecuencia del LFO.
    public float lfoDepthVolume = 0.5f;     // Amplitud de la modulación del LFO.

    public float midPitch = 1.0f;
    public float midVolume = 1.0f;

    private AudioSource audioSource;
    private float lfoTime = 0f;

    void Start()
    {
        // Obtiene el componente AudioSource del GameObject
        audioSource = GetComponent<AudioSource>();
        if (audioSource == null)
        {
            Debug.LogError("No se encontró un componente AudioSource en el GameObject.");
            return;
        }

        // Asigna el audio clip al AudioSource
        audioSource.clip = inputAudioClip;
        PlayAudioWithLFO();
    }

    // Función que genera el LFO
    float GenerateLFO(float frequency, float time)
    {
        // Genera una onda sinusoidal como LFO
        return Mathf.Sin(2 * Mathf.PI * frequency * time);
    }

    // Función que aplica el LFO al audio
    void ApplyLFOToAudio()
    {
        if (audioSource.isPlaying)
        {
            // Calcula el valor del LFO en función del tiempo actual
            float lfoPitchValue = GenerateLFO(lfoFrequencyPitch, lfoTime);
            float lfoVolumeValue = GenerateLFO(lfoFrequencyVolume, lfoTime);
            // Aplica el LFO al pitch del AudioSource
            audioSource.pitch = midPitch + (lfoPitchValue * lfoDepthPitch);
            audioSource.volume = midVolume + (lfoVolumeValue * lfoDepthVolume);
            // Incrementa el tiempo del LFO
            lfoTime += Time.deltaTime;
        }
    }

    // Función para reproducir el audio
    public void PlayAudioWithLFO()
    {
        if (audioSource != null && inputAudioClip != null)
        {
            // Inicia la reproducción del audio
            audioSource.Play();
        }
        else
        {
            Debug.LogError("No se pudo reproducir el audio. Verifica que se haya asignado un AudioClip y un AudioSource.");
        }
    }

    void Update()
    {
        // Aplica el LFO cada frame mientras el audio se está reproduciendo
        ApplyLFOToAudio();
    }
}