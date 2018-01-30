using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace WindyWolfGames
{
    namespace InteractionTool
    {
        /// <summary>
        /// This will instantiate the particle effect at this location and destroy it after the duration is done
        /// </summary>
        public class SpawnParticleAction : Action
        {
            [Tooltip("The effect can spawn on self or at a location,\nLocation is in world space ")]
            public ParticleSystem particleEffect;
            public bool spawnOnSelf;
            public Vector3 spawnLocation;

            [Tooltip("Destroys the particle effect at the end of the particle effects duration")]
            public bool selfKillParticleEffect;

            public override ActionError Execute(Interaction caller)
            {

                if (particleEffect == null)
                    return ActionError.NullData;


                Vector3 spawnLoc;

                if (spawnOnSelf)
                {
                    spawnLoc = gameObject.transform.position;
                }
                else
                {
                    spawnLoc = spawnLocation;
                }

                ParticleSystem sys = Instantiate(particleEffect.gameObject, spawnLoc, Quaternion.identity).GetComponent<ParticleSystem>();

                if (selfKillParticleEffect)
                {
                    Destroy(sys.gameObject, sys.main.duration);
                }
                return ActionError.None;
            }
        }//end of class

    }//namespace
}//namespace