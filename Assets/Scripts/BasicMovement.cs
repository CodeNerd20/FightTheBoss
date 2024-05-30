using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicMovement : MonoBehaviour
{
    public float moveSpeed;
    public Rigidbody rb;
    //public Vector3 move;

    public float verticalInput;
    public float horizontalInput;

    private GameManager gameManager;

    void Start()
    {
        Time.timeScale = 1;
        rb = GetComponent<Rigidbody>();
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
    }


    void Update()
    {
        verticalInput = Input.GetAxis("Vertical");
        horizontalInput = Input.GetAxis("Horizontal");

        transform.Translate(Vector3.forward * verticalInput * moveSpeed * Time.deltaTime);
        transform.Translate(Vector3.right * horizontalInput * moveSpeed * Time.deltaTime);
        //rb.AddForce(Vector3.forward, moveSpeed * verticalInput * Time.deltaTime, ForceMode.Impulse);
        //rb.AddForce(Vector3.right, moveSpeed * horizontalInput * Time.deltaTime, ForceMode.Impulse);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            gameManager.GameOver();
            Time.timeScale = 0f;
        }
    }
}
