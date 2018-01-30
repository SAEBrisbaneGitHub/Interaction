# Interaction

Allows for the configuration of simple condition and response chains to game state entirely within the inspector. This tool uses a Condition-Action structure where a list of actions is run when its corresponding list of conditions are true. It is intended to be simple to understand and extend. 

This project is ongoing and should be considered pre-alpha, as such feature set and API may change in the future. It currently provides the following:

* Interactions:
  * Interaction
  * InteractionManager !!!DO NOT PUT IN SCENE!!!
* Conditions:
  * OnCollision
    * Enter
    * Stay
    * Exit
  * OnKeyPress
    * Down
    * Stay
    * Up
  * OnResourceValue
    * \>
    * \>=
    * ==
    * <=
    * <
  * OnTrigger
    * Enter
    * Stay
    * Exit
* Actions:
  * ChangeBackgroundAudio
  * CreateObject
  * LoadScene
  * ModifyResource
  * PlayOneShot
  * SetVelocity
  * SpawnParticleEffect
  * TeleportObject
  * ToggleEnabled
* Movement:
  * RotatingObject
  * ScrollingObject
  * TextureOffset
  * UniDirectionalOscillation
* Audio:
  * AudioManager (*Unused*)
  * OneShotManager !!!DO NOT PUT IN SCENE!!!
  * BackgroundAudioManager
* Player:
  * ResourcePool
 
# Interactions
The interaction class is how conditions cause actions to happen.
In order for any interaction to take place an interaction script must be put on an object, the condition list must have conditions within it, and any actions that want to be completed must be put in the list of actions within the interaction script.

The InteractionManager does not need to be added to the game manually and further it should not be. It is automatically created when needed.

# Conditions
There are two types of conditions
1) Conditions that are true for a single frame (Marked: *Single Frame*)
2) Conditions that are true for an indefinate period of time (Marked: *Indetermanate*)

Any condition that you want to trigger an action must be within a interaction's condition list.
A condition CAN be put in any number of interactions condition lists

## OnCollision:
There is a list of tags that are checked for checking if the condition is true, the condition will be true only if collided with an object that has a tag within the list, or anything if the list is empty.

The Event type enum determines if the condition is about onCollision(Enter *Single Frame*, Stay *Indetermanate*, or Exit *Single Frame*)

Frequency is only used for Stay and is the amount of seconds between times this condition will activate the actions if it is true (disabled unless CheckEveryFrame is true)

Last Time triggered is used only in code

Check every frame is less efficient, but can be enabled if the condition is not working well with other conditions.

## OnKeyPress
Key Code, Listed similarly to an enum, find the key you want to tie this condition to

Event type:
  Just Pressed *Single Frame*
  Released *Single Frame*
  Kept Pressed *Indetermanate*

Frequency and Last time used the same wass as OnCollision

## OnResourceValue
Custom inspector to help with selecting a Resource pool and a resource from that pool

Event type (all *Indetermanate*)

 * \>
 * \>=
 * ==
 * <=
 * <

Value to check against resource:
  This value is on the right of the sign in relation to the resource, eg. resource >= value

## OnTrigger
Same As On Collision but for triggers

# Actions:
These are assigned to an Interaction and called when the corresponding conditions in that Interaction are all true.

## ChangeBackgroundAudio
The background audio can be changed by an int, that can be a resource value or it can be an int that is directly sent

For a resource the resource pool must be selected and the string representing the resource

for an int the int must just be set, -1 for resource, anything else for int

## CreateObjectAction
Spawns a prefab at a location and if a parent is set the prefab will be a child of that parent

## LoadSceneAction
A scene can be loaded by name, 0 in order to reload the current scene

## ModifyResourceAction
Target pool and resource to modify can be set through the custom inspector

Modify value is added to the resource whenever the action is called

## PlayOneShotAction
Plays the clip attached once whenever the action is called

## SetVelocityAction
Sets the velocity on the object that the action is attached to

## SpawnParticleAction 
spawns the particle effect prefab ata location or on the object that the action is attached to

## TeleportObjectAction
Teleports self to either a location or the location of an object

## ToggleEnabledAction
Toggles Self(whole object)
or
Toggles object
or
toggles a component

**only set one**

# Audio

## BackgroundAudioManager
If you want to use background music this must be put into the scene
it just contains a list of min/max values and clips as well as a swap sound when a music is to be swaps

## OneShotManager
***This Will Put Itself Into The Scene***

# Player

## ResourcePool
Many of these can be placed into the scene, Add resources to them as strings, and they can be monitored and changed based on Actions
A custom inspector is provided to help

# Spawning

## SingleObjectSpawning
For preset spawning it will spawn the prefabs at the positions in the list of vector3s
The button puts them into the scene, but this is unneccesary it will put them into the scene at run ime

For randomish spawning
set the location to spawn them at
the min and max distance between two spawns and the step
so if the min is 10 and the max 30 and the step 10 they will spawn either 10,20, or 30 away from the last

# Misc

## Destroy touching
Destroys everything that touches it
can be set to only destroy certain tags
