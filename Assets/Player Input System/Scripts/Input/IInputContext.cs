/// <summary>
/// Lets anything receive input. Players, Vehicles, Turrets, etc.
/// </summary>
public interface IInputContext {
	void Enter();
	void Exit();
	void ProcessInput(InputFrame input);
}