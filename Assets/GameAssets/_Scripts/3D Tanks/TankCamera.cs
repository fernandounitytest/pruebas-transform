using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankCamera : MonoBehaviour {
    public GameObject target;
    public float sensitivity = 0.5f;
    public Vector3 followDistance = new Vector3(0, 20, -20);

	// Use this for initialization
	void Start () {
        //OPCION 1: Con coordenadas globales
        //this.transform.position = target.transform.position + followDistance;

        //OPCION 2: Con desplazamientos sobre la posición del target
        /*
        this.transform.position = target.transform.position +
            target.transform.forward * followDistance.z +
            target.transform.up * followDistance.y + 
            target.transform.right * followDistance.x;
        this.transform.LookAt(target.transform);
        this.transform.SetParent(target.transform);
        */

        //OPCION 3, NO NECESITA EL CÓDIGO DE LATE UPDATE
        this.transform.SetParent(target.transform);
        this.transform.localPosition = followDistance;
        this.transform.LookAt(target.transform);
	}

    private void Update()
    {
        //GetMouseButton(1) se corresponde con el click derecho
        if (Input.GetMouseButton(1))
        {
            float xInput = Input.GetAxis("Mouse X");
            this.transform.RotateAround(
                point:target.transform.position, 
                axis:Vector3.up, 
                angle:xInput * sensitivity);
        }

    }

    // Si lo hiciésemos en Update, petardea
    /*
	void LateUpdate () {
        this.transform.position = target.transform.position +
            target.transform.forward * followDistance.z +
            target.transform.up * followDistance.y +
            target.transform.right * followDistance.x;
        this.transform.LookAt(target.transform);
    }
    */
}
