using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicMovement : MonoBehaviour
{
    [SerializeField] float moveSpeed;
    [SerializeField] Rigidbody rb;
    public Vector3 move;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }


    void Update()
    {
        float verticalInput = Input.GetAxis("Vertical");

        rb.AddForce(Vector3.forward * verticalInput * moveSpeed * Time.deltaTime, ForceMode.Impulse);
        
    }
}
