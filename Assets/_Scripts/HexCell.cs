using UnityEngine;

    public class HexCell : MonoBehaviour {
        public HexCoordinates Coordinates;
    
        [SerializeField]
        private int _x, _z;

        public int X {
            get {
                return _x;
            }
        }

        public int Z {
            get {
                return _z;
            }
        }

        public void HexCoordinates (int x, int z) {
            this._x = x;
            this._z = z;
        }

    }

