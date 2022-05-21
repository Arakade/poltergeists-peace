using ghostly.utils;
using UnityEngine;
using UnityEngine.AI;
#if UNITY_EDITOR
using UnityEditor;
#endif

#nullable enable
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
			if (ReferenceEquals(null, wayPoints) || 0 >= wayPoints.Length) {
				this.log($"No waypoints for {this}");
				return;
			}
				
			selectNewDestination();
		}
		
#if UNITY_EDITOR
		public void OnDrawGizmosSelected() {
			if (!Application.isPlaying)
				return;
			
			Handles.BeginGUI();
			Handles.Label(transform.position, $"hasPath:{agent.hasPath}\ndist:{agent.remainingDistance}\nstopped:{agent.isStopped}");
			Handles.EndGUI();
		}
#endif

#endregion Unity callbacks
#region public

		public void Update() {
			if (hasArrived()) {
				selectNewDestination();
			}
		}

#endregion public
#region internal

#endregion internal
#region private
		
		private bool hasArrived() {
			if (agent.pathPending)
				return false;
			
			if (!agent.hasPath) {
				this.warn($"{this} has no path");
				return true;
			}
			
			return agent.remainingDistance <= agent.stoppingDistance;
		}

		private void selectNewDestination() {
			var pos = getRandomDestination();
			agent.SetDestination(pos);
		}

		private Vector3 getRandomDestination() {
			var destWP = wayPoints[Random.Range(0, wayPoints.Length)];
			var pos = destWP.transform.position;
			this.log($"{this} going to {destWP} = {pos}");
			return pos;
		}

		private WayPoint[] wayPoints = null!;

#endregion private
	}
}
