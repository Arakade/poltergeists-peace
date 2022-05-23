
#nullable enable
namespace ghostly.npc.goals {
	public interface IGoal<T> where T : class {

		string name { get; }
		
		void setOwner(T owner);
		
		void begin();
		
	}
	
	public abstract class GoalBase : IGoal<NPC> {
		public virtual string name => GetType().Name;
		
		public virtual void setOwner(NPC theOwner) {
			this.owner = theOwner;
		}
		
		public abstract void begin();
		
		protected void goalComplete() {
			owner.onGoalComplete(this);
		}

		public override string ToString() => name;

		protected NPC owner = null!;
	}
	
}
