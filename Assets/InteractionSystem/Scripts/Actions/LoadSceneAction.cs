using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace WindyWolfGames
{
    namespace InteractionTool
    {
        /// <summary>
        /// This action loads a new scene, or reloads the current one
        /// </summary>
        public class LoadSceneAction : Action
        {
            [Header("0 to reload this scene")]
            public string sceneName = "0";

            public override ActionError Execute(Interaction caller)
            {

                if (sceneName == "0")
                {
                    SceneManager.LoadScene(SceneManager.GetActiveScene().name, LoadSceneMode.Single);
                }
                else
                {
                    SceneManager.LoadScene(sceneName, LoadSceneMode.Single);
                }

                return ActionError.None;
            }
        }//end of class

    }//namespace
}//namespace