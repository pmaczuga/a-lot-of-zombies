using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : CharachterBehaviour
{
    public float speed = 2.0f;

    private CharacterController characterController;

    private Vector3 prevDir = Vector3.forward;
    private Vector3 dir = Vector3.zero;
    private float yPos;
    private int hitHash;
    private int dieHash;
    private UIScript uiScript;

    // Start is called before the first frame update
    override protected void Start()
    {
        base.Start();
        
        characterController = GetComponent<CharacterController>();
        uiScript = GameObject.Find("UIText").GetComponent<UIScript>();
        yPos = transform.position.y;

        hitHash = Animator.StringToHash("Base Layer.Hit");
        dieHash = Animator.StringToHash("Base Layer.Die");
    }

    // Update is called once per frame
    override protected void Update()
    {
        if (isDead)
            return;

        uiScript.SetHealth(health);

        dir = Vector3.zero;

        if (Input.GetAxis("Horizontal") > 0)
            dir += Vector3.right;
        if (Input.GetAxis("Horizontal") < 0)
            dir -= Vector3.right;
        if (Input.GetAxis("Vertical") > 0)
            dir += Vector3.forward;
        if (Input.GetAxis("Vertical") < 0)
            dir -= Vector3.forward;

        if (dir != new Vector3(0, 0, 0))
        {
            prevDir = dir;
        }
        if (CanMove())
        {
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(prevDir), 0.2f);
            characterController.Move(dir.normalized * speed * Time.deltaTime);

            animator.SetFloat("Speed", characterController.velocity.magnitude);
        }


        Vector3 temp = transform.position;
        temp.y = yPos;
        transform.position = temp;
    }

    private bool CanMove()
    {
        if (animator.GetCurrentAnimatorStateInfo(0).fullPathHash == hitHash)
        {
            return false;
        }
        if (animator.GetCurrentAnimatorStateInfo(0).fullPathHash == dieHash)
        {
            return false;
        }

        return true;
    }
}
