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
		private Turn2d turn2d = null!;

#endregion serialized
#region Unity callbacks

		public void OnEnable() {
			xfrm = transform;
			turn2d.setAngle(xfrm.eulerAngles.y);
		}

		public void FixedUpdate() {
			move = input * speed;
			rb.velocity = move;
			turn2d.turnToVector(input);
		}
		
#if UNITY_EDITOR
		public void OnDrawGizmosSelected() {
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

#endregion internal
#region private

		private Vector2 move;

		private Vector2 input;
		
		private Transform xfrm = null!;

#endregion private
	}
}
