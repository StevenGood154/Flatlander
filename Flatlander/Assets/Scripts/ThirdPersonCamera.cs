using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThirdPersonCamera : MonoBehaviour
{
    public Camera cam;

    void Update()
    {
        HandleUserInput();
        MoveCamera();
    }

    void MoveCamera()
    {
        transform.rotation = Quaternion.Euler(90 * Vector3.right);
    }

    void HandleUserInput()
    {
        if (Input.GetKeyDown("p"))
        {
            SetPerspective();
        }
        else if (Input.GetKeyUp("p"))
        {
            SetOrthographic();
        }
    }

    void SetOrthographic() {
        cam.orthographic = true;
    }

    void SetPerspective() {
        cam.orthographic = false;
    }
}
