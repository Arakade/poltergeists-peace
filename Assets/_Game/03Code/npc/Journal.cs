using System;
using System.Collections.Generic;
using Unity.Collections;
using UnityEngine;
#if UNITY_EDITOR
using UnityEditor;
#endif

#nullable enable
namespace ghostly.npc {
	/// A record of their actions and goals.
	/// Might allow player to quiz people for things or see as book?
	public sealed class Journal : MonoBehaviour {

		[SerializeField, ReadOnly]
		private List<string> entries = new List<string>();
		
		public event Action? onNewEntry;

		public void record(string txt) {
			entries.Add(txt);
			onNewEntry?.Invoke();
		}
		
#if UNITY_EDITOR
		public void OnDrawGizmosSelected() {
			if (!Application.isPlaying)
				return;
			
			if (!hasGizmoRegisteredForUpdates) {
				hasGizmoRegisteredForUpdates = true;
				onNewEntry += rebuildGizmoEntriesTxt;
				rebuildGizmoEntriesTxt();
			}
			
			Handles.BeginGUI();
			Handles.Label(transform.position, gizmoEntriesTxt);
			Handles.EndGUI();
		}
		
		private void rebuildGizmoEntriesTxt() {
			gizmoEntriesTxt = "Journal:\n" + string.Join("\n", entries);
		}
		
		private string? gizmoEntriesTxt;
		private bool hasGizmoRegisteredForUpdates;
#endif // UNITY_EDITOR

	}
}
