using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace WindyWolfGames
{
    namespace InteractionTool
    {
        /// <summary>
        /// Raycast from mouse position against given camera when key is pressed
        /// </summary>
        public class OnClick : Condition
        {
            [Tooltip("This determins what layer to raytrace,\nAllows for buttons behind other things")]
            public LayerMask layerToCheck;
            public KeyCode keycode = KeyCode.Mouse0;

            [Tooltip("Camera to use to convert mouse position into ray. If null Camera.main is used.")]
            public new Camera camera;

            private void Update()
            {
                if (Input.GetKeyDown(keycode))
                {
                    Ray mouseRay = (camera == null ? Camera.main : camera).ScreenPointToRay(Input.mousePosition);
                    RaycastHit hitInfo;
                    if (Physics.Raycast(mouseRay, out hitInfo, layerToCheck))
                    {
                        if (hitInfo.collider.gameObject == gameObject)
                        {
                            ConditionIsTrue();
                        }
                    }
                }
            }

        }//end of class

    }//namespace
}//namespace