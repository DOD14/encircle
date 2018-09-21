using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {

    public float sidewaysFactor = 5f;
    public float radialFactor = 5f;
    public float gravity = 10f;

    private Rigidbody rb;

	// Use this for initialization
	void Start () {
        rb = GetComponent<Rigidbody>();
	}
	
	// Update is called once per frame
	void FixedUpdate () {

        rb.AddForce(-transform.up * gravity);

        Vector3 camPos = Camera.main.transform.position;
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        //rb.transform.RotateAround(camPos, Camera.main.transform.forward, moveHorizontal * sidewaysFactor);
        Vector3 dirToCam = camPos - transform.position;
        dirToCam = new Vector3(dirToCam.x, dirToCam.y, 0f);
        transform.rotation = Quaternion.LookRotation(Vector3.forward, dirToCam);
        rb.AddForce(dirToCam * moveVertical * radialFactor, ForceMode.Impulse);
        rb.AddRelativeForce(Vector3.right * moveHorizontal * sidewaysFactor, ForceMode.Impulse);
	}
}
