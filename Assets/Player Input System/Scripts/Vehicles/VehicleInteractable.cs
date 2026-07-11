using UnityEngine;

// Temp script for testing. Can abstract interaction logic into a separate interface if needed in the future
// Should also add Interact bool to the InputFrame data struct
public class VehicleInteractable : MonoBehaviour {
	[SerializeField] private VehicleInputContext vehicleContext;
	[SerializeField] private InputContextManager contextManager;

	private bool playerInside;

	private void OnTriggerEnter(Collider other) {
		if (other.CompareTag("Player")) playerInside = true;
	}

	private void OnTriggerExit(Collider other) {
		if (other.CompareTag("Player")) playerInside = false;
	}

	private void Update() {
		if (!playerInside) return;

		if (Input.GetKeyDown(KeyCode.E)) {
			contextManager.SetContext(vehicleContext);
		}
	}
}