using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButScript : MonoBehaviour
{
    public GameObject launcher;
    public float timerWaitANewBall;
    LancementBalle lancementBalle;

    private void Start()
    {
        lancementBalle = launcher.GetComponent<LancementBalle>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Ball"))
        {
            Destroy(other.gameObject);
            StartCoroutine(WaitForANewBall(timerWaitANewBall));
        }
    }

    public IEnumerator WaitForANewBall(float _timer)
    {
        yield return new WaitForSeconds(_timer);

        lancementBalle.newball(lancementBalle.bille, lancementBalle.launcher, lancementBalle.puissance);
    }
}
