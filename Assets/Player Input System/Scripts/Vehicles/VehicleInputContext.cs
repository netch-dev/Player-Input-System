using UnityEngine;

public class VehicleInputContext : MonoBehaviour, IInputContext {
	[SerializeField] private VehicleController vehicle;

	public void ProcessInput(InputFrame input) {
		vehicle.SetMove(input.Move);
	}
}