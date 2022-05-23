
#nullable enable
using System.Collections.Generic;
using System.Linq;
using ghostly.utils;

namespace ghostly.npc.goals {
	/// Stack of things to do (<see cref="IGoal{T}"/>s).
	/// <see cref="currentGoal"/> is pushed down by a new one.
	public sealed class Goals {
#region public
		
		/// Whether it has more goals beyond the <see cref="currentGoal"/>.
		public bool hasMoreGoals => goalStack.Count > 0;
		
		public Goals(NPC owner) {
			this.owner = owner;
		}
		
		public void pushNewCurrentGoal(IGoal<NPC> goal) {
			if (null != currentGoal) {
				owner.journal.record($"{currentGoal} will have to wait.");
				goalStack.Push(currentGoal);
			}
			
			goal.setOwner(owner);
			currentGoal = goal;
			this.log($"{owner} {this}");
		}
		
		public IGoal<NPC> popGoal() {
			var poppedGoal = goalStack.Pop();
			this.log($"{owner} finished {currentGoal}, popping.  {this}");
			owner.journal.record($"Satisfied to have completed {currentGoal}.  Maybe now I can get back to {poppedGoal}?");
			return currentGoal = poppedGoal; // is now the currentGoal
		}

		public override string ToString() {
			return $"Goals(currentGoal:{currentGoal?.name}, stack:[{string.Join(", ", goalStack.Select(g => g.name))}])";
		}

#endregion public
#region internal

#endregion internal
#region private
		
		private IGoal<NPC>? currentGoal;

		private readonly Stack<IGoal<NPC>> goalStack = new Stack<IGoal<NPC>>();
		
		private readonly NPC owner;
		
#endregion private
	}
}
