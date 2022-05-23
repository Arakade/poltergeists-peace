
#nullable enable
using System.Collections;
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
		
		public void put<T>(string key, T value) where T : class {
			dictionary[key] = value;
		}
		
		public bool tryGet<T>(string key, out T value) where T : class {
			var o = dictionary[key];
			if (null != (value = (o as T)!))
				return true;
			
			value = default!;
			return false;
		}

#endregion public
#region internal

#endregion internal
#region private
		
		private readonly Hashtable dictionary = new Hashtable();

#endregion private
	}
}
