using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tut_contr_script : MonoBehaviour
{
    public float animSpeed = 1.5f;
    public bool useCurves;
    public float modelHeight = 2.0f;
    public float modelCenter = 2.0f;
    private Animator anim;

    private AnimatorStateInfo currentBaseState;
    private AnimatorStateInfo layer2CurrentState;

    private CapsuleCollider col;

    static int idleState = Animator.StringToHash("Base Layer.Idle");
    static int locoState = Animator.StringToHash("Base Layer.Locomotion");
    static int jumpState = Animator.StringToHash("Base Layer.Jump");
    static int waveState = Animator.StringToHash("Layer2.Wave");


    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        col = GetComponent<CapsuleCollider>();

        if (anim.layerCount == 2)
        {
            anim.SetLayerWeight(1, 1);
        }
    }

    // Update is called once per frame
    void Update()
    {
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");

        anim.SetFloat("Speed", v);
        anim.SetFloat("Direction", h);
        anim.speed = animSpeed;

        currentBaseState = anim.GetCurrentAnimatorStateInfo(0);

        if (anim.layerCount == 2 )
        {
            layer2CurrentState = anim.GetCurrentAnimatorStateInfo(1);
        }

        if (currentBaseState.fullPathHash == locoState)
        {
            if (Input.GetButtonDown("Jump"))
            {
                anim.SetBool("Jump", true);
            }
        }
        else if (currentBaseState.fullPathHash == jumpState)
        {
            if (!anim.IsInTransition(0))
            {
                if (useCurves)
                {
                    col.height = anim.GetFloat("ColliderHeight") / 2.0f * modelHeight;

                    anim.SetBool("Jump", false);
                }
            }
        }
        else if (currentBaseState.fullPathHash == idleState)
        {
            if (Input.GetButtonUp("Jump"))
            {
                anim.SetBool("Wave", true);
            }
        }

        if (layer2CurrentState.fullPathHash == waveState)
        {
            anim.SetBool("Wave", false);
        }
    }
}
