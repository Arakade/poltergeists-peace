

#nullable enable
using ghostly.npc.goals;
using ghostly.npc.states;
using ghostly.utils;
using UnityEngine;

namespace ghostly.npc {
	public sealed class NPC : MonoBehaviour, IHasXfrm, IHasPosV2 {
#region serialized

		[SerializeField]
		private NPCMovement movement = null!;

		[SerializeField]
		private PointsOfInterest pointsOfInterest = null!;
		
#endregion serialized
#region Unity callbacks

		public void Awake() {
			xfrm = transform;
			stateEngine = new StateEngine<NPC>(this, new StateEngine<NPC>.IState[] {
				new MoveToOwnerCurrentDestination(movement),
			});
			goals = new Goals<NPC>(this);
			chooseNextAction();
		}

#endregion Unity callbacks
#region public
		
		public Transform xfrm { get; private set; } = null!;
		
		public Vector2 posV2 => xfrm.position;

		public StateEngine<NPC> stateEngine { get; private set; } = null!;
		
		public Vector2? currentDestination;

#endregion public
#region internal

#endregion internal
#region private
		
		private void chooseNextAction() {
			if (goals.hasMoreGoals) {
				goals.popGoal().begin();
				return;
			}
			
			// Default goal -- go to a random POI for this NPC
			var (destination, destinationName) = pointsOfInterest.getRandomDestination();
			goals.pushNewCurrentGoal(new VisitLocationForABit(destination, destinationName));
		}
		
		private Goals<NPC> goals = null!;

#endregion private
	}
}
