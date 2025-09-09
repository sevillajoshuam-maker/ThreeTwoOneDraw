using UnityEngine;
using System;

public class EnemyCardPreference : StateMachineBehaviour
{
    public float defendChance = 1.0f;
    public float bulletChance = 1.0f;
    public float skillChance = 1.0f;
    System.Random random = new System.Random();

    public string RollType()
    {
        float chanceSum = defendChance + bulletChance + skillChance;
        float chanceValue = (float) random.NextDouble();
        if (chanceValue < defendChance / chanceSum)
            return "Defend";
        if (chanceValue < (bulletChance + defendChance) / chanceSum)
            return "Bullet";
        return "Skill";
        
    }
    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        animator.gameObject.GetComponent<EnemyStateMachine>().SuggestType(RollType());    
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    //override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    
    //}

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    //override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    
    //}

    // OnStateMove is called right after Animator.OnAnimatorMove()
    //override public void OnStateMove(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    // Implement code that processes and affects root motion
    //}

    // OnStateIK is called right after Animator.OnAnimatorIK()
    //override public void OnStateIK(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    // Implement code that sets up animation IK (inverse kinematics)
    //}
}
