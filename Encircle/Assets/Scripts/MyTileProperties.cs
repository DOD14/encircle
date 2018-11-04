using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyTileProperties : MonoBehaviour
{

    [HideInInspector]
    public int deltaScore;
    public int deltaHealth;

    private Transform myPlayer;
    private Color myColor;
    private Renderer myRenderer;

    private void OnEnable()
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

    public void LightUp()
    {
        Debug.Log("shine!");
        myRenderer.material.SetColor("_Color", Color.white);
    }

    public void LightOff()
    {
        myRenderer.material.SetColor("_Color", Color.black);
        //try a coroutine to fade more nicely?
        //figure out why the emission color doesn't match the real color
        //move the spawn point further off
        //wait a few seconds before dropping the player? maybe spawn them instead
    }

}