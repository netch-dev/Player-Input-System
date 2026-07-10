/// <summary>
/// Lets anything receive input. Players, Vehicles, Turrets, etc.
/// </summary>
public interface IInputContext {
	void ProcessInput(InputFrame input);
}