using UnityEngine;

#nullable enable
namespace ghostly.utils {
	public static class Log {
		
		public static void log(this object context, string txt) {
			Debug.Log(txt, context as Object);
		}
		
		public static void warn(this object context, string txt) {
			Debug.LogWarning(txt, context as Object);
		}
		
		public static void error(this object context, string txt) {
			Debug.LogError(txt, context as Object);
		}

	}
}
