using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankMovement : MonoBehaviour {
    public float speed = 10;//Metros por segundo
    public float rotationSpeed = 90;//Grados por segundos
    public GameObject target;
    public GameObject turretBone;
    public GameObject cannonBone;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        float vInput = Input.GetAxis("Vertical");
        float hInput = Input.GetAxis("Horizontal");
        //Desplazamiento con coorenadas locales
        //this.transform.position += 
        //    this.transform.forward * Time.deltaTime * speed * vInput;
        //Desplazamiento con coordenadas globales pero convierte las coordenadas a local
        this.transform.Translate(Vector3.forward * Time.deltaTime * speed * vInput);

        //Rotación con coordenadas globales
        this.transform.Rotate(new Vector3(0, rotationSpeed * Time.deltaTime * hInput, 0));
        //OTRA OPCIÓN PARA LO MISMO
        //this.transform.Rotate(Vector3.up * rotationSpeed * Time.deltaTime);

        Vector3 targetPosition = target.transform.position;
        Vector3 turretTargetPosition = targetPosition;
        turretTargetPosition.y = turretBone.transform.position.y;
        turretBone.transform.LookAt(turretTargetPosition);

        cannonBone.transform.LookAt(targetPosition);
	}
}
