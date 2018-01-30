using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace WindyWolfGames
{
    namespace InteractionTool
    {
        [System.Serializable]
        public class ClipWithValues
        {
            public int minValue;
            public int maxValue;
            public AudioClip clip;
        }

        /// <summary>
        /// This handles the background music using numbers and clips
        /// </summary>
        [RequireComponent(typeof(AudioSource))]
        public class BackgroundAudioManager : MonoBehaviour
        {

            public AudioClip swapSound;
            public List<ClipWithValues> musicSections = new List<ClipWithValues>();

            private int lastSection = -1;

            private AudioSource source;
            public static BackgroundAudioManager _inst;

            //simple singleton, has to actually be placed
            private void Awake()
            {
                if (_inst != null)
                {
                    DestroyImmediate(this);
                }
                else
                {
                    _inst = this;
                }
            }

            private void Start()
            {
                source = GetComponent<AudioSource>();
            }

            public void PlayNext(int value)
            {
                ClipWithValues scoreSection = musicSections.Find(x => (x.minValue <= value && x.maxValue >= value));
                if (lastSection != musicSections.IndexOf(scoreSection))
                {
                    lastSection = musicSections.IndexOf(scoreSection);
                    StartCoroutine(SwapTracks(scoreSection.clip));
                }
            }

            IEnumerator SwapTracks(AudioClip nextClip)
            {
                if (source.isPlaying)
                {
                    source.Stop();
                }
                source.clip = swapSound;
                source.Play();
                yield return new WaitForSeconds(swapSound.length);
                source.clip = nextClip;
                source.Play();
            }
        }//end of class

    }//namespace
}//namespace