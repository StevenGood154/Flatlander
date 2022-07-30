using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float movementSpeed;
    public float rotationSpeed;
    public Rigidbody rb;

    private float inputX;
    private float inputZ;

    private Vector3 rotation;

    void Start()
    {
        rb.constraints = RigidbodyConstraints.FreezePositionY | RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezeRotationZ;
    }

    // Update is called once per frame
    void Update()
    {
        inputX = Input.GetAxisRaw("Horizontal");
        inputZ = Input.GetAxisRaw("Vertical");
    }

    void FixedUpdate()
    {
        MovePlayer();
        RotatePlayer();
    }

    void MovePlayer()
    {
        rb.velocity = transform.forward * Mathf.Clamp01(inputZ) * movementSpeed;
    }

    void RotatePlayer()
    {
        float rotation = inputX * rotationSpeed;
        rb.MoveRotation(transform.rotation * Quaternion.Euler(transform.up * rotation));
    }

    void OnCollisionExit(Collision collisionInfo)
    {
        rb.angularVelocity = Vector3.zero;
    }
}
