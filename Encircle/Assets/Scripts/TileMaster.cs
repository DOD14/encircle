using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileMaster : MonoBehaviour {

    public GameObject[] tiles;
    public TileKind[] tileKinds;

	// Use this for initialization
	private void OnEnable()
	{
		
	}

    public class TileKind {

        public Color color;
        public float scoreChange;
        public float healthChange;
        public float probabilityRating;

    }
}
