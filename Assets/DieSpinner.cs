using UnityEngine;

/*
* Applies a random rolling force to the die.
*/

public class DieSpinner : MonoBehaviour
{
    public float minSpinDuration = 500f; // Minimum spin duration in milliseconds
    public float maxSpinDuration = 2000f; // Maximum spin duration in milliseconds
    public float spinForce = 100f; // Spin force applied to the die (increase this value for faster spin)

    private Rigidbody rb;
    private float spinTime;
    private float spinTimer;
    private bool isSpinning;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    public void StartSpin()
    {
        rb.useGravity = true;
        
        // Generate a random spin duration between min and max
        spinTime = Random.Range(minSpinDuration, maxSpinDuration) / 1000f; // Convert to seconds
        spinTimer = 0f;
        isSpinning = true;

        // Apply random torque to spin the die
        Vector3 randomTorque = new Vector3(
            Random.Range(-spinForce, spinForce),
            Random.Range(-spinForce, spinForce),
            Random.Range(-spinForce, spinForce)
        );
        Vector3 fixedTorque = new Vector3(spinForce, spinForce, spinForce);
        rb.AddTorque(randomTorque, ForceMode.Impulse);
    }

    void FixedUpdate()
    {
        if (isSpinning)
        {
            spinTimer += Time.deltaTime;

            if (spinTimer >= spinTime)
            {
                // Stop spinning after the duration
                rb.angularVelocity = Vector3.zero;
                isSpinning = false;
            }
        }
    }
}

