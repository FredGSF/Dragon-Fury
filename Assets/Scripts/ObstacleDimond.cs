using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ObstacleDimond : MonoBehaviour
{
     public float speed;
	 
    

	void Update () {
		
        transform.Translate(Vector2.left * speed * Time.deltaTime);
		
	}

    private void OnTriggerEnter2D(Collider2D other)
    {
		
        if (other.CompareTag("Player")) {
			
            Destroy(gameObject);
        }   
    }
}
