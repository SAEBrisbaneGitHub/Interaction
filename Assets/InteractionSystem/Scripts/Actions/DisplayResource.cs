using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace WindyWolfGames
{
    namespace InteractionTool
    {
        /// <summary>
        /// This class displays a resource in a Text ui object
        /// </summary>
        public class DisplayResource : Action
        {
            public Text textUIRef;
            public string resourceToGet;

            public string preString;
            public string postString;

            public override ActionError Execute(Interaction caller)
            {
                if (textUIRef == null)
                    return ActionError.NullData;

                textUIRef.text = preString + ResourcePool._inst.GetResource(resourceToGet).ToString() + " " + resourceToGet + postString;
                return ActionError.None;
            }
        }//end of class

    }//namespace
}//namespace

