using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementPath : MonoBehaviour
{
public enum PathTypes{
    linear, loop
}
public PathTypes PathType; 
public int movementDirection = 1;
public int movingTo = 0;
public Transform[] PathElements;
public GameObject Rocket;


int _lenght;
void Start(){
_lenght = PathElements.Length;
}
public void OnDrawGizmos(){
    if(PathElements == null || PathElements.Length < 2)
    return;

        for (int i = 1; i < _lenght; i++){
    Gizmos.DrawLine(PathElements[i - 1].position, PathElements[i].position);}

    if(PathType == PathTypes.loop)
    Gizmos.DrawLine(PathElements[0].position, PathElements[PathElements.Length - 1].position);
}

public IEnumerator<Transform>GetNextPathPoint(){
    if(PathElements == null || PathElements.Length < 1)
    yield break;

    while(true){
    yield return PathElements[movingTo];

    if(PathElements.Length == 1)
    continue;

        if(PathType == PathTypes.linear){

        if(movingTo <= 0){
        movementDirection = 1;}
        }

        if(movingTo == PathElements.Length)
        movementDirection = 0;
    
        //movingTo = movingTo + movementDirection;

        /*if(PathType == PathTypes.loop){
        if(movingTo >= PathElements.Length)
        movingTo = 0;

        if(movingTo < 0)
        movingTo = PathElements.Length - 1;
        }*/
    }
}

	void LateUpdate(){
		if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began && PauseScript.check == 1){
			Debug.Log("Touch");
			movingTo = movingTo + movementDirection;

          
    //if(Rocket.transform.position == PathElements[movingTo - 1].transform.position){
         //var dir = PathElements[movingTo].position - Rocket.transform.position;
        //var angle = Mathf.Atan2(dir.x, dir.y) * Mathf.Rad2Deg;
        //Rocket.transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
    //}
            //Destroy (PathElements[movingTo - 1].gameObject);

            //PathElements[movingTo - 1].gameObject.SetActive(false);

            //_lenght--;

            
		}
   
    }

}
