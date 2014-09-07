using System;
using UnityEngine;
using System.Collections;

public class Explode : MonoBehaviour
{
    public ParticleSystem Explosion;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            other.SendMessage("OnTriggerEnter2D", collider2D); // Force the other dude to get this message too.
            var explosion = Instantiate(Explosion, transform.position, Quaternion.identity) as ParticleSystem;
            Destroy(explosion, Explosion.startLifetime);
            Destroy(gameObject);
        }
    }

    void OnBecameInvisible()
    {
        Destroy(gameObject);
    }
}
