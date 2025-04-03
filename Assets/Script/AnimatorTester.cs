using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    
    public Animator animator;
    public Animation cube;
    void Start()
    {


        //animator.SetFloat("DamageFloat", 0.5f);


        /*
        animator.SetBool();
        Trigger, Integer, Float µîµî............
        */
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            animator.SetTrigger("JumpTrigger");
        }
    }
    public void Jump()
    {
        animator.SetTrigger("JumpTrigger");
    }
    public void Attack()
    {
        animator.SetTrigger("AttackTrigeer");
    }
    public void Damage()
    {
        animator.SetTrigger("Damage");
    }
   public void CubeAnimation()
    {
        cube.Play("CubeRotate");
    }
}
