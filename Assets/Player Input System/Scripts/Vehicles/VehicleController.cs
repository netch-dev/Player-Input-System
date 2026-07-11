using UnityEngine;

public class VehicleController : MonoBehaviour {
	[SerializeField] private VehicleMotor motor;

	public void SetMove(Vector2 move) {
		motor.SetMove(move);
	}
}