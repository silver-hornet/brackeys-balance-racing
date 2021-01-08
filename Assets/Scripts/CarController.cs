using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class CarController : MonoBehaviour
{
    [SerializeField] Rigidbody2D rb;
    [SerializeField] WheelJoint2D backWheel;
    [SerializeField] WheelJoint2D frontWheel;
    [SerializeField] float speed = 1500;
    [SerializeField] float rotationSpeed = 800f;
    float movement = 0f;
    float rotation = 0f;

    void Update()
    {
        movement = -Input.GetAxisRaw("Vertical") * speed; // A positive speed moves the car backward, so we have to compensate by putting a negative in front of Input
        rotation = Input.GetAxisRaw("Horizontal");
    }

    void FixedUpdate()
    {
        if (movement == 0f)
        {
            backWheel.useMotor = false;
            frontWheel.useMotor = false;
        }
        else
        {
            backWheel.useMotor = true;
            frontWheel.useMotor = true;
            JointMotor2D motor = new JointMotor2D { motorSpeed = movement, maxMotorTorque = backWheel.motor.maxMotorTorque }; // Created this variable because you can't directly modify a struct
            backWheel.motor = motor;
            frontWheel.motor = motor;
        }

        rb.AddTorque(-rotation * rotationSpeed * Time.deltaTime);
    }
}