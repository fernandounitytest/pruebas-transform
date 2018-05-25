using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tile2D : MonoBehaviour {
    private Tank2D tank;
	// Use this for initialization
	void Start ()
    {
        tank = GameObject.Find("Tank").GetComponent<Tank2D>();
        Debug.Log("El tanque se llama:" + tank.name);
        float randomGray = Random.Range(0.7f, 1f);
        GetComponent<SpriteRenderer>().color = new Color(randomGray, randomGray, randomGray);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnMouseUpAsButton()
    {
        Debug.Log("He pulsado sobre la casilla " + this.name);
        tank.MoveToTile(this);
    }

    /*
    //Se mueve en direccion al raton
    private void OnMouseOver()
    {
        tank.MoveToTile(this);
    }
    */
}
