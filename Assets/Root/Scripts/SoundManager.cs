using Ardalis.SmartEnum;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[DefaultExecutionOrder(-1)]
public class SoundManager : MonoBehaviour
{
    public static SoundManager Instance { get; private set; }

    private AudioSource _audio;
    [SerializeField]
    private AudioClip _bgMusic;

    private Coroutine _bgMusicCoroutine;

    //audios
    private AudioClip _shootSound;
    private AudioClip _hitSound;
    private AudioClip _deadSound;

    private AudioSource _shootSource;
    private AudioSource _hitSource;
    private AudioSource _deadSource
        ;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }

        GetAudiosAssets();

        _audio = gameObject.AddComponent<AudioSource>();
        _audio.playOnAwake = false;
        _audio.clip = _bgMusic;
    }

    private void GetAudiosAssets()
    {
        _bgMusic = Resources.Load<AudioClip>("Audios/BG_Music");
        _shootSound = Resources.Load<AudioClip>("Audios/Shoot");
        _hitSound = Resources.Load<AudioClip>("Audios/Hit");
        _deadSound = Resources.Load<AudioClip>("Audios/Dead");

        Sounds.Shoot.clip = _shootSound;
        Sounds.Hit.clip = _hitSound;
        Sounds.Dead.clip = _deadSound;
    }

    public void PlayBGMusic()
    {
        if(!_audio.isPlaying) _audio.Play();
        _bgMusicCoroutine = StartCoroutine(BGMusicCoroutine());
    }
    public void PauseBgMusic()
    {
        _audio.Pause();
        StopCoroutine(_bgMusicCoroutine);
    }

    private IEnumerator BGMusicCoroutine()
    {
        
        yield return new WaitUntil(() =>
        {
            return _audio.time >= 18.9f;
        });

        _audio.time = 14.4f;
        PlayBGMusic();
    }

    private Coroutine _soundCoroutine;

    public void PlayAudio(Sounds soundType)
    {
        if (_soundCoroutine != null) StopCoroutine(_soundCoroutine);
        _soundCoroutine = StartCoroutine(PlaySoundCoroutine(soundType));
    }
    

    private IEnumerator PlaySoundCoroutine(Sounds sound)
    {
        if(sound.source == null)
        {
            sound.source = new GameObject(sound.Name).AddComponent<AudioSource>();
        }

        sound.source.PlayOneShot(sound.clip);
        yield return new WaitUntil(() =>
        {
            return !sound.source.isPlaying;
        });

        Destroy(sound.source.gameObject);
        sound.source = null;
        _soundCoroutine = null;
    }

    public abstract class Sounds : SmartEnum<Sounds>
    {
        public static Sounds Shoot = new ShootSound();
        public static Sounds Hit = new HitSound();
        public static Sounds Dead = new DeadSound();


        public abstract AudioSource source { get; set; }
        public abstract AudioClip clip { get; set; }

        protected Sounds(string name, int value) : base(name, value)
        {
        }

        private class ShootSound : Sounds
        {
            public override AudioSource source { get; set; }
            public override AudioClip clip { get; set; }

            public ShootSound() : base("Shoot", 0) { }
        }

        private class HitSound : Sounds
        {
            public override AudioSource source { get; set; }
            public override AudioClip clip { get; set; }

            public HitSound() : base("Hit", 1) { }
        }

        private class DeadSound : Sounds
        {
            public override AudioSource source { get; set; }
            public override AudioClip clip { get; set; }

            public DeadSound() : base("Dead", 2) { }
        }

    }
}

