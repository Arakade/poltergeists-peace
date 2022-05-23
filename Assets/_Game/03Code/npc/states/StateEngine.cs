
using System;
using System.Linq;
using ghostly.utils;
using UnityEngine.Assertions;

#nullable enable
namespace ghostly.npc.states {
	/// States for brains.
	public sealed class StateEngine<T> where T : class {
#region public
		
		public T owner { get; }
		
		public IState currentState { get; private set; } = null!;

		public int currentStateIndex { get; private set; }

		public event OnStateChange? onStateChange;

		public delegate void OnStateChange(StateEngine<T> stateEngine, IState oldState, IState newState);
		
		public StateEngine(T owner, IState[] states, int initial = 0) {
			Assert.IsNotNull(owner);
			Assert.IsTrue(0 < states.Length, $"No states given for {owner}");
			Assert.IsTrue(0 <= initial && initial <= states.Length, $"Initial state {initial} is outside valid states 0..{states.Length} for {owner}");

			this.owner = owner;
			this.states = states;
			for (var i = 0; i < states.Length; i++) {
				states[i].setOwner(owner);
				states[i].engine = this;
				states[i].onValidateState();
				states[i].init();
				// Disable all to start with then enterState() call below will enable The One
				states[i].onStateExit();
			}
			enterState(initial);
		}
		
		public void changeState(string stateName) {
			changeState(getStateIndexByName(stateName));
		}

		private int getStateIndexByName(string stateName) {
			for (var i = 0; i < states.Length; i++) {
				if (stateName == states[i].name)
					return i;
			}
			owner.error($"Failed to find state \"{stateName}\" in {this}");
			throw new Exception($"Failed to find state \"{stateName}\" in {this}");
		}


		public void changeState(int stateIndex) {
			Assert.IsTrue(0 <= stateIndex && stateIndex < states.Length, $"{stateIndex} is not a valid state index (0..{states.Length}) for {this} on {owner}");
			if (stateIndex == currentStateIndex) {
				this.log($"Skipping exiting and re-entering state {stateIndex} for {this}");
				return;
			}

			currentState.onStateExit();
			enterState(stateIndex);
		}

		public void tick() {
			currentState.onTick();
		}
		
		public override string ToString() {
			return $"{GetType().Name}-{typeof(T).Name}(currentState:{currentState.name} = {currentState} of {states.Length} states:[{string.Join(", ", states.Select(s => s.name))}]";
		}
		
#region Types
		
		public interface IState {
		
			string name { get; }

			StateEngine<T> engine { set; }

			void onValidateState();
			public void setOwner(T newOwner);

			void init();

			void onStateEnter();
			void onTick();
			void onStateExit();
		}
		
		
		public abstract class StateBase : IState {

			public virtual string name => GetType().Name;

			public StateEngine<T> engine { protected get; set; } = null!;

			public void setOwner(T newOwner) {
				owner = newOwner;
			}

			public virtual void onValidateState() {
			}

			public virtual void init() {
			}

			public virtual void onStateEnter() {
			}

			public virtual void onStateExit() {
			}

			public virtual void onTick() {
			}

			protected T owner = null!;
		}
		
#endregion Types
#endregion public
#region internal

#endregion internal
#region private

		private void enterState(int stateIndex) {
			owner.log($"state ({currentStateIndex}:{currentState}) -> ({stateIndex}:{states[stateIndex]}) on {owner}");
			var oldState = currentState;
			currentStateIndex = stateIndex;
			currentState = states[stateIndex];
			currentState.onStateEnter(); // has to be last in case its onEnter() prompts another state change!
			if (null != onStateChange) {
				onStateChange(this, oldState, currentState);
			}
		}
		
		private readonly IState[] states;

#endregion private
	}
}
