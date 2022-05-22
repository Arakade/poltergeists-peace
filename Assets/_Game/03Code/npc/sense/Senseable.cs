
#nullable enable
using UnityEngine;
using UnityEngine.Assertions;

namespace ghostly.npc.sense {
	/// Something that can be sensed.
	public sealed class Senseable : MonoBehaviour {
#region serialized

		

#endregion serialized
#region Unity callbacks

		public void Awake() {
			Assert.IsTrue(TryGetComponent(out Collider2D _), $"No Collider2D on {this}");
		}

#endregion Unity callbacks
#region public

#endregion public
#region internal

#endregion internal
#region private

#endregion private
	}
}
