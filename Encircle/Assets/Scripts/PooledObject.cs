using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// a component that simply identifies the pool that a GameObject came from
public class PooledObject : MonoBehaviour
{
    public SimpleObjectPool pool;
    public float lifetime = 5f;
    private float timer;

    // Use this for initialization
    void OnEnable()
    {
        timer = 0f;
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if (timer > lifetime)
        {
            pool.ReturnObject(this.gameObject);
        }
    }
}