using UnityEngine;
using UnityEngine.Audio;

public class SoundClipManagement : Singleton<SoundClipManagement>
{
    //[SerializeField]
    //private SoundData _soundData;
    [SerializeField]
    private AudioSource _musicAudioSource;
    [SerializeField]
    private AudioSource _effectsAudioSource;
    [SerializeField]
    private AudioMixer _audioMixer;

    [Range(0.0001f, 2f)]
    public float MasterSoundValue = 1;
    [Range(0.0001f, 2f)]
    public float MusicSoundValue = 1;
    [Range(0.0001f, 2f)]
    public float EffectsSoundValue = 1;

    private void Start()
    {
        SetAll();
    }

    public void SetAll()
    {
        _audioMixer.SetFloat("Master", Mathf.Log10(MasterSoundValue) * 20);

        _audioMixer.SetFloat("Music", Mathf.Log10(MusicSoundValue) * 20);

        _audioMixer.SetFloat("Effects", Mathf.Log10(EffectsSoundValue) * 20);
    }

    public void SetMusic(AudioClip audioClip)
    {
        _musicAudioSource.clip = audioClip;
        _musicAudioSource.Play();
    }

    public void SetEffects(AudioClip audioClip)
    {
        _effectsAudioSource.clip = audioClip;
        _effectsAudioSource.Play();
    }
}
