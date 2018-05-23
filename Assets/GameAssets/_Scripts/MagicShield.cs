using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MagicShield : MonoBehaviour {

    public GameObject target;//Objeto sobre el que va a dar vueltas
    public float rotationSpeed=360f;//Velocidad de rotación (grados por segundo)
    public float distanceToTarget = 5;

	// Update is called once per frame
	void Update () {
        this.transform.RotateAround(target.transform.position, Vector3.up, rotationSpeed * Time.deltaTime);
        //Calculo la distancia
        Vector3 directionFromTarget = this.transform.position - target.transform.position;
        //Elimino la componente y para que no se tenga en cuenta la altura de la bola en el cálculo
        directionFromTarget.y = 0;
        //Normalizo el vector
        directionFromTarget.Normalize();
        this.transform.position = target.transform.position + directionFromTarget * distanceToTarget;
	}
}
