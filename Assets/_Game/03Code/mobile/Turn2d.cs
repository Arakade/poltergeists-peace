using UnityEngine;

#nullable enable
namespace ghostly {
	public class Turn2d : MonoBehaviour {
#region serialized
		
		public float smoothTime = 0.1f;
		public float maxSpeed = 1000f;

#endregion serialized
#region Unity callbacks

		public void OnEnable() {
			xfrm = transform;
			setAngle(xfrm.eulerAngles.y);
		}

#endregion Unity callbacks
#region public

		public void setAngle(float value) => yAngle = value;
		
		public void turnToVector(Vector2 v) {
			if (0f != v.x || 0f != v.y) {
				// Converts from Unity angle +x = 0 to our +y = 0
				var angleDeg = Mathf.Atan2(-v.x, v.y) * Mathf.Rad2Deg;
				turnToAngle(angleDeg);
			}
		}
		
		public void turnToAngle(float angleDeg) {
			yAngle = Mathf.SmoothDampAngle(yAngle, angleDeg, ref rate, smoothTime, maxSpeed, Time.deltaTime);
			xfrm.rotation = Quaternion.Euler(0f, 0f, yAngle);
		}

#endregion public
#region internal

#endregion internal
#region private
		
		private float yAngle;
		
		private float rate = 10f;
		
		private Transform xfrm = null!;

#endregion private
	}
}
