using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace WindyWolfGames
{
    namespace InteractionTool
    {
        /// <summary>
        /// This action will change the background audio using the Background Audio Manager
        /// </summary>
        public class ChangeBackgroundAudioAction : Action
        {

            public string resourceToSend = string.Empty;
            [Tooltip("Used instead of resourceToSend if not -1.")]
            public int intToSend = -1;

            public override ActionError Execute(Interaction caller)
            {
                if (BackgroundAudioManager._inst != null)
                {
                    if (intToSend != -1)
                    {
                        BackgroundAudioManager._inst.PlayNext(intToSend);
                        return ActionError.None;
                    }
                    else
                    {
                        if (ResourcePool._inst.HasResource(resourceToSend))
                        {
                            BackgroundAudioManager._inst.PlayNext((int)ResourcePool._inst.GetResource(resourceToSend));
                            return ActionError.None;
                        }
                        else
                        {
                            print("Target Pool does not have that resource");
                            return ActionError.CannotCos;
                        }
                    }
                }
                else
                {
                    print("There is no Background Audio Manager");
                    return ActionError.CannotCos;
                }
            }
        }//end of class

    }//namespace
}//namespace