using System.Collections.Generic;
using UnityEngine;

public class InputContextManager : MonoBehaviour {
	[SerializeField] private PlayerInputReader reader;
	[SerializeField] private MonoBehaviour startingContext;

	private Stack<IInputContext> contexts;

	private void Awake() {
		contexts = new Stack<IInputContext>();
		Push((IInputContext)startingContext);
	}

	public void Push(IInputContext context) {
		if (contexts.Count > 0) contexts.Peek().Exit();

		contexts.Push(context);

		context.Enter();
	}

	public void Pop() {
		contexts.Pop().Exit();

		contexts.Peek().Enter();
	}

	private void Update() {
		contexts.Peek().ProcessInput(reader.CurrentInput);
	}
}