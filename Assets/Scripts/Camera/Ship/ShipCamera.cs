using UnityEngine;
using System.Collections;

public class ShipCamera : MonoBehaviour
{

    public Transform cameraPlatform;
    public Transform ship;

    float distance = 15f;
    float xSpeed = 1f;
    float ySpeed = 1f;

    float yMinLimit = -90f;
    float yMaxLimit = 90f;

    private float x = 0f;
    private float y = 0f;

    float smoothTime = 0.01f;

    private float xSmooth = 0f;
    private float ySmooth = 0f;
    private float shipXSmooth = 0f;
    private float shipYSmooth = 0f;
    private float xVelocity = 0f;
    private float yVelocity = 0f;
    private float shipXVelocity = 0f;
    private float shipYVelocity = 0f;

    void Start()
    {
        if (GetComponent<Rigidbody>())
        {
            GetComponent<Rigidbody>().freezeRotation = true;
        }
    }

    //void LateUpdate()
    void FixedUpdate ()
    {
        if (cameraPlatform)
        {
            //if (Input.GetMouseButton(0))
            //{

                x += Input.GetAxis("Mouse X") * xSpeed;
                y -= Input.GetAxis("Mouse Y") * ySpeed;
                x = Mathf.Clamp(x, yMinLimit, yMaxLimit);
                y = Mathf.Clamp(y, yMinLimit, yMaxLimit);
            //}

            xSmooth = Mathf.SmoothDamp(xSmooth, x, ref xVelocity, smoothTime);
            ySmooth = Mathf.SmoothDamp(ySmooth, y, ref yVelocity, smoothTime);

            shipXSmooth = Mathf.SmoothDamp(shipXSmooth, ship.eulerAngles.x, ref shipXVelocity, 0.3f);
            shipYSmooth = Mathf.SmoothDamp(shipYSmooth, ship.eulerAngles.y, ref shipYVelocity, 0.3f);

            transform.localRotation = Quaternion.Euler(ySmooth, xSmooth, 0);
            transform.position = transform.rotation * new Vector3(0f, 0f, -distance) + cameraPlatform.position;

        }
    }
}


