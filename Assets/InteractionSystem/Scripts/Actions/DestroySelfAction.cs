using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace WindyWolfGames
{
    namespace InteractionTool
    {
        /// <summary>
        /// This will destroy the entire gameobject it is attached to
        /// </summary>
        public class DestroySelfAction : Action
        {
            public override ActionError Execute(Interaction caller)
            {
                Destroy(gameObject);
                return ActionError.None;
            }
        }//end of class

    }//namespace
}//namespace