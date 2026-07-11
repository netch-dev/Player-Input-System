using UnityEngine;

public class PlayerInputContext : MonoBehaviour, IInputContext {
	[SerializeField] private PlayerController controller;
	[SerializeField] PlayerCameraController cameraController;

	public void ProcessInput(InputFrame input) {
		controller.SetMove(input.Move);

		if (input.Jump) controller.SetJump();

		controller.SetSprint(input.Sprint);

		cameraController.SetLook(input.Look);
	}
}