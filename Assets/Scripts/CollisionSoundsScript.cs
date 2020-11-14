using UnityEngine;
using System.Collections;

public class CollisionSoundsScript : MonoBehaviour 
{

	void OnCollisionEnter (Collision col) // Sons liés à la bille lors d'une collision
	{
	 //   if (col.gameObject.tag == "Raquette") // Si la bille tape une raquette
		//{
		//	FMODUnity.RuntimeManager.PlayOneShot ("event:/FAIT/Environnement/Bruitages/Raquettes/Raquettes_impact"); // Bruit d'impact raquette
		//}

		if (col.gameObject.tag == "Bumper_Rond") // Si la bille tape un bumper
		{
			FMODUnity.RuntimeManager.PlayOneShot ("event:/FAIT/Environnement/Bruitages/Bumpers/Bumper_rond_impact"); // Bruit d'impact bumper
		}

		if (col.gameObject.tag == "Bumper_Wall") // Si la bille tape un mur
		{
			FMODUnity.RuntimeManager.PlayOneShot ("event:/FAIT/Environnement/Bruitages/Bumpers/Bumper_mural_impact"); // Bruit d'impact mur
		}

		if (col.gameObject.tag == "Container") // Si la bille tape un container
		{
			FMODUnity.RuntimeManager.PlayOneShot ("event:/FAIT/Environnement/Bruitages/Murs/Cogne_murs"); // Bruit d'impact container
		}

		if (col.gameObject.tag == "Fence") // Si la bille tape une barrière
		{
			FMODUnity.RuntimeManager.PlayOneShot ("event:/FAIT/Environnement/Bruitages/Murs/Cogne_murs"); // Bruit d'impact container (idem que container)
		}
	}
}
