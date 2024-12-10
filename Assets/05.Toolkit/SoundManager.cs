using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoSingleton<SoundManager>
{
    private float volume = 0.5f;
    private float bgmVolume = 0.5f;
    private AudioSource _audioSource;

    // ���� Ŭ���� ������ ��ųʸ�
    public Dictionary<Sound, AudioClip> soundDictionary = new Dictionary<Sound, AudioClip>();

    void Awake()
    {
        DontDestroyOnLoad(gameObject);
        // AudioSource ������Ʈ �������� �Ǵ� �߰�
        _audioSource = gameObject.GetComponent<AudioSource>();
        if (_audioSource == null)
        {
            _audioSource = gameObject.AddComponent<AudioSource>();
        }

        // ���� �ʱ�ȭ
        _audioSource.volume = volume;

        // ���� Ŭ�� ��ųʸ� �ʱ�ȭ
        LoadSounds();
    }

    private void LoadSounds()
    {
        // �� ���忡 �´� ����� Ŭ���� �̸� �ε��մϴ�.
        soundDictionary[Sound.ButtonClick] = Resources.Load<AudioClip>("Sounds/ButtonClick");
     
    }

    public void SetVolume(float newVolume)
    {
        volume = Mathf.Clamp01(newVolume);
        _audioSource.volume = volume; // AudioSource ���� �ݿ�
    }

    public void SetBgmVolume(float newBgmVolume)
    {
        bgmVolume = Mathf.Clamp01(newBgmVolume);
    }

    public float GetVolume() => volume;
    public float GetBgmVolume() => bgmVolume;

    public void MuteMusic()
    {
        SetBgmVolume(0);
    }

    public void PlaySound(Sound sound)
    {
        if (soundDictionary.ContainsKey(sound))
        {
            _audioSource.PlayOneShot(soundDictionary[sound]);
        }
        else
        {
            Debug.LogWarning("Sound not found: " + sound);
        }
    }

    public void ResetSettings()
    {
        SetVolume(0.5f);
        SetBgmVolume(0.5f);
    }
}

public enum Sound
{
    ButtonClick,
    BellRing,
    BuyFail,
    BuySuccess,
    Card,
    Catch,
    Paper,
    Receipt,
    Shop,
    Stage,
    Tada,
    Throw,
    WaterClean
}
