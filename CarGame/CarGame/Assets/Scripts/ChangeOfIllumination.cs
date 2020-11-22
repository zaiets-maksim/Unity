using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeOfIllumination : MonoBehaviour {
public Light MainLight;

public Light Headlights;
public Light HeadlightR;
public Light HeadlightL;
	// Use this for initialization
	void Start () {
		Headlights.intensity = 0f;
		HeadlightR.intensity = 0f;
		HeadlightL.intensity = 0f;
		StartCoroutine("SlowScale");
	}

IEnumerator SlowScale()
{
	link:
   for (MainLight.intensity = 1.01f; MainLight.intensity > -0.1f; MainLight.intensity -= .01f)
   {
      transform.localScale = new Vector3(MainLight.intensity, MainLight.intensity, MainLight.intensity);
      yield return new WaitForSeconds(.5f);

		if(MainLight.intensity < 0.3f){
		Headlights.intensity = 0.25f;
		HeadlightR.intensity = 0.6f;
		HeadlightL.intensity = 0.6f;
	  }
	if(MainLight.intensity <= 0f)
		break;
   }
   yield return new WaitForSeconds(45f);

     for (MainLight.intensity = 0f; MainLight.intensity < 1.011f; MainLight.intensity += .01f)
   {
      transform.localScale = new Vector3(MainLight.intensity, MainLight.intensity, MainLight.intensity);
      yield return new WaitForSeconds(.5f);

	  if(MainLight.intensity > 0.3f){
		Headlights.intensity = 0f;
		HeadlightR.intensity = 0f;
		HeadlightL.intensity = 0f;
	  }

	  if(MainLight.intensity > 1.02f)
		break;
   }
   yield return new WaitForSeconds(45f);
   goto link;
}
}
