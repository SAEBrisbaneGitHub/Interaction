using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace WindyWolfGames
{
    namespace InteractionTool
    {
        /// <summary>
        /// This action triggers animations
        /// </summary>
        [RequireComponent(typeof(Animator))]
        public class AnimatorAction : Action
        {
            public enum AnimatorTypes
            {
                Float,
                Int,
                Bool,
                Trigger
            }

            public AnimatorTypes type = AnimatorTypes.Trigger;

            public string variableName;
            [Tooltip("For Float: any number\nFor Int: it will round\nFor Bool: 1 = true, anything else = false\nFor Trigger: ignored")]
            public float value;

            private Animator anim;

            private void Start()
            {
                anim = GetComponent<Animator>();
            }

            public override ActionError Execute(Interaction caller)
            {
                switch (type)
                {
                    case AnimatorTypes.Trigger:
                        anim.SetTrigger(variableName);
                        break;
                    case AnimatorTypes.Int:
                        anim.SetInteger(variableName, Mathf.RoundToInt(value));
                        break;
                    case AnimatorTypes.Float:
                        anim.SetFloat(variableName, value);
                        break;
                    case AnimatorTypes.Bool:
                        anim.SetBool(variableName, value == 1);
                        break;
                }

                return ActionError.None;
            }
        }//end of class

    }//namespace
}//namespace