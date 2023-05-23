using System.Collections;
using UnityEngine;

public class PlayerJump : MonoBehaviour
{
    public float speed;
    public float rotationSpeed;
    public float jumpForce;
    public float jumpCooldownDuration;

    private CharacterController characterController;
    private float originalStepOffset;
    private bool canJump = true;

    void Start()
    {
        characterController = GetComponent<CharacterController>();
        originalStepOffset = characterController.stepOffset;
    }

    void Update()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        Vector3 movementDirection = new Vector3(horizontalInput, 0, verticalInput).normalized;

        if (movementDirection != Vector3.zero)
        {
            Quaternion toRotation = Quaternion.LookRotation(movementDirection, Vector3.up);
            transform.rotation = Quaternion.RotateTowards(transform.rotation, toRotation, rotationSpeed * Time.deltaTime);
        }

        if (characterController.isGrounded)
        {
            characterController.stepOffset = originalStepOffset;

            if (canJump && Input.GetButtonDown("Jump"))
            {
                StartCoroutine(JumpCoroutine());
            }
        }
        else
        {
            characterController.stepOffset = 0;
        }

        Vector3 movement = movementDirection * speed;
        movement.y = Physics.gravity.y;
        characterController.Move(movement * Time.deltaTime);
    }

    IEnumerator JumpCoroutine()
    {
        canJump = false;
        characterController.Move(Vector3.up * jumpForce * Time.deltaTime);

        yield return new WaitForSeconds(jumpCooldownDuration);

        canJump = true;
    }
}
