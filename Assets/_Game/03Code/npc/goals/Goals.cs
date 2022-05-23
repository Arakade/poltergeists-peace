
#nullable enable
using System.Collections.Generic;
using System.Linq;
using ghostly.utils;

namespace ghostly.npc.goals {
	/// Stack of things to do (<see cref="IGoal{T}"/>s).
	/// <see cref="currentGoal"/> is pushed down by a new one.
	public sealed class Goals<T> where T : class {
#region public
		
		/// Whether it has more goals beyond the <see cref="currentGoal"/>.
		public bool hasMoreGoals => goalStack.Count > 0;
		
		public Goals(T owner) {
			this.owner = owner;
		}
		
		public void pushNewCurrentGoal(IGoal<T> goal) {
			if (null != currentGoal)
				goalStack.Push(currentGoal);
			
			goal.setOwner(owner);
			currentGoal = goal;
			this.log($"{owner} {this}");
		}
		
		public IGoal<T> popGoal() {
			var poppedGoal = goalStack.Pop();
			this.log($"{owner} finished {currentGoal}, popping.  {this}");
			return currentGoal = poppedGoal; // is now the currentGoal
		}

		public override string ToString() {
			return $"Goals(currentGoal:{currentGoal}, stack:{string.Join(", ", goalStack.Select(g => g.name))})";
		}

#endregion public
#region internal

#endregion internal
#region private
		
		private IGoal<T>? currentGoal;

		private readonly Stack<IGoal<T>> goalStack = new Stack<IGoal<T>>();
		
		private readonly T owner;
		
#endregion private
	}
}
