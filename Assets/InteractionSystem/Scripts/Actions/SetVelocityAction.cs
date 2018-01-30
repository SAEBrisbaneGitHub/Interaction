using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace WindyWolfGames
{
    namespace InteractionTool
    {
        /// <summary>
        /// This action will set the velocity of the object it is attached to, requires a rigidbody
        /// </summary>
        [RequireComponent(typeof(Rigidbody))]
        public class SetVelocityAction : Action
        {
            public enum VelocityPossibilities
            {
                Static,
                RandomDirection,
                RandomDirectionAndVelocity
            }

            [Tooltip("Static: uses the direction and velocity\nRandomDirection: uses the velocity but randomizes the direction in a unitSphere\nRandomDirectionAndVelocity: as with direction but velocity is randomized between 0 and the velocity")]
            public VelocityPossibilities type = VelocityPossibilities.Static;
            public Vector3 direction;
            public float velocity;


            private Rigidbody rb;

            private void Start()
            {
                rb = GetComponent<Rigidbody>();
            }

            public override ActionError Execute(Interaction caller)
            {
                switch (type)
                {
                    case VelocityPossibilities.Static:
                        rb.velocity = direction.normalized * velocity;
                        break;
                    case VelocityPossibilities.RandomDirection:
                        rb.velocity = Random.insideUnitSphere * velocity;
                        break;
                    case VelocityPossibilities.RandomDirectionAndVelocity:
                        rb.velocity = Random.insideUnitSphere * Random.Range(0.0f, velocity);
                        break;
                }
                return ActionError.None;
            }
        }//end of class

    }//namespace
}//namespace