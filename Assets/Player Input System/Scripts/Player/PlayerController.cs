using UnityEngine;

public class PlayerController : MonoBehaviour {
	[SerializeField] private CharacterMotor motor;

	public void SetMove(Vector2 move) {
		motor.SetMove(move);
	}

	public void SetJump() {
		motor.SetJump();
	}

	public void SetSprint(bool sprint) {
		motor.SetSprint(sprint);
	}
}