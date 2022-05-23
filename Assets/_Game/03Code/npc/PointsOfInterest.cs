
#nullable enable
using System;
using ghostly.utils;
using UnityEngine;
using UnityEngine.Assertions;

namespace ghostly.npc {
	public sealed class PointsOfInterest : MonoBehaviour {
#region serialized

		public WayPoint[] pointsOfInterest = Array.Empty<WayPoint>();

#endregion serialized
#region Unity callbacks
		
		public void Awake() {
			Assert.IsTrue(0 < pointsOfInterest.Length, $"{this} has no points of interest!");
			for (var i = 0; i < pointsOfInterest.Length; i++) {
				if (null == pointsOfInterest[i])
					this.error($"{this}.{nameof(pointsOfInterest)}[{i}] is null!");
			}
			
			randomGrabBag = new RandomGrabBag<WayPoint>(pointsOfInterest, autoReset:true);
		}
			

#endregion Unity callbacks
#region public

		public (Vector2, string) getRandomDestination() {
			var destWP = randomGrabBag.chooseOne();
			var pos = destWP.transform.position;
			return (pos, destWP.name);
		}
		
#endregion public
#region internal

#endregion internal
#region private
		
		private RandomGrabBag<WayPoint> randomGrabBag = null!;

#endregion private
	}
}
