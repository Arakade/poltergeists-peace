
#nullable enable
using System;
using System.Collections;
using ghostly.utils;
using UnityEngine;

namespace ghostly.npc {
	/// AI memory.
	public sealed class Blackboard : MonoBehaviour {
#region serialized

		// MB in case wish to pre-populate some data!

#endregion serialized
#region Unity callbacks

#endregion Unity callbacks
#region public
		
		public void put<T>(string key, T value) {
			dictionary[key] = value;
		}
		
		public bool has(string key) => dictionary.ContainsKey(key);
		
		public bool tryGetStructType<T>(string key, out T value) where T : struct {
			if (!dictionary.ContainsKey(key)) {
				this.log($"{this}[{key}] does not exist (expected to be a {typeof(T)})");
				value = default;
				return false;
			}
			
			var o = dictionary[key];
			try {
				value = (T) o;
				return true;
			} catch (InvalidCastException) {
				this.error($"{this}[{key}] has value {o} which is not a {typeof(T)}");
				value = default;
				return false;
			}
		}

		public bool tryGetRefType<T>(string key, out T value) where T : class {
			if (!dictionary.ContainsKey(key)) {
				this.log($"{this}[{key}] does not exist (expected to be a {typeof(T)})");
				value = default!;
				return false;
			}
			
			var o = dictionary[key];
			if (null != (value = (o as T)!))
				return true;
			
			this.error($"{this}[{key}] has value {o} which is not a {typeof(T)}");
			value = default!;
			return false;
		}

		public void delete(string key) {
			dictionary.Remove(key);
		}

#endregion public
#region internal

#endregion internal
#region private
		
		private readonly Hashtable dictionary = new Hashtable();

#endregion private
	}
}
