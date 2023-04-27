using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerMove : MonoBehaviour
{
    public float moveSpeed = 10f;
    public float rotateSpeed = 100f;
    public float jumpForce = 10f;
    public float throwForce = 10f;
    public GameObject spherePrefab;

    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        transform.Translate(Vector3.forward * moveSpeed * verticalInput * Time.deltaTime);
        transform.Rotate(Vector3.up * rotateSpeed * horizontalInput * Time.deltaTime);

        if (Input.GetKeyDown(KeyCode.Space))
        {
            Jump();
        }

        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            ThrowSphere();
        }
    }

    void Jump()
    {
        rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
    }

    void ThrowSphere()
    {
        GameObject newSphere = Instantiate(spherePrefab, transform.position + transform.forward * 5f, Quaternion.identity);
        Rigidbody sphereRb = newSphere.GetComponent<Rigidbody>();
        sphereRb.AddForce(transform.forward * throwForce + transform.up * throwForce, ForceMode.VelocityChange);
    }


}
