using ghostly.utils;
using UnityEngine;
using UnityEngine.Assertions;

#nullable enable
namespace ghostly.npc.sense {
	/// Area that detects specified things and feeds to something that might act.
	public sealed class SenseArea : MonoBehaviour {
#region serialized

#endregion serialized
#region Unity callbacks

		public void Awake() {
			Assert.IsTrue(TryGetComponent(out Collider2D _), $"No Collider2D on {this}");
		}

		public void OnTriggerEnter2D(Collider2D col) {
			if (!col.gameObject.TryGetComponent(out Senseable senseable))
				return;
			
			this.log($"{this} spotted {senseable}");
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
