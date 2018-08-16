using UnityEngine.Audio;
using UnityEngine;

[System.Serializable]
public class Sound
{
    [SerializeField]
    private string m_Name;

    [SerializeField]
    private AudioClip m_Clip;

    [SerializeField]
    [Range(0.0f, 1.0f)]
    private float m_Volume = 0.75f;

    [SerializeField]
    [Range(0.0f, 1.0f)]
    private float m_VolumeVariance = 0.1f;

    [SerializeField]
    [Range(0.1f, 3.0f)]
    private float m_Pitch = 1.0f;

    [SerializeField]
    [Range(0.0f, 1.0f)]
    private float m_PitchVariance = 0.1f;

    [SerializeField]
    private bool m_Loop = false;

    [SerializeField]
    private bool m_Music = false;

    [SerializeField]
    private AudioMixerGroup m_Mixer;

    [SerializeField]
    private AudioSource m_Source;

    public Sound()
    {

    }

    public Sound(string a_Name, float a_Volume, float a_Pitch, bool a_Loop, bool a_Music, AudioMixerGroup a_Mixer, AudioSource a_Source)
    {
        m_Name = a_Name;
        m_Volume = a_Volume;
        m_Pitch = a_Pitch;
        m_Loop = a_Loop;
        m_Music = a_Music;
        m_Mixer = a_Mixer;
        m_Source = a_Source;
    }

    public void SetName(string a_Name)
    {
        m_Name = a_Name;
    }

    public void SetVolume(float a_Volume)
    {
        m_Volume = a_Volume;
    }

    public void SetVolumeVariance(float a_Variance)
    {
        m_VolumeVariance = a_Variance;
    }

    public void SetPitch(float a_Pitch)
    {
        m_Pitch = a_Pitch;
    }

    public void SetPitchVariance(float a_Variance)
    {
        m_PitchVariance = a_Variance;
    }

    public void SetLoop(bool a_Loop)
    {
        m_Loop = a_Loop;
    }

    public void SetMusic(bool a_Music)
    {
        m_Music = a_Music;
    }

    public void SetMixer(AudioMixerGroup a_Mixer)
    {
        m_Mixer = a_Mixer;
    }

    public void SetSource(AudioSource a_Source)
    {
        m_Source = a_Source;
    }

    public string GetName()
    {
        return m_Name;
    }

    public float GetVolume()
    {
        return m_Volume;
    }

    public float GetVolumeVariance()
    {
        return m_VolumeVariance;
    }

    public float GetPitch()
    {
        return m_Pitch;
    }

    public float GetPitchVariance()
    {
        return m_PitchVariance;
    }

    public bool GetLoop()
    {
        return m_Loop;
    }

    public bool GetMusic()
    {
        return m_Music;
    }

    public AudioClip GetClip()
    {
        return m_Clip;
    }

    public AudioSource GetSource()
    {
        return m_Source;
    }
}
