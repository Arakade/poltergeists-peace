using ghostly.ui;
using UnityEngine;

#nullable enable
namespace ghostly.npc {
	public sealed class HasSpeechBubble : MonoBehaviour {
#region serialized

		[SerializeField]
		private SpeechBubble speechBubblePrefab = null!;

#endregion serialized
#region Unity callbacks

		public void Awake() {
			setupSpeechBubble();
		}

		private void setupSpeechBubble() {
			speechBubble = Instantiate(speechBubblePrefab, OverlayParent.singleton.transform);
			var uiFollowWorld2D = speechBubble.GetComponent<UIFollowWorld2D>();
			uiFollowWorld2D.setTarget(transform);
		}

#endregion Unity callbacks
#region public

		public SpeechBubble speechBubble {get; private set;} = null!;
		
#endregion public
#region internal

#endregion internal
#region private

#endregion private
	}
}
