using UnityEngine;

public class PlayerController : MonoBehaviour {
	[SerializeField] private CharacterMotor motor;

	public void Move(Vector2 move) {
		motor.SetMove(move);
	}

	public void Jump() {
		motor.Jump();
	}

	public void SetSprint(bool sprint) {
		motor.SetSprint(sprint);
	}
}