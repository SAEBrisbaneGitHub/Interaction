using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;


namespace WindyWolfGames
{
    namespace InteractionTool
    {
        [CustomEditor(typeof(Interaction))]
        [CanEditMultipleObjects]
        public class InteractionEditor : Editor
        {

            Component[] components;

            Interaction castedTarget;

            private void OnEnable()
            {
                castedTarget = (target as Interaction);
                components = castedTarget.GetComponents<Component>();
            }

            public override void OnInspectorGUI()
            {
                base.OnInspectorGUI();


                if (GUILayout.Button("Toggle Condition Visibility"))
                {
                    for (int i = 0; i < castedTarget.InteractionConditions.Count; ++i)
                    {
                        if (castedTarget.InteractionConditions[i].hideFlags == HideFlags.HideInInspector)
                        {
                            castedTarget.InteractionConditions[i].hideFlags = HideFlags.None;
                        }
                        else
                        {
                            castedTarget.InteractionConditions[i].hideFlags = HideFlags.HideInInspector;
                        }
                    }
                }

                if (GUILayout.Button("Toggle Action Visibility"))
                {
                    for (int i = 0; i < castedTarget.ActionsToUnderTake.Count; ++i)
                    {
                        if (castedTarget.ActionsToUnderTake[i].hideFlags == HideFlags.HideInInspector)
                        {
                            castedTarget.ActionsToUnderTake[i].hideFlags = HideFlags.None;
                        }
                        else
                        {
                            castedTarget.ActionsToUnderTake[i].hideFlags = HideFlags.HideInInspector;
                        }
                    }
                }

                GUILayout.Space(20);

                if (GUILayout.Button("Toggle Other Visibility"))
                {
                    for (int i = 0; i < components.Length; ++i)
                    {
                        if (!(components[i] is Interaction || components[i] is Action || components[i] is Condition))
                        {
                            if (components[i].hideFlags == HideFlags.HideInInspector)
                            {
                                components[i].hideFlags = HideFlags.None;
                            }
                            else
                            {
                                components[i].hideFlags = HideFlags.HideInInspector;
                            }
                        }
                    }
                }

                GUILayout.Space(10);

                if (GUILayout.Button("Show All"))
                {
                    for (int i = 0; i < components.Length; ++i)
                    {
                        components[i].hideFlags = HideFlags.None;
                    }
                }
            }
        }
    }
}