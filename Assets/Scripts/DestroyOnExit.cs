using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// class which controls the destruction of an animated object
/// </summary>
public class DestroyOnExit : StateMachineBehaviour
{
    /// <summary>
    /// destroys the object at the end of it's animation
    /// </summary>
    /// <param name="animator">animator assigned to the object</param>
    /// <param name="stateInfo">info about the animation</param>
    /// <param name="layerIndex">layer index of the animation</param>
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        Destroy(animator.gameObject, stateInfo.length);
    }
}
