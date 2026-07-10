using UnityEngine;

public class PlayerCameraController : MonoBehaviour {
	[Header("References")]
	[SerializeField] private Transform playerRoot;
	[SerializeField] private Transform cameraPivot;

	[Header("Settings")]
	[SerializeField] private float sensitivity = 0.25f;
	[SerializeField] private float minPitch = -85f;
	[SerializeField] private float maxPitch = 85f;

	private Vector2 lookInput;

	private float pitch;

	public void SetLook(Vector2 input) {
		lookInput = input;
	}

	// Running in LateUpdate ensures the camera reacts to the players final transform for that frame
	private void LateUpdate() {
		RotateCamera();
	}

	private void RotateCamera() {
		float yaw = lookInput.x * sensitivity;
		float pitchDelta = lookInput.y * sensitivity;

		playerRoot.Rotate(Vector3.up * yaw);

		pitch -= pitchDelta;
		pitch = Mathf.Clamp(pitch, minPitch, maxPitch);

		cameraPivot.localRotation = Quaternion.Euler(pitch, 0f, 0f);
	}
}