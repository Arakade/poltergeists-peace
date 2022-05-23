

#nullable enable
using ghostly.npc.goals;
using ghostly.npc.states;
using ghostly.utils;
using UnityEngine;
using UnityEngine.Assertions;

namespace ghostly.npc {
	public sealed class NPC : MonoBehaviour, IHasXfrm, IHasPosV2 {
#region serialized

		[SerializeField]
		private NPCMovement movement = null!;

		[SerializeField]
		private PointsOfInterest pointsOfInterest = null!;
		
		[SerializeField]
		public Blackboard blackboard = null!;
		
		[SerializeField]
		public Journal journal = null!;
		
		[SerializeField]
		private HasSpeechBubble hasSpeechBubble = null!;
		
#endregion serialized
#region Unity callbacks

		public void Awake() {
			Assert.IsNotNull(movement);
			Assert.IsNotNull(blackboard);
			Assert.IsNotNull(pointsOfInterest);
			Assert.IsNotNull(journal);
			Assert.IsNotNull(hasSpeechBubble);
			
			xfrm = transform;
			stateEngine = new StateEngine<NPC>(this, new StateEngine<NPC>.IState[] {
				// I'm not happy with the Goals and States divide but I'm too short on time to fix
				new Idle(),
				new MoveToOwnerCurrentDestination(movement),
				new WaitForPeriod(),
			});
			goals = new Goals(this);
		}
		
		public void Start() {
			chooseNextAction();
		}

		public void Update() {
			stateEngine.tick();
		}

#endregion Unity callbacks
#region public
		
		public Transform xfrm { get; private set; } = null!;
		
		public Vector2 posV2 => xfrm.position;

		public StateEngine<NPC> stateEngine { get; private set; } = null!;
		
		public Vector2? currentDestination;
		
		public void recordThought(IGoal<NPC> goal) {
			this.log($"Decided to {goal}");
			journal.record($"Decided to {goal}");
			hasSpeechBubble.speechBubble.setText($"Think I'll {goal}");
		}

		public void onGoalComplete(IGoal<NPC> completedGoal) {
			goals.completedCurrentGoal(completedGoal);
			chooseNextAction();
		}

#endregion public
#region internal

#endregion internal
#region private
		
		private void chooseNextAction() {
			if (goals.hasMoreGoals) {
				var goal = goals.popGoal();
				journal.record($"It's time to {goal}");
				goal.begin();
				return;
			}
			
			// Default goal -- go to a random POI for this NPC
			var (destination, destinationName) = pointsOfInterest.getRandomDestination();
			var visitLocationForABit = new VisitLocationForABit(destination, destinationName);
			recordThought(visitLocationForABit);
			goals.pushNewCurrentGoal(visitLocationForABit);
			visitLocationForABit.begin();
		}
		
		private Goals goals = null!;

#endregion private
	}
}
