using UnityEngine;

#nullable enable
namespace ghostly.utils {
	public static class Log {
		
		// ReSharper disable Unity.PerformanceAnalysis = logging
		public static void log(this object context, string txt) {
			Debug.Log(txt, context as Object);
		}
		
		// ReSharper disable Unity.PerformanceAnalysis = logging
		public static void warn(this object context, string txt) {
			Debug.LogWarning(txt, context as Object);
		}
		
		// ReSharper disable Unity.PerformanceAnalysis = logging
		public static void error(this object context, string txt) {
			Debug.LogError(txt, context as Object);
		}

	}
}
