using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class PlayerAnimationControl : MonoBehaviour
{
    Rigidbody rb;
    public Animator animator;
    NavMeshAgent agent;
    
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        animator = GetComponent<Animator>();
        agent = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        ChangeAnim();
    }
    void ChangeAnim()
    {
        if (agent.velocity.magnitude > 0.5)
        {
            animator.SetBool("OnMove", true);
        }
        else
        {
            animator.SetBool("OnMove", false);
        }
        float speed = agent.velocity.magnitude;
        animator.SetFloat("Speed", speed);
        
    }
}
