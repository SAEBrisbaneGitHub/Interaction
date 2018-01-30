using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace WindyWolfGames
{
    namespace InteractionTool
    {
        [System.Serializable]
        public class TagCollection
        {
            [SerializeField]
            protected List<string> tags = new List<string>();

            public bool CanPass(string compare)
            {
                return (tags.Count == 0 || tags.Contains(compare));
            }
        }//end of class
    }//namespace
}//namespace