using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace WindyWolfGames
{
    namespace InteractionTool
    {
        /// <summary>
        /// This action will play a AudioClip once
        /// </summary>
        public class PlayOneShotAction : Action
        {
            [Tooltip("Gets played once")]
            public AudioClip clip;

            public override ActionError Execute(Interaction caller)
            {
                OneShotManager.Play(clip);
                return ActionError.None;
            }
        }//end of class

    }//namespace
}//namespace