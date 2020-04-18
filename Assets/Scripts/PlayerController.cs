using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 2.0f;

    private Animator animator;
    private CharacterController characterController;
    private Vector3 prevDir = Vector3.forward;
    private Vector3 dir = Vector3.zero;
    private float yPos;

    // Start is called before the first frame update
    void Start()
    {
        characterController = GetComponent<CharacterController>();
        animator = GetComponent<Animator>();
        yPos = transform.position.y;
    }

    // Update is called once per frame
    void Update()
    {
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
        transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(prevDir), 0.2f);
        characterController.Move(dir.normalized * speed * Time.deltaTime);

        animator.SetFloat("Speed", characterController.velocity.magnitude);

        Vector3 temp = transform.position;
        temp.y = yPos;
        transform.position = temp;
    }
}
