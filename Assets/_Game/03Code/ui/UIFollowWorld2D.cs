

#nullable enable
using System;
using ghostly.utils;
using UnityEngine;
namespace ghostly.ui {
	/// Keep Overlay UI atop 2D world object.
	// [ExecuteInEditMode]
	public sealed class UIFollowWorld2D : MonoBehaviour {
#region serialized
		
#endregion serialized
#region Unity callbacks
		
		public void Awake() {
			enabled = false;
			rectTransform = (RectTransform) transform;
			if (null == (cam = Camera.main!))
				throw new Exception("No camera?!");
		}

		public void Start() {
			rectTransform = (RectTransform) transform;
			if (null == target) {
				this.warn($"{this} has no target = disabling");
				enabled = false;
			}
		}

		public void Update() {
			var uiPos = cam.WorldToViewportPoint(target.position);
			rectTransform.anchorMax = rectTransform.anchorMin = uiPos;
		}

#endregion Unity callbacks
#region public
		
		public void setTarget(Transform newTarget) {
			target = newTarget;
			enabled = true;
		}

#endregion public
#region internal

#endregion internal
#region private
		
		private Transform target = null!;
		
		private Camera cam = null!;
		
		private RectTransform rectTransform = null!;

#endregion private
	}
}
