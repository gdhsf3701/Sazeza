using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoSingleton<SoundManager>
{
    private float volume = 0.5f;
    private float bgmVolume = 0.5f;
    private AudioSource _audioSource;

    // 사운드 클립을 저장할 딕셔너리
    public Dictionary<Sound, AudioClip> soundDictionary = new Dictionary<Sound, AudioClip>();

    void Awake()
    {
        DontDestroyOnLoad(gameObject);
        // AudioSource 컴포넌트 가져오기 또는 추가
        _audioSource = gameObject.GetComponent<AudioSource>();
        if (_audioSource == null)
        {
            _audioSource = gameObject.AddComponent<AudioSource>();
        }

        // 볼륨 초기화
        _audioSource.volume = volume;

        // 사운드 클립 딕셔너리 초기화
        LoadSounds();
    }

    private void LoadSounds()
    {
        // 각 사운드에 맞는 오디오 클립을 미리 로드합니다.
        soundDictionary[Sound.ButtonClick] = Resources.Load<AudioClip>("Sounds/ButtonClick");
        soundDictionary[Sound.BellRing] = Resources.Load<AudioClip>("Sounds/BellRing");
        soundDictionary[Sound.BuyFail] = Resources.Load<AudioClip>("Sounds/BuyFail");
        soundDictionary[Sound.BuySuccess] = Resources.Load<AudioClip>("Sounds/BuySuccess");
        soundDictionary[Sound.Card] = Resources.Load<AudioClip>("Sounds/Card");
        soundDictionary[Sound.Catch] = Resources.Load<AudioClip>("Sounds/Catch");
        soundDictionary[Sound.Paper] = Resources.Load<AudioClip>("Sounds/Paper");
        soundDictionary[Sound.Receipt] = Resources.Load<AudioClip>("Sounds/Receipt");
        soundDictionary[Sound.Shop] = Resources.Load<AudioClip>("Sounds/Shop");
        soundDictionary[Sound.Stage] = Resources.Load<AudioClip>("Sounds/Stage");
        soundDictionary[Sound.WaterClean] = Resources.Load<AudioClip>("Sounds/WaterClean");
        soundDictionary[Sound.Throw] = Resources.Load<AudioClip>("Sounds/Throw");
        soundDictionary[Sound.Tada] = Resources.Load<AudioClip>("Sounds/Tada");




    }

    public void SetVolume(float newVolume)
    {
        volume = Mathf.Clamp01(newVolume);
        _audioSource.volume = volume; // AudioSource 볼륨 반영
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
