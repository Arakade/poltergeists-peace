
#nullable enable
using UnityEngine.Assertions;

namespace ghostly.npc.states {
	/// Go check on a thing.
	public sealed class CheckOnThing : StateEngine<NPC>.StateBase {
#region public
		
		public CheckOnThing(NPCMovement movement) {
			this.movement = movement;
		}

		public override void init() {
		}

		public override void onStateEnter() {
			var destination = owner.currentDestination;
			Assert.IsTrue(destination.HasValue, $"{owner} has no destination!");
			movement.onArrived += onArrived;
			movement.goTo(destination!.Value);
		}

#endregion public
#region internal

#endregion internal
#region private

		private void onArrived() {
			// TODO: How to decide on next state?
			movement.onArrived += onArrived;
		}
		
		private readonly NPCMovement movement;

#endregion private
	}
}
