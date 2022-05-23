
#nullable enable
using ghostly.npc.states;
using ghostly.utils;
using UnityEngine;

namespace ghostly.npc.goals {
	public sealed class VisitLocationForABit : GoalBase {
#region public

		public override string name => $"visit {destinationName} for {duration:0} minutes";

		public VisitLocationForABit(Vector2 location, string destinationName, float duration = -1f) {
			this.location = location;
			this.destinationName = destinationName;
			this.duration = 0 < duration ? duration : Random.Range(1f, 5f);
		}

		public override void begin() {
			// Travel to location
			this.log($"Going to {destinationName}");
			owner.currentDestination = location;
			owner.stateEngine.onStateChange += onStateChangedWhileWaitingToArrive;
			owner.stateEngine.changeState(nameof(MoveToOwnerCurrentDestination));
			
			
			// TODO: Wait for a bit
		}

#endregion public
#region internal

#endregion internal
#region private

		private void onStateChangedWhileWaitingToArrive(StateEngine<NPC> stateEngine, StateEngine<NPC>.IState oldState, StateEngine<NPC>.IState newState) {
			if (!(oldState is MoveToOwnerCurrentDestination) || !(newState is Idle) || owner.currentDestination != location) {
				// this.log($"{this} notified of irrelevant state change");
				return;
			}
			
			// done listening
			stateEngine.onStateChange -= onStateChangedWhileWaitingToArrive;
			stateEngine.onStateChange += onStateChangedWhileWaitingForTimeToElapse;
			owner.blackboard.put(WaitForPeriod.PeriodToWait, duration);
			stateEngine.changeState(nameof(WaitForPeriod));
		}
		
		private void onStateChangedWhileWaitingForTimeToElapse(StateEngine<NPC> stateEngine, StateEngine<NPC>.IState oldState, StateEngine<NPC>.IState newState) {
			if (!(oldState is WaitForPeriod) || !(newState is Idle) || owner.currentDestination != location) {
				// this.log($"{this} notified of irrelevant state change");
				return;
			}
			
			// done listening
			stateEngine.onStateChange -= onStateChangedWhileWaitingForTimeToElapse;
			owner.blackboard.delete(WaitForPeriod.PeriodToWait);
			stateEngine.changeState(nameof(Idle));
			
			goalComplete();
		}
		
		private readonly float duration;
		
		private readonly string destinationName;
		
		private readonly Vector2 location;

#endregion private
	}
}
