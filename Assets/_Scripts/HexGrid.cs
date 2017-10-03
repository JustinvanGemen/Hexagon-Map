using UnityEngine;
using UnityEngine.UI;

	public class HexGrid : MonoBehaviour
	{

		public int Width;
		public int Height;

		[SerializeField]private HexCell _cellPrefab;
		[SerializeField]private HexCell[] _cells;

		[SerializeField] private Text _cellLabelPrefab;
		private Canvas _gridCanvas;
		private HexMesh _hexMesh;

		private void Awake () {
			_gridCanvas = GetComponentInChildren<Canvas>();
			_hexMesh = GetComponentInChildren<HexMesh>();
		
			_cells = new HexCell[Height * Width];

			for (int z = 0, i = 0; z < Height; z++) {
				for (var x = 0; x < Width; x++) {
					CreateCell(x, z, i++);
				}
			}
		}

		private void Start()
		{
			_hexMesh.Triangulate(_cells);
		}

		private void CreateCell (int x, int z, int i) {
			Vector3 position;
			position.x = (x + z * 0.5f - z / 2) * (HexMetrics.InRadius * 2f);
			position.y = 0f;
			position.z = z * (HexMetrics.OutRadius * 1.5f);
		
			var cell = _cells[i] = Instantiate(_cellPrefab);
			cell.transform.SetParent(transform, false);
			cell.transform.localPosition = position;
			cell.Coordinates = HexCoordinates.FromOffsetCoordinates(x, z);
		
			var label = Instantiate(_cellLabelPrefab);
			label.rectTransform.SetParent(_gridCanvas.transform, false);
			label.rectTransform.anchoredPosition =
				new Vector2(position.x, position.z);
			label.text = cell.Coordinates.ToStringOnSeparateLines();
		
		}

	

	}