using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace WindyWolfGames
{
    namespace InteractionTool
    {
        /// <summary>
        /// This action modifies a resource in the resource pool
        /// </summary>
        public class ModifyResource : Action
        {
            [Tooltip("string of the resource to modify within the Resource Pool")]
            public string ResourceToModify;
            [Tooltip("This gets added to the resource")]
            public float ModifyValue;

            public override ActionError Execute(Interaction caller)
            {

                if (ResourcePool._inst.HasResource(ResourceToModify))
                {
                    ResourcePool._inst.ModifyResource(ResourceToModify, ModifyValue);
                }

                return ActionError.None;
            }
        }//end of class

    }//namespace
}//namespace