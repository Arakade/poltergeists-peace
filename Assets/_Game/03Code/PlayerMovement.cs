
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

#endregion serialized
#region Unity callbacks

		public void FixedUpdate() {
			move = input * (Time.deltaTime * speed);
		}

		public void Update() {
			rb.velocity = move;
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
			input = new Vector2(x, y);
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

#endregion private
	}
}
