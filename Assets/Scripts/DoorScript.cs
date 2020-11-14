﻿using UnityEngine;
using System.Collections;

public class DoorScript : MonoBehaviour 
{
    public float force; // Force de répulsion du bumper
    public float PVInit = 20; // Nombre de PV initial du bumper
    private float PVActuel; // Nombre de PV actuel du bumper
    private Animator anim;

    void Start()
    {
        anim = GetComponent<Animator>();
        PVActuel = PVInit; // On set le nombre de points de vie au max
    }

	void OnCollisionEnter (Collision other)
	{
		if (other.gameObject.tag == "Ball") // Si c'est la balle qui tappe dans un bumper
		{
			PVActuel -= 1; // Le bumper perd 1 PV           
			Rigidbody r = other.gameObject.GetComponent<Rigidbody>(); // Le rigidbody de la bille
			Vector3 repulseDir = -other.contacts[0].normal; // On répulse la bille par rapport à son angle d'arrivée sur le bumper
			r.AddForce(repulseDir.normalized * force, ForceMode.Impulse); // On le repousse d'une force donnée
		}
       
        if (PVActuel == 0) // Si le bumper n'a plus de points de vie
        {
            anim.SetTrigger("Hit");
            FMODUnity.RuntimeManager.PlayOneShot("event:/FAIT/Environnement/Bruitages/Bumpers/Bumper_rond_impact"); // On joue un son d'explosion
        }
    }
}
