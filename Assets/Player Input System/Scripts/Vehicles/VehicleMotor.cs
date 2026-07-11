using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class VehicleMotor : MonoBehaviour {
	[SerializeField] private float acceleration = 15f;
	[SerializeField] private float turnSpeed = 80f;

	private Rigidbody rb;

	private Vector2 moveInput;

	private void Awake() {
		rb = GetComponent<Rigidbody>();
	}

	public void SetMove(Vector2 input) {
		moveInput = input;
	}

	private void FixedUpdate() {
		rb.AddForce(transform.forward * moveInput.y * acceleration);

		rb.MoveRotation(rb.rotation * Quaternion.Euler(0f, moveInput.x * turnSpeed * Time.fixedDeltaTime, 0f));
	}
}