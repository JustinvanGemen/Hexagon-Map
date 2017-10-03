using System.Collections.Generic;
using UnityEngine;

	[RequireComponent(typeof(MeshFilter), typeof(MeshRenderer))]
	public class HexMesh : MonoBehaviour {
	
		private Mesh _hexMesh;
		private List<Vector3> _verts;
		private List<int> _triangles;

		private void Awake () {
			GetComponent<MeshFilter>().mesh = _hexMesh = new Mesh();
			_hexMesh.name = "Hex Mesh";
			_verts = new List<Vector3>();
			_triangles = new List<int>();
		}
	
		public void Triangulate (HexCell[] cells) {
			_hexMesh.Clear();
			_verts.Clear();
			_triangles.Clear();
			foreach (var t in cells)
			{
				Triangulate(t);
			}
			_hexMesh.vertices = _verts.ToArray();
			_hexMesh.triangles = _triangles.ToArray();
			_hexMesh.RecalculateNormals();
		}

		private void Triangulate (Component cell) {
			var center = cell.transform.localPosition;
			for (var i = 0; i < 6; i++) {
				AddTriangle(
					center,
					center + HexMetrics.Corners[i],
					center + HexMetrics.Corners[i + 1]
				);
			}

		}

		private void AddTriangle (Vector3 v1, Vector3 v2, Vector3 v3) {
			var vertexIndex = _verts.Count;
			_verts.Add(v1);
			_verts.Add(v2);
			_verts.Add(v3);
			_triangles.Add(vertexIndex);
			_triangles.Add(vertexIndex + 1);
			_triangles.Add(vertexIndex + 2);
		}

	}
