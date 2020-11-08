using UnityEngine;
using System.Collections;

public class Bumper : MonoBehaviour 
{
    public float force; // Force de répulsion du bumper
    public float PVInit = 20; // Nombre de PV initial du bumper
    public ParticleSystem explosionParticleSystem; // Systeme de particule pour l'explosion du bumper
    private float PVActuel; // Nombre de PV actuel du bumper
    private Material myMaterial; // Material du bumper
    private Animator anim;

    void Start()
    {
        anim = GetComponent<Animator>();
        myMaterial = GetComponent<Renderer>().materials[1]; // Deuxième material du bumper
        myMaterial.color = Color.white; // Sa lumière est bleue
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

        if (PVActuel >= 2 * (PVInit / 3)) // Si le bumper à plus de 2/3 de ses points de vie
        {
            myMaterial.color = Color.white; // Sa lumière est bleue
        }
        else if (PVActuel < 2 * (PVInit / 3) && PVActuel >= PVInit / 3) // Si le bumper à entre 2/3 et 1/3 de ses points de vie
        {
            myMaterial.color = Color.grey; // Sa lumière est jaune
        }
        else if (PVActuel < PVInit / 3 && PVActuel > 0) // Si le bumper à entre 1/3 et 1 points de vie
        {
            myMaterial.color = Color.black; // Sa lumière est rouge
        }
        else if (PVActuel == 0) // Si le bumper n'a plus de points de vie
        {
            explosionParticleSystem.Play();
            FMODUnity.RuntimeManager.PlayOneShot("event:/FAIT/Lancement/Lancement_bille"); // On joue un son d'explosion
            Destroy(gameObject); // On détruit l'objet de la scène
        }
    }
}
