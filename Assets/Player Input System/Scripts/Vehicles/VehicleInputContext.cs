using UnityEngine;

public class VehicleInputContext : MonoBehaviour, IInputContext {
	[SerializeField] private VehicleController vehicle;

	public void Enter() {
	}

	public void Exit() {
		vehicle.SetMove(Vector2.zero);
	}

	public void ProcessInput(InputFrame input) {
		vehicle.SetMove(input.Move);
	}
}