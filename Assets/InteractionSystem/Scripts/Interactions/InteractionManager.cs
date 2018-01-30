using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace WindyWolfGames
{
    namespace InteractionTool
    {
        /// <summary>
        /// DO NOT PUT IN SCENE
        /// it will put itself in
        /// This is the efficiency aspect to interactions
        /// will only check interactions when a condition becomes true
        /// </summary>
        [AddComponentMenu("")]
        public class InteractionManager : MonoBehaviour
        {
            private List<Interaction> interactionsToProcess = new List<Interaction>();
            private List<Condition> conditionsToStartInteractions = new List<Condition>();

            private void Update()
            {
                ProcessInteractions();
            }

            private void ProcessInteractions()
            {
                for (int index = 0; index < interactionsToProcess.Count; ++index)
                {
                    interactionsToProcess[index].Process();
                }

                for (int i = 0; i < conditionsToStartInteractions.Count; ++i)
                {
                    conditionsToStartInteractions[i].ResetCondition();
                }

                //i think this is okay??
                //if they are all true this should be removed
                //if not all of them are true the next one that is true will put this back here
                interactionsToProcess.Clear();
                conditionsToStartInteractions.Clear();
            }

            public void AddInteractionToProcess(Condition toAdd)
            {
                if (!conditionsToStartInteractions.Contains(toAdd))
                {
                    conditionsToStartInteractions.Add(toAdd);
                }

                for (int index = 0; index < toAdd.thisConditionsInteractions.Count; ++index)
                {
                    if (!interactionsToProcess.Contains(toAdd.thisConditionsInteractions[index]))
                    {
                        interactionsToProcess.Add(toAdd.thisConditionsInteractions[index]);
                    }
                }
            }

            //Singleton
            private static InteractionManager _inst;

            public static InteractionManager Instance
            {
                get
                {
                    if (_inst != null)
                    {
                        return _inst;
                    }
                    else
                    {
                        var newGo = new GameObject("InteractionManager");
                        DontDestroyOnLoad(newGo);
                        _inst = newGo.AddComponent<InteractionManager>();
                        return _inst;
                    }
                }
            }
        }//end of class

    }//namespace
}//namespace