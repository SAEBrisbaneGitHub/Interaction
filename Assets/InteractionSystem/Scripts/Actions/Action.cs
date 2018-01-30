using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace WindyWolfGames
{
    namespace InteractionTool
    {
        public enum ActionError
        {
            None,
            CannotCos,
            NullData
        }

        /// <summary>
        /// This is the base action class
        /// </summary>
        public abstract class Action : MonoBehaviour
        {
            /// <summary>
            /// This is called whenever an action is triggered
            /// </summary>
            /// <param name="caller">The Interaction that calls this</param>
            /// <returns></returns>
            public abstract ActionError Execute(Interaction caller);
        }//end of class

    }//namespace
}//namespace