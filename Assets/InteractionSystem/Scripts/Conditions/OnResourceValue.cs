using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace WindyWolfGames
{
    namespace InteractionTool
    {
        /// <summary>
        /// This class uses the Resource pool and monitors resources becoming true when the math formula is true
        /// </summary>
        public class OnResourceValue : Condition
        {
            [System.Serializable]
            public enum ResourceCheckType
            {
                Greater,
                GreaterOrEqual,
                ExactlyEqual,
                LessOrEqual,
                Less
            }

            [Tooltip("this string represents the resource in the ResourcePool that is to be monitored")]
            public string MonitoringResource;

            [Tooltip("This determins what kind of math check is done on the resource")]
            public ResourceCheckType eventType = ResourceCheckType.ExactlyEqual;
            public int value = 0;

            private void Start()
            {
                if (ResourcePool._inst.HasResource(MonitoringResource))
                {
                    ResourcePool._inst.ResourceChanged(MonitoringResource).AddListener(ResourceChanged);
                }
                else
                {
                    print("Resource is not set up");
                }
            }

            public void ResourceChanged()
            {
                if (!ResourcePool._inst.HasResource(MonitoringResource))
                {
                    return;
                }

                float fetchedResourceValue = ResourcePool._inst.GetResource(MonitoringResource);

                switch (eventType)
                {
                    case ResourceCheckType.Greater:
                        if (fetchedResourceValue > value)
                        {
                            ConditionIsTrue();
                        }
                        else
                        {
                            ResetCondition();
                        }
                        break;
                    case ResourceCheckType.GreaterOrEqual:
                        if (fetchedResourceValue >= value)
                        {
                            ConditionIsTrue();
                        }
                        else
                        {
                            ResetCondition();
                        }
                        break;
                    case ResourceCheckType.ExactlyEqual:
                        if (fetchedResourceValue == value)
                        {
                            ConditionIsTrue();
                        }
                        else
                        {
                            ResetCondition();
                        }
                        break;
                    case ResourceCheckType.LessOrEqual:
                        if (fetchedResourceValue <= value)
                        {
                            ConditionIsTrue();
                        }
                        else
                        {
                            ResetCondition();
                        }
                        break;
                    case ResourceCheckType.Less:
                        if (fetchedResourceValue < value)
                        {
                            ConditionIsTrue();
                        }
                        else
                        {
                            ResetCondition();
                        }
                        break;
                }
            }

            public override void ResetCondition()
            {
                //base.ResetCondition();
            }
        }//end of class

    }//namespace
}//namespace