using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {

    public float sidewaysFactor = 5f;
    public float radialFactor = 5f;
    public float gravity = 10f;

    private Rigidbody rb;

	// Use this for initialization
	void Awake () {
        rb = GetComponent<Rigidbody>();
	}
	
	// Update is called once per frame
	void FixedUpdate () {

        rb.AddForce(-transform.up * gravity);

        Vector3 camPos = Camera.main.transform.position;
        float moveHorizontal = Input.GetAxis("Horizontal");

        bool moveVertical;
        if (Input.GetMouseButton(0))
             moveVertical = true;
        else moveVertical = false;

        //rb.transform.RotateAround(camPos, Camera.main.transform.forward, moveHorizontal * sidewaysFactor);
        Vector3 dirToCam = camPos - transform.position;
        dirToCam = new Vector3(dirToCam.x, dirToCam.y, 0f);

        //float yPos = transform.position.y;
        //int signum = (yPos >= 0 ? -1 : 1);
        if(moveVertical)
            rb.AddForce(dirToCam * radialFactor, ForceMode.Impulse);
        rb.AddRelativeForce(Vector3.right * moveHorizontal * sidewaysFactor, ForceMode.Impulse);
        transform.rotation = Quaternion.LookRotation(Vector3.forward, dirToCam);

        //Get rid of the down arrow, use mouth/touch to approach center
	}

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Tile"))
        {
            MyTileProperties tileProps = collision.gameObject.GetComponent<MyTileProperties>();
            if(tileProps){
                GetComponent<Renderer>().material.SetColor("_Color", collision.gameObject.GetComponent<Renderer>().material.color);
                GameManager.instance.ModifyScore(tileProps.deltaScore);
                GameManager.instance.ModifyHealth(tileProps.deltaHealth);
                tileProps.LightUp();
                Destroy(tileProps);
            }
        }
    }
}
