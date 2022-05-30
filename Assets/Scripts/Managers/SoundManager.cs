using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GoToSleep.Manager
{
    public class SoundManager : Singleton<SoundManager>
    {
        private AudioSource source;

        private List<AudioClip> clipList = new List<AudioClip>();
        private float mainSoundVolume;

        private float soundEffectVolume;


        public float MainSoundVolume
        {
            get
            {
                return mainSoundVolume;
            }
            set
            {
                mainSoundVolume = value;
                source.volume = mainSoundVolume;
            }
        }

        public float SoundEffectVolume
        {
            get
            {
                return soundEffectVolume;
            }
            set
            {
                soundEffectVolume = value;
            }
        }
        protected override void Init()
        {
            base.Init();
            source = GetComponent<AudioSource>();
        }
        protected override void Awake()
        {
            base.Awake();
            AudioClip[] clips = Resources.LoadAll<AudioClip>("Sound");
            for (int i = 0; i < clips.Length; i++)
            {
                clipList.Add(clips[i]);
            }
        }
        public void PlaySoundEffect(string name)
        {
            AudioClip tmp = clipList.Find(o => o.name == name);
            if (tmp != null)
                source.PlayOneShot(tmp);
        }

    }
}
