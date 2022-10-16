using UnityEngine;

public class AudioManager : MonoSingleton<AudioManager>
{
    [Range(0, 1)] public float volume = 1;

    public void PlayAudio(AudioClip audio)
    {
        AudioSource.PlayClipAtPoint(audio, transform.position, volume); 
	}
}