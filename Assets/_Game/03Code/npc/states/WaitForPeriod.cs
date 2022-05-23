
#nullable enable
using ghostly.utils;
using UnityEngine;

namespace ghostly.npc.states {
	public sealed class WaitForPeriod : StateEngine<NPC>.StateBase {
		
		public const string PeriodToWait = "periodToWait";

		public override void onStateEnter() {
			if (!owner.blackboard.tryGetStructType(PeriodToWait, out float period)) {
				this.error($"{this} has no period to wait");
				return;
			}
			endTime = Time.timeSinceLevelLoad + period;
		}

		public override void onTick() {
			// busy wait = simpler for now
			if (Time.timeSinceLevelLoad < endTime)
				return;
			
			engine.changeState(nameof(Idle));
		}
		
		private float endTime;

	}
}
