using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpongebobControls : MonoBehaviour
{
    public float speed;
    private Rigidbody spongyRb;
    private GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        spongyRb = GetComponent<Rigidbody>();
        player = GameObject.Find("Player");
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 lookDirection = (player.transform.position - transform.position).normalized;

        spongyRb.AddForce(lookDirection * speed);
    }
}
