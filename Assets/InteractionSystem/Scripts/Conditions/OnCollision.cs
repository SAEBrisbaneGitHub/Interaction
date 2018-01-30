using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace WindyWolfGames
{
    namespace InteractionTool
    {
        public enum PhysicsEventTypes
        {
            Enter,
            Exit,
            StayInside
        }

        /// <summary>
        /// This condition handles all the stages of a collision
        /// </summary>
        public class OnCollision : Condition
        {
            [Tooltip("This determins the tags that this collision is checking against\nif no tags it will work for any collision")]
            public TagCollection tagsCol = new TagCollection();

            public PhysicsEventTypes eventType = PhysicsEventTypes.Enter;

            public float frequency = 1.0f;

            public float lastTimeTriggerStay;
            public bool checkEveryFrame = false;

            private void OnCollisionEnter(Collision col)
            {
                if (eventType == PhysicsEventTypes.Enter)
                {
                    Process(col);
                }
                else if (eventType == PhysicsEventTypes.StayInside)
                {
                    Process(col);
                }
            }

            private void OnCollisionStay(Collision col)
            {
                if (checkEveryFrame && eventType == PhysicsEventTypes.StayInside && Time.time >= lastTimeTriggerStay + frequency)
                {
                    Process(col);
                }
            }

            private void OnCollisionExit(Collision col)
            {
                if (eventType == PhysicsEventTypes.Enter)
                {
                    Process(col);
                }
                else if (eventType == PhysicsEventTypes.StayInside)
                {
                    base.ResetCondition();
                }
            }

            private void Process(Collision col)
            {
                if (tagsCol.CanPass(col.gameObject.tag))
                {
                    ConditionIsTrue();
                }
            }

            public override void ResetCondition()
            {
                if (eventType == PhysicsEventTypes.StayInside && !checkEveryFrame)
                    return;

                base.ResetCondition();
            }
        }//end of class

    }//namespace
}//namespace