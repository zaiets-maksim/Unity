using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class FollowPath : MonoBehaviour
{
    public enum MovementType{
        Moving,
        Lerping
    }
    public MovementType Type = MovementType.Moving;
    public MovementPath MyPath;
    public float speed = 1;
    public float MaxDistance = 0.1f;
    private IEnumerator<Transform> _pointInPath;
    Vector3 dir;
    float angle;
    // Start is called before the first frame update
    void Start()
    {
        if(MyPath == null){
        Debug.Log("!!!");
        return;}

        _pointInPath = MyPath.GetNextPathPoint();
		_pointInPath.MoveNext();

        if(_pointInPath.Current == null){
            return;
            Debug.Log("need a points");
        }
        //transform.position = _pointInPath.Current.position;
    }

    // Update is called once per frame
    void Update()
    {
        if(_pointInPath == null || _pointInPath.Current == null){
            return;
        }

        if(Type == MovementType.Moving){
        transform.position = Vector2.MoveTowards(transform.position, _pointInPath.Current.position, Time.deltaTime * speed );
        }
        else if(Type == MovementType.Lerping){
        transform.position = Vector2.Lerp(transform.position, _pointInPath.Current.position, Time.deltaTime * speed);
        }
        var distanceSquare = (transform.position - _pointInPath.Current.position).sqrMagnitude;
        
        if(distanceSquare < (MaxDistance * MaxDistance)){
            _pointInPath.MoveNext();
        }  
    }
        void OnTriggerEnter2D(Collider2D collider) {
	        if (collider.gameObject.CompareTag("star")){
            dir = _pointInPath.Current.position - transform.position;
            angle = Mathf.Atan2(dir.x, dir.y) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);  
		    }
        }
    
}

