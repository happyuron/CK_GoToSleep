using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GoToSleep.Manager
{
    public class SoundManager : Singleton<SoundManager>
    {
        private AudioSource source;
        private AudioClip[] clips;

        private List<AudioClip> clipList;
        private float mainSoundVolume;

        private float effectSoundVolume;


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

        public float EffectSoundVolume
        {
            get
            {
                return effectSoundVolume;
            }
            set
            {
                effectSoundVolume = value;
            }
        }
        protected override void Init()
        {
            base.Init();
            source = GetComponent<AudioSource>();
            if (source == null)
                source = gameObject.AddComponent<AudioSource>();
            clips = Resources.LoadAll("") as AudioClip[];

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
