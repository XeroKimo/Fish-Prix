using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControllerTest : MonoBehaviour
{
    public Rigidbody rb;

    private short keyToPress;
    private bool accelerate = false;
    public float rotationSpeed;
    private float rotation;

    // Start is called before the first frame update
    void Start()
    {
        keyToPress = -1;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Z) && (keyToPress == -1 || keyToPress == 0) && !accelerate)
        {
            Debug.Log("Z");
            accelerate = true;
            keyToPress = 1;
        }
        if (Input.GetKeyDown(KeyCode.X) && (keyToPress == -1 || keyToPress == 1) && !accelerate)
        {
            Debug.Log("X");
            accelerate = true;
            keyToPress = 0;
        }
        rotation = 0;
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            rotation += -rotationSpeed;
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            rotation += rotationSpeed;
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (accelerate)
        {
            if (rb.velocity.magnitude < 3.0f)
                rb.AddForce(transform.forward * 1, ForceMode.Impulse);
            else
                rb.AddForce(transform.forward * 10, ForceMode.Impulse);
            accelerate = false;
        }


        if (rb.velocity.magnitude > 0)
        {
            float rotationValue = rotation;
            if(rb.velocity.magnitude < 10.0f)
                rotationValue *= 3;
            transform.rotation *= Quaternion.Euler(0, rotationValue * Time.fixedDeltaTime, 0);
            //rb.velocity = Quaternion.Euler(0, rotationValue * Time.fixedDeltaTime, 0) * rb.velocity;
        }
    }
}
