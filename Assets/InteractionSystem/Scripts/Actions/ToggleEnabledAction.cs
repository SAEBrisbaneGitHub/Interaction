using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace WindyWolfGames
{
    namespace InteractionTool
    {
        /// <summary>
        /// This action enables disabled objects or disables enabled ones, beware that if it toggles itself it toggles the entire object
        /// </summary>
        public class ToggleEnabledAction : Action
        {
            [Tooltip("Will toggle all 3 if able\nToggleComponent only works on Monobehaviour scripts currently")]
            public bool toggleSelf;
            public GameObject toggleObject;
            public MonoBehaviour toggleComponent;

            public override ActionError Execute(Interaction caller)
            {

                if (toggleObject != null)
                {
                    toggleObject.SetActive(!toggleObject.activeInHierarchy);
                }

                if (toggleComponent != null)
                {
                    toggleComponent.enabled = !toggleComponent.enabled;
                }

                if (toggleSelf)
                {
                    gameObject.SetActive(!gameObject.activeInHierarchy);
                }

                return ActionError.None;
            }

        }//end of class

    }//namespace
}//namespace