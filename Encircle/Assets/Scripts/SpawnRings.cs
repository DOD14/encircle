using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnRings : MonoBehaviour {

    public float interval = 5f;

    private SimpleObjectPool poolScript;
    private float timer;

	// Use this for initialization
	void Awake () {
        poolScript = GetComponent<SimpleObjectPool>();
        timer = 0f;
        SpawnRing();
	}
	
	// Update is called once per frame
	void Update () {
        timer += Time.deltaTime;
        if(timer>interval)
        {
            timer = 0f;
            SpawnRing();
        }
	}

    void SpawnRing()
    {
        GameObject ring = poolScript.GetObject();
        ring.transform.position = new Vector3(0f, 0f, 16f);
        //consider creating a spawnpoint GameObject
    }

}
