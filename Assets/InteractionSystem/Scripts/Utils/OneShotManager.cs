using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace WindyWolfGames
{
    namespace InteractionTool
    {
        /// <summary>
        /// this will add itself into the scene to play one shots
        /// </summary>
        [RequireComponent(typeof(AudioSource))]
        [AddComponentMenu("")]
        public class OneShotManager : MonoBehaviour
        {
            private AudioSource source;
            private static OneShotManager _inst;

            public static OneShotManager Instance
            {
                get
                {
                    if (_inst != null)
                    {
                        return _inst;
                    }
                    else
                    {
                        var newGo = new GameObject("OneShotManager");
                        DontDestroyOnLoad(newGo);
                        _inst = newGo.AddComponent<OneShotManager>();
                        _inst.source = newGo.GetComponent<AudioSource>();

                        if(_inst.source == null)
                        {
                            _inst.source = newGo.AddComponent<AudioSource>();
                        }

                        return _inst;
                    }
                }
            }

            static public void Play(AudioClip clip)
            {
                Instance.source.PlayOneShot(clip);
            }

        }//end of class

    }//namespace
}//namespace