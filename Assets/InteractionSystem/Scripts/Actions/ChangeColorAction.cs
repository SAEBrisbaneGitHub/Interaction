using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace WindyWolfGames
{
    namespace InteractionTool
    {
        /// <summary>
        /// This action will change the color of an object, must have a MeshRenderer
        /// </summary>
        [RequireComponent(typeof(MeshRenderer))]
        public class ChangeColorAction : Action
        {
            public enum TransitionStyle
            {
                Instant,
                LeanTween
            }
            [Tooltip("Instant: changes color Instantly\nLeanTween takes time amount of time")]
            public TransitionStyle style;
            public Color col;
            public float time = 0;

            private MeshRenderer mr;

            private void Start()
            {
                mr = GetComponent<MeshRenderer>();
            }

            public override ActionError Execute(Interaction caller)
            {
                switch (style)
                {
                    case TransitionStyle.Instant:
                        mr.material.color = col;
                        break;
                    case TransitionStyle.LeanTween:
                        LeanTween.color(gameObject, col, time);
                        break;
                }
                return ActionError.None;
            }
        }//end of class

    }//namespace
}//namespace