
#nullable enable
using System;
using ghostly.utils;
using UnityEngine;
using Random = UnityEngine.Random;

namespace ghostly.npc {
	public sealed class PointsOfInterest : MonoBehaviour {
#region serialized

		public WayPoint[] pointsOfInterest = Array.Empty<WayPoint>();

#endregion serialized
#region Unity callbacks
		
		public void Awake() {
			if (0 >= pointsOfInterest.Length) {
				this.warn($"{this} has no points of interest so using all!");
			}

			for (var i = 0; i < pointsOfInterest.Length; i++) {
				if (null == pointsOfInterest[i])
					this.error($"{this}.{nameof(pointsOfInterest)}[{i}] is null!");
			}
		}
			

#endregion Unity callbacks
#region public

		public (Vector2, string) getRandomDestination() {
			var destWP = pointsOfInterest[Random.Range(0, pointsOfInterest.Length)];
			var pos = destWP.transform.position;
			this.log($"{this} going to {destWP} = {pos}");
			return (pos, destWP.name);
		}
		
#endregion public
#region internal

#endregion internal
#region private

#endregion private
	}
}
