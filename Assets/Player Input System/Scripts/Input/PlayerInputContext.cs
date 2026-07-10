using UnityEngine;

public class PlayerInputContext : MonoBehaviour, IInputContext {
	[SerializeField] private PlayerController controller;
	[SerializeField] PlayerCameraController cameraController;

	public void ProcessInput(InputFrame input) {
		controller.Move(input.Move);

		if (input.Jump) controller.Jump();

		controller.SetSprint(input.Sprint);

		cameraController.SetLook(input.Look);
	}
}