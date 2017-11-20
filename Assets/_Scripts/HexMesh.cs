using UnityEngine;
using System.Collections.Generic;

[RequireComponent(typeof(MeshFilter), typeof(MeshRenderer))]
public class HexMesh : MonoBehaviour {
	private Mesh _hexMesh;
	private List<Vector3> _verts;
	private List<Color> _colors;
	private List<int> _triangles;

	private MeshCollider _meshCollider;

	private void Awake () {
		GetComponent<MeshFilter>().mesh = _hexMesh = new Mesh();
		_meshCollider = gameObject.AddComponent<MeshCollider>();
		_hexMesh.name = "Hex Mesh";
		_verts = new List<Vector3>();
		_colors = new List<Color>();
		_triangles = new List<int>();
	}

	public void Triangulate (HexCell[] cells) {
		_hexMesh.Clear();
		_verts.Clear();
		_colors.Clear();
		_triangles.Clear();
		for (var i = 0; i < cells.Length; i++) {
			Triangulate(cells[i]);
		}
		_hexMesh.vertices = _verts.ToArray();
		_hexMesh.colors = _colors.ToArray();
		_hexMesh.triangles = _triangles.ToArray();
		_hexMesh.RecalculateNormals();
		_meshCollider.sharedMesh = _hexMesh;
	}

	private void Triangulate (HexCell cell) {
		var center = cell.transform.localPosition;
		for (var i = 0; i < 6; i++) {
			AddTriangle(
				center,
				center + HexMetrics.Corners[i],
				center + HexMetrics.Corners[i + 1]
			);
			AddTriangleColor(cell.Color);
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

	private void AddTriangleColor (Color color) {
		_colors.Add(color);
		_colors.Add(color);
		_colors.Add(color);
	}
}