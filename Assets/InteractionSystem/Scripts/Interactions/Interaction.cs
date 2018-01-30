using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace WindyWolfGames
{
    namespace InteractionTool
    {
        /// <summary>
        /// Object that binds together a collection of conditions that then cause a
        /// collection of actions to fire.
        /// </summary>
        public class Interaction : MonoBehaviour
        {
            public bool canOnlyHappenOnce = false;

            public List<Condition> InteractionConditions = new List<Condition>();
            public List<Action> ActionsToUnderTake = new List<Action>();

            private void OnEnable()
            {
                for (int index = 0; index < InteractionConditions.Count; ++index)
                {
                    if (InteractionConditions[index] != null)
                    {
                        InteractionConditions[index].AddInteraction(this);
                    }
                }
            }

            private void OnDisable()
            {
                for (int index = 0; index < InteractionConditions.Count; ++index)
                {
                    if (InteractionConditions[index] != null)
                    {
                        InteractionConditions[index].RemoveInteraction(this);
                    }
                }
            }

            public void Process()
            {
                if (AreConditionsMet())
                {
                    RunAllActions();
                    ResetConditions();

                    if (canOnlyHappenOnce)
                    {
                        enabled = false;
                    }
                }
            }

            bool AreConditionsMet()
            {
                for (int i = 0; i < InteractionConditions.Count; ++i)
                {
                    if (InteractionConditions[i] != null && !InteractionConditions[i].IsConditionFulfilled)
                        return false;
                }

                return true;
            }

            void ResetConditions()
            {
                for (int index = 0; index < InteractionConditions.Count; ++index)
                {
                    if (InteractionConditions[index] != null)
                    {
                        InteractionConditions[index].ResetCondition();
                    }
                }
            }

            void RunAllActions()
            {
                for (int index = 0; index < ActionsToUnderTake.Count; ++index)
                {
                    if (ActionsToUnderTake[index] != null)
                    {
                        switch (ActionsToUnderTake[index].Execute(this))
                        {

                            case ActionError.None:
                                //does anything happen on no error??? if not delete this case
                                break;

                            case ActionError.CannotCos:
                                print("CannotCos Error");
                                break;

                            case ActionError.NullData:
                                print(ActionsToUnderTake[index].GetType().ToString() + " has null data");
                                break;

                        }
                    }
                }
            }
        }//end of class
    }//namespace
}//namespace