using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using System.Linq;

namespace WindyWolfGames
{
    namespace InteractionTool
    {
        [System.Serializable]
        public class Resource
        {
            public string name;
            public float value;
            public UnityEvent resourceChanged = new UnityEvent();
        }

        /// <summary>
        /// this must be filled with resources
        /// </summary>
        [System.Serializable]
        public class ResourcePool : MonoBehaviour
        {
            public static ResourcePool _inst;

            //simple singleton, has to actually be placed
            private void Awake()
            {
                if (_inst != null)
                {
                    DestroyImmediate(this);
                }
                else
                {
                    _inst = this;
                }
            }

            //public string ResourcePoolName = "Default";
            public List<Resource> pool = new List<Resource>();

            //public Dictionary<string, Resource> AvaliableResources = new Dictionary<string, Resource>();

            public bool HasResource(string resource)
            {
                return pool.Find(x => x.name == resource) != null;
                //return AvaliableResources.ContainsKey(resource);
            }

            public float GetResource(string resource)
            {
                return pool.Find(x => x.name == resource).value;
                //return AvaliableResources[resource].value;
            }

            public void ModifyResource(string resource, float amountToAdd)
            {
                pool.Find(x => x.name == resource).value += amountToAdd;
                pool.Find(x => x.name == resource).resourceChanged.Invoke();
                //AvaliableResources[resource].value += amountToAdd;
                //AvaliableResources[resource].resourceChanged.Invoke();
            }

            public UnityEvent ResourceChanged(string resource)
            {
                return pool.Find(x => x.name == resource).resourceChanged;
                //return AvaliableResources[resource].resourceChanged;
            }
        }//end of class

    }//namespace
}//namespace