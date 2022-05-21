
#nullable enable
using UnityEngine;

namespace ghostly.ui {
	/// <summary>
	/// More environmentally friendly to run the game at sensible FPS.
	/// </summary>
	public sealed class FPSLimit : MonoBehaviour {

		[SerializeField]
		private int fps = 60;

		public void Awake() {
			Application.targetFrameRate = fps;
		}

	}
}
