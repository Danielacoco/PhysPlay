using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Traget : MonoBehaviour {

    public ProjectileBehavior projectilePrefab;

    private void OnTriggerEnter(Collider other)
    {
        Instantiate(projectilePrefab.gameObject, transform.position, Quaternion.identity);
        CreateRandomTarget();
        Destroy(this.gameObject);

    }

    void CreateRandomTarget()
    {
        Vector3 position = new Vector3(Random.Range(-1f, 5.5f), Random.Range(-6f, 1.5f), Random.Range(-3.5f, 4f));
        Instantiate(this.gameObject, position, Quaternion.identity);
    }
	
}
