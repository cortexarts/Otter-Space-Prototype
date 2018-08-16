using System;
using UnityEngine.Audio;
using UnityEngine;
using UnityEngine.UI;

public class AudioManager : MonoBehaviour
{
    #region Persistent Singleton

    public static AudioManager m_Instance;

    private void Awake()
    {
        if(m_Instance != null)
        {
            Destroy(gameObject);
        }
        else
        {
            m_Instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }

    #endregion

    [SerializeField]
    private float m_MainVolume = 1.0f;

    [SerializeField]
    private float m_MusicVolume = 1.0f;

    [SerializeField]
    private float m_SoundVolume = 1.0f;

    [SerializeField]
	private AudioMixerGroup m_Mixer;

    [SerializeField]
    private Sound[] m_Sounds;

    private void Start()
    {
        foreach(Sound sound in m_Sounds)
        {
            sound.SetSource(gameObject.AddComponent<AudioSource>());
            sound.GetSource().clip = sound.GetClip();
            sound.GetSource().loop = sound.GetLoop();
            sound.GetSource().outputAudioMixerGroup = m_Mixer;
        }
    }

    public void Play(string a_Sound)
	{
		Sound sound = Array.Find(m_Sounds, item => item.GetName() == a_Sound);

		if (sound == null)
		{
			Debug.LogWarning("Sound: " + name + " not found!");
			return;
		}

        if(sound.GetMusic())
        {
            sound.GetSource().volume = sound.GetVolume() * m_MainVolume * m_MusicVolume * (1.0f + UnityEngine.Random.Range(-sound.GetVolumeVariance() / 2.0f, sound.GetVolumeVariance() / 2.0f));
        }
        else
        {
            sound.GetSource().volume = sound.GetVolume() * m_MainVolume * m_SoundVolume * (1.0f + UnityEngine.Random.Range(-sound.GetVolumeVariance() / 2.0f, sound.GetVolumeVariance() / 2.0f));
        }

        sound.GetSource().pitch = sound.GetVolume() * (1.0f + UnityEngine.Random.Range(-sound.GetPitchVariance() / 2.0f, sound.GetPitchVariance() / 2.0f));

        sound.GetSource().Play();
	}

    public void SetMainVolume(float a_Volume)
    {
        m_MainVolume = a_Volume;
    }

    public void SetMusicVolume(float a_Volume)
    {
        m_MusicVolume = a_Volume;
    }

    public void SetSoundVolume(float a_Volume)
    {
        m_SoundVolume = a_Volume;
    }

    public void SetMainVolume(Slider a_Slider)
    {
        m_MainVolume = a_Slider.value;
    }

    public void SetMusicVolume(Slider a_Slider)
    {
        m_MusicVolume = a_Slider.value;
    }

    public void SetSoundVolume(Slider a_Slider)
    {
        m_SoundVolume = a_Slider.value;
    }
}
