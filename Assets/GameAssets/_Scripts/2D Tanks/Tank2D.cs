using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tank2D : MonoBehaviour {
    private Tile2D targetTile;
    public float speed = 10f;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (targetTile != null)
        {
            if (IsLookingAtTargetTile())
            {
                //MoveToTileWithTranslate();//Movimiento con traslate
                MoveToTileWithMoveTowards();//Movimiento con towards
            } else
            {
                RotateToTileWithRotateTowards();
            }
        }
    }

    private bool IsLookingAtTargetTile()
    {
        Vector3 lookingDirection = this.transform.forward;
        Vector3 targetDirection = targetTile.transform.position - this.transform.position;
        float angle = Vector3.Angle(lookingDirection, targetDirection);
        if (angle<=1f)
        {
            return true;
        }
        return false;
    }

    private void RotateToTileWithRotateTowards()
    {
        Vector3 targetDirection = targetTile.transform.position - this.transform.position;
        this.transform.forward = Vector3.RotateTowards(
            this.transform.forward, 
            targetDirection,
            Mathf.PI / 2 * Time.deltaTime, 
            0);
    }

    private void MoveToTileWithTranslate()
    {
        //this.transform.position = targetTile.transform.position;//Teletransporte
        //this.transform.LookAt(targetTile.transform);//Mira hacia el target

        if ((Vector3.Distance(this.transform.position, targetTile.transform.position)) > 0.1f)
        {
            Vector3 directionToTile = targetTile.transform.position - this.transform.position;
            directionToTile.Normalize();
            this.transform.Translate(directionToTile * Time.deltaTime * speed);
        }
    }

    private void MoveToTileWithMoveTowards()
    {
        this.transform.position = Vector3.MoveTowards(this.transform.position, targetTile.transform.position, 0.1f);
    }

    public void MoveToTile(Tile2D tile)
    {
        targetTile = tile;
    }
}
