
#nullable enable
using UnityEngine;
using UnityEngine.AI;

namespace ghostly.npc {
	public sealed class NPCMovement : MonoBehaviour {
#region serialized
		
		[SerializeField]
		private NavMeshAgent agent = null!;

#endregion serialized
#region Unity callbacks

		public void Awake() {
			wayPoints = FindObjectsOfType<WayPoint>();
			
			agent.updateRotation = false;
			agent.updateUpAxis = false;
		}

		public void Start() {
			if (null == wayPoints || 0 >= wayPoints.Length) {
				Debug.LogWarning($"No waypoints for {this}");
				return;
			}
				
			// var destWP = wayPoints[Random.Range(0, wayPoints.Length)];
			var destWP = wayPoints[0];
			var pos = destWP.transform.position;
			Debug.Log($"{this} going to {destWP} = {pos}");
			agent.SetDestination(pos);
		}

#endregion Unity callbacks
#region public

#endregion public
#region internal

#endregion internal
#region private
		
		private WayPoint[]? wayPoints;

#endregion private
	}
}
