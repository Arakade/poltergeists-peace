

#nullable enable
using System;
using UnityEngine;
using UnityEngine.InputSystem;
namespace ghostly {
	public class PlayerInputs : MonoBehaviour {
#region serialized
		
		[SerializeField]
		private PlayerMovement playerMovement = null!;
		
#endregion serialized
#region Unity

		public void Update() {
			var x = UnityEngine.Input.GetAxis("Horizontal");
			var y = UnityEngine.Input.GetAxis("Vertical");
			playerMovement.setInput(x, y);
		}

		// public void Awake() {
		// 	input = new Input();
		// 	input.Game.Horizontal.performed += onHorizontal;
		// 	input.Game.Vertical.performed += onVertical;
		// }
		//
		// public void OnEnable() {
		// 	input.Enable();
		// }
		//
		// public void OnDisable() {
		// 	input.Disable();
		// }
		
#endregion Unity
#region private

		// private void onHorizontal(InputAction.CallbackContext ctx) {
		// 	playerMovement.setHorizontal(ctx.ReadValue<float>());
		// }
		//
		// private void onVertical(InputAction.CallbackContext ctx) {
		// 	playerMovement.setVertical(ctx.ReadValue<float>());
		// }
		//
		// private Input input = null!;
		
#endregion private
	}
}
