using System;
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
			this.log($"{this} disabling");
			enabled = false;
			agent.updateRotation = false;
			agent.updateUpAxis = false;
		}

		public void Update() {
			if (hasArrived()) {
				this.log($"{this} disabling");
				enabled = false;
				onArrived?.Invoke();
			}
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
		
		public event Action? onArrived;
		
		public float stoppingDistance => agent.stoppingDistance;
		
		public void goTo(Vector2 pos) {
			this.log($"{this} enabling");
			enabled = true;
			agent.SetDestination(pos);
		}

#endregion public
#region internal

#endregion internal
#region private
		
		private bool hasArrived() {
			if (agent.pathPending)
				return false;
			
			// if (!agent.hasPath) {
			// 	this.warn($"{this} has no path");
			// 	return true;
			// }
			
			return agent.remainingDistance <= stoppingDistance;
		}

#endregion private
	}
}
