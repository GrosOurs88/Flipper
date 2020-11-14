using UnityEngine;
using System.Collections;

public class CibleFixeScript : MonoBehaviour 
{
    public float force; // Force de répulsion du bumper
    private Animator anim;

    void Start()
    {
        anim = GetComponent<Animator>();
    }

	void OnCollisionEnter (Collision other)
	{
		if (other.gameObject.tag == "Ball") // Si c'est la balle qui tappe dans un bumper
		{
            anim.SetTrigger("Hit");
            FMODUnity.RuntimeManager.PlayOneShot("event:/FAIT/Environnement/Bruitages/Bumpers/Bumper_rond_impact"); // On joue un son d'explosion
            Rigidbody r = other.gameObject.GetComponent<Rigidbody>(); // Le rigidbody de la bille
			Vector3 repulseDir = -other.contacts[0].normal; // On répulse la bille par rapport à son angle d'arrivée sur le bumper
			r.AddForce(repulseDir.normalized * force, ForceMode.Impulse); // On le repousse d'une force donnée
		}
    }
}
