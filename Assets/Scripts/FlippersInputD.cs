﻿using UnityEngine;
using System.Collections;

public class FlippersInputD : MonoBehaviour
{
	private Rigidbody rb;
	private HingeJoint joint;
	public float force;
	public float maxAngularForce;
    public KeyCode inputKey;

	void Start () 
	{
		rb = GetComponent<Rigidbody> (); // On prend le rigidbody de la raquette
		rb.maxAngularVelocity = maxAngularForce; // On défini une valeur angulaire maximum lors de la frappe
		joint = GetComponent<HingeJoint> (); // On va chercher l'Hinge Joint de la raquette
	}

	void Update () 
	{
        if (Input.GetKeyDown(inputKey)) // Lors du maintien de la touche
        {
            PointerUp();
            FMODUnity.RuntimeManager.PlayOneShot("event:/FAIT/Environnement/Bruitages/Raquettes/Raquette_mouvement");
        }

        if (Input.GetKey(inputKey)) // Lors du maintien de la touche
		{
			rb.AddTorque(Vector3.up * force, ForceMode.Force); // On garde la force pour maintenir la raquette vers le haut
		}
	}
	public void PointerUp()
	{
		print ("up");
		joint.useSpring = true; // On utilise le ressort de rappel
	}
	public void PointerDown()
	{
		print ("down");
		rb.AddTorque(Vector3.up * force, ForceMode.Impulse); // On projette la raquette angulairement d'une certaine force
		joint.useSpring = false; // On utilise pas le ressort de rappel
	}
}
