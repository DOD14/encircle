using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileMaster : MonoBehaviour {

    public GameObject[] tiles;
    public TileKind[] tileKinds;

	// Use this for initialization
	private void OnEnable()
	{
        SetupTilesProperties();	
	}

    [System.Serializable]
    public class TileKind {

        public Color color;
        public int scoreChange;
        public int healthChange;
        public int probabilityRating;

    }

    void SetupTilesProperties()
    {
        int sum = 0;
        int length = tileKinds.Length;

        foreach(TileKind tileKind in tileKinds)
        {
            sum += tileKind.probabilityRating;
        }

        int[] intervals = new int[length+1];
        int counter = 0;

        for (int i = 0; i < length; i++)
        {
            intervals[i] = counter;
            counter += tileKinds[i].probabilityRating;
        }

        foreach(GameObject tile in tiles)
        {
            float randomPick = sum * Random.value;
            for (int i = 0; i < length; i++)
            {
                if (randomPick >= intervals[i] && randomPick <= intervals[i + 1])
                {
                    TileKind tileKind = tileKinds[i];
                    MyTileProperties propertiesScript = tile.AddComponent<MyTileProperties>();
                    propertiesScript.InitProperties(tileKind.color, tileKind.scoreChange, tileKind.healthChange);
                    break;
                }
            }
        }

    }
}
