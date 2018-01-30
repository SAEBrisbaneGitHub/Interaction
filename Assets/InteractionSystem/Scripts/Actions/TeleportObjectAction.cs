using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace WindyWolfGames
{
    namespace InteractionTool
    {
        /// <summary>
        /// this action will teleport itself to either a location or directly on top of an object
        /// </summary>
        public class TeleportObjectAction : Action
        {
            private bool teleportSelf = true;
            [Tooltip("will teleport to the location if the object is null")]
            public Vector3 teleportLocation;
            public GameObject objectToTeleportTo;

            public override ActionError Execute(Interaction caller)
            {
                //if (actionData == null)
                //{
                //    return ActionError.CannotCos;
                //}


                GameObject teleportObject;

                if (teleportSelf)
                {
                    teleportObject = gameObject;
                }
                else
                {
                    teleportObject = gameObject;
                    //teleportObject = other;
                }

                if (objectToTeleportTo != null)
                {
                    teleportObject.transform.position = objectToTeleportTo.transform.position;
                }
                else
                {
                    teleportObject.transform.position = teleportLocation;
                }

                return ActionError.None;
            }

        }//end of class

    }//namespace
}//namespace