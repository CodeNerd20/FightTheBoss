using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirstPersonLookControls : MonoBehaviour
{
    [SerializeField] Transform player;
    [SerializeField] float mouseSens = 2.0f;
    float cameraVerticalRotation = 0.0f;

    // Start is called before the first frame update
    void Start()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        //Get mouse positions
        float mouseX = Input.GetAxis("Mouse X");
        float mouseY = Input.GetAxis("Mouse Y");

        float userInputX = mouseX * mouseSens;
        float userInputY = mouseY * mouseSens;

        //Rotate Camera
        //
        //Vertical
        cameraVerticalRotation -= userInputY;
        cameraVerticalRotation = Mathf.Clamp(cameraVerticalRotation, -90.0f, 90.0f);
        transform.localEulerAngles = Vector3.right * cameraVerticalRotation;
        //Horizontal
        player.Rotate(Vector3.up * userInputX);
    }
}
