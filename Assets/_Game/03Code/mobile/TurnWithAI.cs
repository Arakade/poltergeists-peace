

#nullable enable
using UnityEngine;
using UnityEngine.AI;

namespace ghostly {
	public sealed class TurnWithAI : Turn2d {
		
		[SerializeField]
		private NavMeshAgent agent = null!;

		public void FixedUpdate() {
			turnToVector(agent.velocity);
		}

	}
}
