using UnityEngine;
using System.Collections;

public class CibleTombanteScript : MonoBehaviour 
{
    public float force; // Force de répulsion du bumper
    private Animator anim;

    void Start()
    {
        anim = GetComponent<Animator>();
    }

	void OnCollisionEnter (Collision other)
	{
        print("A");
		if (other.gameObject.tag == "Ball") // Si c'est la balle qui tappe dans un bumper
		{
            print("B");
            FMODUnity.RuntimeManager.PlayOneShot("event:/FAIT/Environnement/Bruitages/Bumpers/Bumper_mural_impact"); // On joue un son d'explosion
            anim.SetTrigger("Hit");
			Rigidbody r = other.gameObject.GetComponent<Rigidbody>(); // Le rigidbody de la bille
			Vector3 repulseDir = -other.contacts[0].normal; // On calcul l'angle d'arrivée sur le bumper
			r.AddForce(repulseDir.normalized * force, ForceMode.Impulse); // On le repousse d'une force donnée
		}
    }
}
