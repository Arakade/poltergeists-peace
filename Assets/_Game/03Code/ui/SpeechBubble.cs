
#nullable enable
using TMPro;
using UnityEngine;

namespace ghostly.ui {
	/// Speech bubble text.
	public sealed class SpeechBubble : MonoBehaviour {

		[SerializeField]
		private TMP_Text label = null!;
		
		public void setText(string newText) {
			label.SetText(newText);
		}

	}
}
