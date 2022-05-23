
#nullable enable
using ghostly.npc.states;
using ghostly.utils;
using UnityEngine;

namespace ghostly.npc.goals {
	public sealed class VisitLocationForABit : GoalBase {
#region public
		
		public VisitLocationForABit(Vector2 location, string destinationName, float duration = -1f) {
			this.location = location;
			this.destinationName = destinationName;
			this.duration = 0 < duration ? duration : Random.Range(1f, 5f);
		}

		public override void begin() {
			// Travel to location
			this.log($"Going to {destinationName}");
			owner.currentDestination = location;
			owner.stateEngine.
			owner.stateEngine.changeState(nameof(MoveToOwnerCurrentDestination));
			
			// TODO: Wait for a bit
		}

#endregion public
#region internal

#endregion internal
#region private
		
		private readonly float duration;
		
		private readonly string destinationName;
		
		private readonly Vector2 location;

#endregion private
	}
}
