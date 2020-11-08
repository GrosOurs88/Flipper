using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class Boutons_quit_and_replay : MonoBehaviour
{
	public void clicQuit()
	{
		Application.Quit (); // En cliquant sur le bouton "Quit", on ferme l'application
	}

	public void clicReplay()
	{
		SceneManager.LoadScene ("Flipper_niveau1"); // En cliquant sur le bouton "Replay", on lance une nouvelle partie
	}
    public void Update()
    {
        if(Input.GetKeyDown(KeyCode.Return))
        {
            Scene scene = SceneManager.GetActiveScene(); 
            SceneManager.LoadScene(scene.name);
        }
    }
}