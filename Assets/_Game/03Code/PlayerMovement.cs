using System;
using UnityEngine;
#if UNITY_EDITOR
using UnityEditor;
#endif

#nullable enable
namespace ghostly {
	public sealed class PlayerMovement : MonoBehaviour {
#region serialized
		
		[SerializeField]
		private float speed = 10f;

		[SerializeField]
		private Rigidbody2D rb = null!;
		
		[SerializeField]
		private Turn turn = new Turn();
		
		[Serializable]
		private class Turn {
			public float smoothTime = 1f;
			public float maxSpeed = 30f;

			private float yAngle;
			private float rate = 10f;
			
			public void setAngle(float value) => yAngle = value;
			
			public Quaternion turnTo(float angleDeg) {
				yAngle = Mathf.SmoothDampAngle(yAngle, angleDeg, ref rate, smoothTime, maxSpeed, Time.deltaTime);
				return Quaternion.Euler(0f, 0f, yAngle);
			}
		}

#endregion serialized
#region Unity callbacks

		public void OnEnable() {
			xfrm = transform;
			turn.setAngle(xfrm.eulerAngles.y);
		}

		// public void FixedUpdate() {
		// }

		public void Update() {
			move = input * (Time.deltaTime * speed);
			rb.velocity = move;
			if (0f != input.x || 0f != input.y) {
				var angleDeg = Mathf.Atan2(-input.x, input.y) * Mathf.Rad2Deg;
				xfrm.rotation = turn.turnTo(angleDeg);
			}
		}
		
#if UNITY_EDITOR
		public void OnDrawGizmos() {
			Handles.BeginGUI();
			Handles.Label(transform.position, $"{nameof(input)}:{input}\n{nameof(move)}:{move}");
			Handles.EndGUI();
		}
#endif

#endregion Unity callbacks
#region public

#endregion public
#region internal

		internal void setInput(float x, float y) {
			var v = new Vector2(x, y);
			var sqrLen = v.sqrMagnitude;
			input = sqrLen > 1f ? v / Mathf.Sqrt(sqrLen) : v;
		}

		internal void setHorizontal(float value) {
			input.x = value;
		}

		internal void setVertical(float value) {
			input.y = value;
		}

#endregion internal
#region private

		private Vector2 move;

		private Vector2 input;
		
		private Transform xfrm = null!;

#endregion private
	}
}
