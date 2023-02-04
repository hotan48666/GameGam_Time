using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{

    public Animator animator;
    public Animator bowAnim;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
    }



    public void AttackAnimation()
    {
        animator.SetBool("IsAttack", true);
        bowAnim.SetBool("BowShoot", true);
    }

    public void AttackAnimationEnd()
    {
        animator.SetBool("IsAttack", false);
        bowAnim.SetBool("BowShoot", false);
    }
}
