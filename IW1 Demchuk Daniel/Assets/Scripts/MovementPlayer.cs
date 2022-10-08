using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementPlayer : MonoBehaviour
{
    // Start is called before the first frame update
    public float movementSpeed = 5f;
    public float jumpHeight = 15f;
    CapsuleCollider capsuleCollider;
    Rigidbody rbody;
    CharacterController characterController;
    void Start()
    {
        rbody = GetComponent<Rigidbody>();
        capsuleCollider = GetComponent<CapsuleCollider>();
        characterController = GetComponent<CharacterController>();
    }
    private void FixedUpdate()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        Vector2 movementVector = new Vector2(horizontalInput * movementSpeed * 100 * Time.deltaTime, rbody.velocity.y);
        Debug.Log(Time.deltaTime);
        rbody.velocity = movementVector;
    }
    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Jump"))
        {
            if (!capsuleCollider.isGrounded) return;
            rbody.AddForce(Vector2.up * jumpHeight, ForceMode.Impulse);
        }
    }
}