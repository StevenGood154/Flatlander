using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float MovementSpeed;
    public float RotationSpeed;
    public CharacterController controller;

    private Vector3 rotation;

    // Update is called once per frame
    void Update()
    {
        float inputX = Input.GetAxisRaw("Horizontal");
        float inputZ = Input.GetAxisRaw("Vertical");

        controller.Move(transform.forward * inputZ * Time.deltaTime * MovementSpeed);

        rotation = new Vector3(0, inputX * RotationSpeed * Time.deltaTime, 0);
        controller.transform.Rotate(rotation);
        transform.Rotate(rotation);
    }
}
