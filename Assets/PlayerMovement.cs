using UnityEngine;
using UnityEngine.UIElements;


public class PlayerMovement : MonoBehaviour
{

    public float speed = 3f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        MovePlayerRelativeCamera();
    }

    void MovePlayerRelativeCamera()
    {
        // Get Player Input
        float playerVerticalInput = Input.GetAxis("Vertical");
        float playerHorizontalInput = Input.GetAxis("Horizontal");

        // Normalizing the diagonal direction
        Vector3 inputDirection = new Vector3(playerHorizontalInput, 0, playerVerticalInput);

        if (inputDirection.magnitude > 1)
        {
            inputDirection.Normalize();
        }


        // Get Cameraaa Normalized Directional Vectors
        Vector3 forward = Camera.main.transform.forward;
        Vector3 right = Camera.main.transform.right;
        forward.y = 0;
        right.y = 0;
        forward = forward.normalized;
        right = right.normalized;

        // Create direction-relative-input vector
        Vector3 movement = (forward * inputDirection.z + right * inputDirection.x) * speed * Time.deltaTime;


        // Apply camera relative movement
        gameObject.transform.Translate(movement, Space.World);



    }

}
