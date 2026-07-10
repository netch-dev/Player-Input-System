using UnityEngine;
using UnityEngine.InputSystem;

/// <summary>
/// Converts Unity input actions into something the player can use. Stores data in an InputFrame.
/// </summary>
public class PlayerInputReader : MonoBehaviour {
	public InputFrame CurrentInput { get; private set; }

	private InputSystem_Actions actions;

	private void Awake() {
		CurrentInput = new InputFrame();
		actions = new InputSystem_Actions();
	}

	private void OnEnable() {
		actions.Enable();

		actions.Player.Move.performed += OnMove;
		actions.Player.Move.canceled += OnMove;

		actions.Player.Look.performed += OnLook;
		actions.Player.Look.canceled += OnLook;

		actions.Player.Jump.performed += OnJump;	
		actions.Player.Sprint.performed += OnSprint;
	}

	private void OnDisable() {
		actions.Player.Move.performed -= OnMove;
		actions.Player.Look.performed -= OnLook;
		actions.Player.Jump.performed -= OnJump;
		actions.Player.Sprint.performed -= OnSprint;

		actions.Disable();
	}

	public void OnMove(InputAction.CallbackContext ctx) {
		CurrentInput.Move = ctx.ReadValue<Vector2>();
	}

	public void OnLook(InputAction.CallbackContext ctx) {
		CurrentInput.Look = ctx.ReadValue<Vector2>();
	}

	public void OnJump(InputAction.CallbackContext ctx) {
		CurrentInput.Jump = ctx.performed;
	}

	public void OnSprint(InputAction.CallbackContext ctx) {
		CurrentInput.Sprint = ctx.ReadValueAsButton();
	}

	private void LateUpdate() {
		// One-shot buttons
		CurrentInput.Jump = false;
	}
}
