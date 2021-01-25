using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour
{
    public Score scoreManager;
   
    public ParticleSystem system;
    protected ParticleSystem explode;

    //this method is called whenever a collision is detected
    private void OnCollisionEnter(Collision collision)
    {
        //on collision adding point to the score
        scoreManager.AddPoint();

        // printing if collision is detected on the console
        //Debug.Log("Collision Detected");
        //after collision is detected destroy the gameobject
        Destroy(gameObject);


        //particle system explode
        explode = Instantiate(system, transform.position, Quaternion.identity);

    }
}