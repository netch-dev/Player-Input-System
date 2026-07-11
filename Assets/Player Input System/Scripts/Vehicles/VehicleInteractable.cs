using UnityEngine;

// Temp script for testing. Can abstract interaction logic into a separate interface if needed in the future
// Should also add Interact bool to the InputFrame data struct
public class VehicleInteractable : MonoBehaviour {
	[SerializeField] private VehicleInputContext vehicleContext;
	[SerializeField] private InputContextManager contextManager;

	private bool playerInTrigger;
	private bool playerInVehicle;

	private void OnTriggerEnter(Collider other) {
		if (other.CompareTag("Player")) playerInTrigger = true;
	}

	private void OnTriggerExit(Collider other) {
		if (other.CompareTag("Player")) playerInTrigger = false;
	}

	private void Update() {
		// This should use the Interact input from the InputFrame instead of checking for key presses directly
		// InputFrame.Interact -> InteractManager -> IInteractable (Vehicle) 
		if (playerInVehicle) {
			if (Input.GetKeyDown(KeyCode.E)) {
				contextManager.Pop();
				playerInVehicle = false;
			}

			return;
		}

		if (playerInTrigger) {
			if (Input.GetKeyDown(KeyCode.E)) {
				contextManager.Push(vehicleContext);
				playerInVehicle = true;
			}
		}
	}
}