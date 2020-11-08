using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LancementBalle : MonoBehaviour
{
    public GameObject bille;
    public Transform launcher; 
    public float puissance;
    private Rigidbody rgBille;

    void Start()
    {
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
        FMODUnity.RuntimeManager.PlayOneShot("event:/FAIT/Lancement/Lancement_bille");
        rgBille = newBall.GetComponent<Rigidbody>();
        rgBille.AddRelativeForce(_launcher.transform.forward * _puissance, ForceMode.Impulse);
    }
}
		
