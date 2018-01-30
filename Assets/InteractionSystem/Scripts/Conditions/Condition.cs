using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace WindyWolfGames
{
    namespace InteractionTool
    {
        /// <summary>
        /// Base condition class
        /// </summary>
        public abstract class Condition : MonoBehaviour
        {
            [Tooltip("This bool determins if this condition returns:\nTrue or false when it is met")]
            public bool not = false;


            private List<Interaction> _ThisConditionsInteractions = new List<Interaction>();
            public List<Interaction> thisConditionsInteractions
            {
                get
                {
                    return _ThisConditionsInteractions;
                }
            }

            private bool isConditionFulfilled;
            public virtual bool IsConditionFulfilled
            {
                get
                {
                    if (not)
                    {
                        return !isConditionFulfilled;
                    }
                    else
                    {
                        return isConditionFulfilled;
                    }

                }
            }

            public virtual void ConditionIsTrue()
            {
                //TODO be smarter than this
                isConditionFulfilled = true;

                for (int index = 0; index < _ThisConditionsInteractions.Count; ++index)
                {
                    InteractionManager.Instance.AddInteractionToProcess(this);
                }
            }

            public virtual void ResetCondition()
            {
                isConditionFulfilled = false;
            }

            public void AddInteraction(Interaction toAdd)
            {
                if (!_ThisConditionsInteractions.Contains(toAdd))
                {
                    _ThisConditionsInteractions.Add(toAdd);
                }
            }

            public void RemoveInteraction(Interaction toRemove)
            {
                _ThisConditionsInteractions.Remove(toRemove);
            }

        }//end of class

    }//namespace
}//namespace