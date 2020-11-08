using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GameMgr : MonoBehaviour 
{

	void Start () 
	{
		FMODUnity.RuntimeManager.PlayOneShot("event:/FAIT/Environnement/Ambiance/Musique niveau 1");
	}

	public IEnumerator Shake(GameObject _camera, float _duration, float _magnitude) 
	{
        Vector3 originalPos = _camera.transform.localPosition;

        float elapsed = 0.0f;

        while (elapsed < _duration)
        {
            float x = Random.Range(-1f, 1f) * _magnitude;
            float y = Random.Range(-1f, 1f) * _magnitude;

            _camera.transform.localPosition = new Vector3(x, y, originalPos.z);

            elapsed += Time.deltaTime;

            yield return null;
        }

        _camera.transform.localPosition = originalPos; // On regagne la position initial de la camera
	}
}
