using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace WindyWolfGames
{
    namespace InteractionTool
    {
        /// <summary>
        /// This condition handles all Trigger conditions for an object
        /// </summary>
        public class OnTrigger : Condition
        {
            [Tooltip("This determins the tags that this collision is checking against\nif no tags it will work for any collision")]
            public TagCollection tagsCol = new TagCollection();

            public PhysicsEventTypes eventType = PhysicsEventTypes.Enter;

            public float frequency = 1.0f;

            public float lastTimeTriggerStay;
            public bool checkEveryFrame = false;

            // Use this for initialization
            void Start()
            {
                lastTimeTriggerStay = -frequency;
            }

            private void OnTriggerEnter(Collider other)
            {
                if (eventType == PhysicsEventTypes.Enter)
                {
                    Process(other);
                }
                else if (eventType == PhysicsEventTypes.StayInside)
                {
                    Process(other);
                }
            }

            private void OnTriggerStay(Collider other)
            {
                if (checkEveryFrame && eventType == PhysicsEventTypes.StayInside && Time.time >= lastTimeTriggerStay + frequency)
                {
                    Process(other);
                }
            }

            private void OnTriggerExit(Collider other)
            {
                if (eventType == PhysicsEventTypes.Exit)
                {
                    Process(other);
                }
                else if (eventType == PhysicsEventTypes.StayInside)
                {
                    base.ResetCondition();
                }
            }

            private void Process(Collider col)
            {
                if (tagsCol.CanPass(col.gameObject.tag))
                {
                    ConditionIsTrue();
                }
            }

            public override void ResetCondition()
            {
                if (eventType == PhysicsEventTypes.StayInside & !checkEveryFrame)
                {
                    return;
                }


                base.ResetCondition();
            }
        }//end of class

    }//namespace
}//namespace