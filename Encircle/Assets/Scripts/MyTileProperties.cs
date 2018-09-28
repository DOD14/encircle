using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyTileProperties : MonoBehaviour {

    [HideInInspector]
    public int deltaScore;
    public int deltaHealth;

    private Transform myPlayer;
    private Color myColor;
    private Renderer myRenderer;


	private void Start()
	{
        myRenderer = GetComponent<Renderer>();
	}

	public void InitProperties(Color color, int score, int health, Transform player)
    {
        myColor = color;
        myPlayer = player;
        myRenderer.material.SetColor("_Color", myColor);
        deltaScore = score;
        deltaHealth = health;
    }

	private void FixedUpdate()
	{
        while(Mathf.Abs(transform.position.z - myPlayer.position.z) < 1f && )

            myRenderer.material.SetColor("_EmissionColor", myColor);
        
	}
}
