using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimplePlayer : MonoBehaviour
{
    public float speed = 7.5f;

    CharacterController characterController;
    Vector3 moveDirection = Vector3.zero;
    float yPos;

    // Start is called before the first frame update
    void Start()
    {
        characterController = GetComponent<CharacterController>();
        yPos = transform.position.y; 
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 forward = transform.TransformDirection(Vector3.forward);
        Vector3 right = transform.TransformDirection(Vector3.right);
        float curSpeedX = speed * Input.GetAxis("Vertical");
        float curSpeedY = speed * Input.GetAxis("Horizontal");
        moveDirection = (forward * curSpeedX) + (right * curSpeedY);

        characterController.Move(moveDirection * Time.deltaTime);
        Vector3 temp = transform.position;
        temp.y = yPos;
        transform.position = temp;
    }
}
