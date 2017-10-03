using UnityEngine;

	public static class HexMetrics {

		public const float OutRadius = 10f;

		public const float InRadius = OutRadius * 0.866025404f;
	
		public static Vector3[] Corners = {
			new Vector3(0f, 0f, OutRadius),
			new Vector3(InRadius, 0f, 0.5f * OutRadius),
			new Vector3(InRadius, 0f, -0.5f * OutRadius),
			new Vector3(0f, 0f, -OutRadius),
			new Vector3(-InRadius, 0f, -0.5f * OutRadius),
			new Vector3(-InRadius, 0f, 0.5f * OutRadius),
			new Vector3(0f, 0f, OutRadius)
		};
	}


