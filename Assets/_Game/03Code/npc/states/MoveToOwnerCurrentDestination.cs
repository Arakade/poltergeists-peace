
#nullable enable
using ghostly.utils;
using UnityEngine.Assertions;

namespace ghostly.npc.states {
	public sealed class MoveToOwnerCurrentDestination : StateEngine<NPC>.StateBase {
#region public
		
		public MoveToOwnerCurrentDestination(NPCMovement movement) {
			this.movement = movement;
		}

		public override void init() {
			movement.onArrived += onArrived;
		}

		public override void onStateEnter() {
			var destination = owner.currentDestination;
			Assert.IsTrue(destination.HasValue, $"{owner} has no destination!");
			this.log($"{this} going to {destination}");
			movement.goTo(destination!.Value);
		}

#endregion public
#region internal

#endregion internal
#region private

		private void onArrived() {
			Assert.IsTrue(owner.currentDestination.HasValue, $"{owner} has no currentDestination onArrived!?");
			
			// Might get invoked by something else moving us so this checks whether we're really close enough to where we want to go
			if (movement.stoppingDistance >= owner.distanceTo(owner.currentDestination!.Value)) {
				engine.changeState(nameof(ArrivedAtCurrentDestination));
			} else {
				this.log($"Not arrived -- too far away");
			}
		}
		
		private readonly NPCMovement movement;

#endregion private
	}
}
