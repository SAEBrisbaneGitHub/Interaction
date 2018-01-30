using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace WindyWolfGames
{
    namespace InteractionTool
    {
        /// <summary>
        /// This action will create a prefab and it has some variables to determine how
        /// </summary>
        public class CreateObjectAction : Action
        {
            public enum ObjectCreationMethods
            {
                Location,
                RadiusFromPoint,
                LocationRelativeToParent
            }

            public ObjectCreationMethods type = ObjectCreationMethods.Location;

            public GameObject prefab;
            public Vector3 location;
            public bool spawnAsChild;
            public GameObject parent;
            public float radius;

            public override ActionError Execute(Interaction caller)
            {


                if (prefab == null)
                    return ActionError.NullData;

                Vector3 loc = Vector3.zero;

                switch (type)
                {
                    case ObjectCreationMethods.Location:
                        loc = location;
                        break;
                    case ObjectCreationMethods.RadiusFromPoint:
                        loc = location + Random.insideUnitSphere * radius;
                        break;
                    case ObjectCreationMethods.LocationRelativeToParent:
                        if (parent != null)
                        {
                            loc = parent.transform.position + location;
                        }
                        else
                        {
                            loc = location;
                        }
                        break;
                }


                GameObject obj = Instantiate(prefab, loc, Quaternion.identity);

                if (spawnAsChild && parent != null)
                {
                    obj.transform.parent = parent.transform;
                }

                return ActionError.None;
            }
        }//end of class

    }//namespace
}//namespace