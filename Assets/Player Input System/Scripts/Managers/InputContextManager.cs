using UnityEngine;

public class InputContextManager : MonoBehaviour {
	[SerializeField] private PlayerInputReader reader;
	[SerializeField] private MonoBehaviour startingContext;

	private IInputContext activeContext;

	private void Awake() {
		activeContext = (IInputContext)startingContext;
	}

	private void Update() {
		activeContext.ProcessInput(reader.CurrentInput);
	}

	public void SetContext(IInputContext context) {
		activeContext = context;
	}
}