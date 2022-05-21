using UnityEngine;

#nullable enable
namespace ghostly.ui {
	/// Parent to dynamically added UI.
	public sealed class OverlayParent : MonoBehaviour {

		public static OverlayParent singleton { get; private set; } = null!;

		public void Awake() {
			singleton = this;
		}
		
	}
}
