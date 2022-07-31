using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float movementSpeed;
    public float rotationSpeed;
    public Rigidbody rb;

    [SerializeField] private Camera thirdPersonCamera;
    [SerializeField] private Camera firstPersonCamera;

    private float inputX;
    private float inputZ;
    private bool isSplitScreen = false;
    private bool isFirstPerson = false;

    private Vector3 rotation;

    void Start()
    {
        rb.constraints = RigidbodyConstraints.FreezePositionY | RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezeRotationZ;
        SetThirdPersonView();
    }

    // Update is called once per frame
    void Update()
    {
        inputX = Input.GetAxisRaw("Horizontal");
        inputZ = Input.GetAxisRaw("Vertical");
        if (Input.GetKeyDown("f") && !isSplitScreen)
        {
            TogglePointOfView();
        }
        else if (Input.GetKeyDown("e"))
        {
            ToggleSplitScreen();
        }
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

    void ToggleSplitScreen()
    {
        if (isSplitScreen)
        {
            isSplitScreen = false;
            SetThirdPersonView();
            thirdPersonCamera.rect = new Rect(0f, 0f, 1f, 1f);
            firstPersonCamera.rect = new Rect(0f, 0f, 1f, 1f);
        }
        else
        {
            isSplitScreen = true;
            thirdPersonCamera.enabled = true;
            firstPersonCamera.enabled = true;
            thirdPersonCamera.rect = new Rect(0f, 0f, .5f, 1f);
            firstPersonCamera.rect = new Rect(0.5f, 0f, .5f, 1f);
        }
    }

    void TogglePointOfView()
    {
        if (isFirstPerson)
        {
            isFirstPerson = false;
            SetThirdPersonView();
        }
        else
        {
            isFirstPerson = true;
            SetFirstPersonView();
        }
    }

    void SetFirstPersonView()
    {
        thirdPersonCamera.enabled = false;
        firstPersonCamera.enabled = true;
    }

    void SetThirdPersonView()
    {
        thirdPersonCamera.enabled = true;
        firstPersonCamera.enabled = false;
    }

    void OnCollisionExit(Collision collisionInfo)
    {
        rb.angularVelocity = Vector3.zero;
    }
}
