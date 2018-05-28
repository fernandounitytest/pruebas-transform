using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explosion2D : MonoBehaviour {
    [SerializeField] float explosionRadius=3.5f;

    void Start () {
        Invoke("KillEnemies", 0.3f);
	}
	
	void Update () {
		
	}

    void KillEnemies()
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
        for (int i = 0; i < enemies.Length; i++)
        {
            if (Vector3.Distance(this.transform.position, enemies[i].transform.position) < explosionRadius)
            {
                Destroy(enemies[i]);
                Debug.Log("hostia");
            }
        }
        Destroy(this.gameObject);


    }
}
