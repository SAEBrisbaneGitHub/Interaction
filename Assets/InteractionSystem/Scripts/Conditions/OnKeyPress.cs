using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace WindyWolfGames
{
    namespace InteractionTool
    {
        /// <summary>
        /// This condition is true during a specific stage of a key press
        /// </summary>
        public class OnKeyPress : Condition
        {
            /// <summary>
            /// 
            /// </summary>
            [System.Serializable]
            public enum KeyEventTypes
            {
                JustPressed,
                Released,
                KeptPressed
            }

            [Tooltip("The key that is being monitored")]
            public KeyCode keyValue;

            [Tooltip("JustPressed: only on key down\nReleased: only on key up\nKeptPressed: true as long as the key is pressed, activates the event every frequency")]
            public KeyEventTypes eventType = KeyEventTypes.JustPressed;

            public bool checkEveryFrame = false;
            public float frequency = 1.0f;
            

            private void Update()
            {
                switch (eventType)
                {

                    case KeyEventTypes.JustPressed:
                        if (Input.GetKeyDown(keyValue))
                        {
                            ConditionIsTrue();
                        }
                        break;

                    case KeyEventTypes.KeptPressed:
                        if (Input.GetKeyDown(keyValue))
                        {
                            ConditionIsTrue();
                        }
                        if (Input.GetKeyUp(keyValue))
                        {
                            base.ResetCondition();
                        }

                        if (checkEveryFrame && Input.GetKey(keyValue))
                        {
                            ConditionIsTrue();
                        }
                        break;

                    case KeyEventTypes.Released:
                        if (Input.GetKeyUp(keyValue))
                        {
                            ConditionIsTrue();
                        }
                        break;
                }
            }


            public override void ResetCondition()
            {
                if (eventType == KeyEventTypes.KeptPressed && !checkEveryFrame)
                    return;

                base.ResetCondition();
            }
        }//end of class

    }//namespace
}//namespace