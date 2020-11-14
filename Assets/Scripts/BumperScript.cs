using UnityEngine;
using System.Collections;

public class BumperScript : MonoBehaviour 
{
    public float force; // Force de répulsion du bumper
    public float PVInit = 20; // Nombre de PV initial du bumper
    public ParticleSystem explosionParticleSystem; // Systeme de particule pour l'explosion du bumper
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
            anim.SetTrigger("Hit");
			Rigidbody r = other.gameObject.GetComponent<Rigidbody>(); // Le rigidbody de la bille
			Vector3 repulseDir = -other.contacts[0].normal; // On répulse la bille par rapport à son angle d'arrivée sur le bumper
			r.AddForce(repulseDir.normalized * force, ForceMode.Impulse); // On le repousse d'une force donnée
		}
       
        if (PVActuel == 0) // Si le bumper n'a plus de points de vie
        {
            explosionParticleSystem.Play();
            FMODUnity.RuntimeManager.PlayOneShot("event:/FAIT/Lancement/Lancement_bille"); // On joue un son d'explosion
            Destroy(gameObject); // On détruit l'objet de la scène
        }
    }
}
