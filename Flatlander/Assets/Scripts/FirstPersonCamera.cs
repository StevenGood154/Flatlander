using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirstPersonCamera : MonoBehaviour
{
    public float horizontalStretch = 1;
    public float verticalStretch = 1;
    public Vector2 shearing = Vector2.zero;

    private Matrix4x4 matStretch = Matrix4x4.identity;

    private Camera cam;
    private Matrix4x4 originalProjectionMatrix;

    // Start is called before the first frame update
    void Start()
    {
        cam = GetComponent<Camera>();
        originalProjectionMatrix = cam.projectionMatrix;
    }

    // Update is called once per frame
    void Update()
    {
        matStretch[0, 0] = horizontalStretch;
        matStretch[1, 1] = verticalStretch;

        cam.projectionMatrix = originalProjectionMatrix * matStretch;
    }
}
