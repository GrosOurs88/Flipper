using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LancementBalleScript : MonoBehaviour
{
    public GameObject bille;
    public float puissance;
    [HideInInspector]
    public Transform launcher;
    private Rigidbody rgBille;

    void Start()
    {
        launcher = GetComponent<Transform>();
        newball(bille, launcher, puissance);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            newball(bille, launcher, puissance);
        }
    }

    public void newball(GameObject _bille, Transform _launcher, float _puissance)
    {
        GameObject newBall = Instantiate(_bille, _launcher.transform.position, Quaternion.identity);
        FMODUnity.RuntimeManager.PlayOneShot("event:/FAIT/Environnement/Bruitages/Rampe/Sortie_Rampe");
        rgBille = newBall.GetComponent<Rigidbody>();
        rgBille.AddRelativeForce(_launcher.transform.forward * _puissance, ForceMode.Impulse);
    }
}
		
