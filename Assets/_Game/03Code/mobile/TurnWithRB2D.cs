using UnityEngine;

#nullable enable
namespace ghostly {
	public sealed class TurnWithRB2D : Turn2d {
		
		[SerializeField]
		private Rigidbody2D rb = null!;

		public void FixedUpdate() {
			turnToVector(rb.velocity);
		}

	}
}
