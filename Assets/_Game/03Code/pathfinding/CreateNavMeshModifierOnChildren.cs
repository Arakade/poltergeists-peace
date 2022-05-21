#nullable enable
using UnityEngine;
using UnityEngine.AI;

namespace ghostly.pathfinding {
	public sealed class CreateNavMeshModifierOnChildren : MonoBehaviour {
#region serialized

		[SerializeField] private int area = 1;

#endregion serialized
#region Unity callbacks

		[ContextMenu("Add obstacles to child colliders")]
		private void addObstaclesToChildColliders() {
			var children = GetComponentsInChildren<Collider2D>();
			foreach (var c in children) {
				// If it already has a NMM, skip
				if (null != (c.GetComponent<NavMeshModifier>())) {
					continue;
				}

				var obstacle = c.gameObject.AddComponent<NavMeshModifier>();
				obstacle.area = area;
				obstacle.overrideArea = true;
			}

			// NavMeshAssetManager.instance.StartBakingSurfaces(targets);
		}


		[ContextMenu("Remove obstacles from all children")]
		private void removeObstaclesFromChildren() {
			var children = GetComponentsInChildren<NavMeshModifier>();
			foreach (var obstacle in children) {
				DestroyImmediate(obstacle);
			}
		}

#endregion Unity callbacks
#region public

#endregion public
#region internal

#endregion internal
#region private

#endregion private
	}
}
