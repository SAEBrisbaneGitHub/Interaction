using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace WindyWolfGames
{
    namespace InteractionTool
    {
        /// <summary>
        /// This action will move the object it is attached to to the new position in a period of time
        /// </summary>
        public class MovePositionAction : Action
        {
            public Vector3 newposition;
            public float time;

            public override ActionError Execute(Interaction caller)
            {
                LeanTween.move(gameObject, newposition, time);

                return ActionError.None;
            }
        }//end of class

    }//namespace
}//namespace