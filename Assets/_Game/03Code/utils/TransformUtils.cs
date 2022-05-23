
#nullable enable
using UnityEngine;

namespace ghostly.utils {
	public static class TransformUtils {
		
		// public static float sqrDistanceTo(this Transform xfrm, Vector2 pos) => Vector2.SqrMagnitude((Vector2) xfrm.position - pos);
		
		// public static float sqrDistanceTo(this IHasXfrm hasXfrm, Vector2 pos) => Vector2.SqrMagnitude((Vector2) hasXfrm.xfrm.position - pos);
		
		public static float sqrDistanceTo(this IHasPosV2 hasPosV2, Vector2 pos) => Vector2.SqrMagnitude(hasPosV2.posV2 - pos);
		
		// public static float distanceTo(this Transform xfrm, Vector2 pos) => Vector2.Distance(xfrm.position, pos);
		
		// public static float distanceTo(this IHasXfrm hasXfrm, Vector2 pos) => Vector2.Distance(hasXfrm.xfrm.position, pos);
		
		public static float distanceTo(this IHasPosV2 hasPosV2, Vector2 pos) => Vector2.Distance(hasPosV2.posV2, pos);

	}
}
