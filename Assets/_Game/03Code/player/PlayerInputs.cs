using UnityEngine;

#nullable enable
namespace ghostly {
	public class PlayerInputs : MonoBehaviour {
		
		[SerializeField]
		private PlayerMovement playerMovement = null!;
		
		public void Update() {
			var x = Input.GetAxis("Horizontal");
			var y = Input.GetAxis("Vertical");
			playerMovement.setInput(x, y);
		}
		
	}
}
