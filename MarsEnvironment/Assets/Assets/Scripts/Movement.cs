using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    float speed;
    float walk = 2;
    float sprint = 5;
    float crouch = 1.5f;

    float horizontalInput;
    float forwardInput;


    [SerializeField] Rigidbody rb;
    [SerializeField] Transform cam;

    // Start is called before the first frame update
    void Start() { }

    // Update is called once per frame
    void Update()
    {
        horizontalInput = Input.GetAxis("Horizontal");
        forwardInput = Input.GetAxis("Vertical");

        if (Input.GetKey(KeyCode.LeftControl)) { speed = crouch; }
        else if (Input.GetKey(KeyCode.LeftShift)) { speed = sprint; }
        else { speed = walk; }
    }

    private void FixedUpdate()
    {
        Vector3 forwardMovement = cam.transform.forward * forwardInput * speed * Time.fixedDeltaTime;
        Vector3 horizontalMovement = cam.transform.right * horizontalInput * speed * Time.fixedDeltaTime;

        rb.MovePosition(rb.position + forwardMovement + horizontalMovement);
    }
}
