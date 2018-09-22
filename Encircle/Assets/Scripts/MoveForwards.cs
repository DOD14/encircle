﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveForwards : MonoBehaviour {

    public float speed = 1f;

	// Update is called once per frame
	void Update () {
        transform.position += -Vector3.forward * Time.deltaTime * speed;
	}
}
