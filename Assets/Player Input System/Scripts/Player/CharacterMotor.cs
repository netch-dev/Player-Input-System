using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class CharacterMotor : MonoBehaviour {
	[Header("Movement")]
	[SerializeField] private float walkSpeed = 5f;
	[SerializeField] private float sprintSpeed = 8f;

	[Header("Jumping")]
	[SerializeField] private float jumpHeight = 1.5f;
	[SerializeField] private float gravity = -9.81f;

	private CharacterController controller;

	private Vector2 moveInput;
	private bool sprinting;
	private bool jumpRequested;

	private float verticalVelocity;
	private bool grounded;

	private void Awake() {
		controller = GetComponent<CharacterController>();
	}

	public void SetMove(Vector2 input) {
		moveInput = input;
	}

	public void SetSprint(bool sprint) {
		sprinting = sprint;
	}

	public void SetJump() {
		jumpRequested = true;
	}

	private void Update() {
		grounded = controller.isGrounded;

		HandleJump();

		ApplyGravity();

		MoveCharacter();

		jumpRequested = false;
	}

	private void HandleJump() {
		if (!jumpRequested) return;

		if (!grounded) return;

		verticalVelocity = Mathf.Sqrt(jumpHeight * -2f * gravity);
	}

	private void ApplyGravity() {
		if (grounded && verticalVelocity < 0f) {
			verticalVelocity = -2f;
		}

		verticalVelocity += gravity * Time.deltaTime;
	}

	private void MoveCharacter() {
		float speed = sprinting ? sprintSpeed : walkSpeed;

		Vector3 horizontal = transform.forward * moveInput.y + transform.right * moveInput.x;

		horizontal *= speed;

		Vector3 movement = horizontal;
		movement.y = verticalVelocity;

		controller.Move(movement * Time.deltaTime);
	}
}