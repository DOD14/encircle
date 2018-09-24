using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyTileProperties : MonoBehaviour {

    public int deltaScore;
    public int deltaHealth;

    public void InitProperties(Color color, int score, int health)
    {
        GetComponent<Renderer>().material.SetColor("_Color", color);
        deltaScore = score;
        deltaHealth = health;
    }

}
