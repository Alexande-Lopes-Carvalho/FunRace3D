using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IPointProvider{
    Vector3 GetNextPoint();
}

public class PathFollower : MonoBehaviour {
    [SerializeField] private IPointProvider provider;
    public IPointProvider Provider{get => provider; set => provider = value;}
    private Vector3 currentPoint;
    private float speed = 1;
    public float Speed{get => speed; set => speed = value;}
    private float tolerance = 0.001f;
    // Start is called before the first frame update
    private void Start() {
        currentPoint = transform.position;
    }

    // Update is called once per frame
    private void FixedUpdate() {
        Move(speed*Time.deltaTime);
    }

    private void Move(float distToMove){
        //Debug.Log(distToMove + " " + currentPoint);
        while(distToMove > tolerance){
            Vector3 v = currentPoint-transform.position;
            if(v.magnitude < tolerance){
                Vector3 oldPoint = currentPoint;
                currentPoint = provider.GetNextPoint();
                if(oldPoint == currentPoint){
                    return;
                }
                continue;
            }
            float maxDist = Mathf.Min(v.magnitude, distToMove);
            transform.LookAt(transform.position+v.normalized*maxDist);
            transform.position += v.normalized*maxDist;
            
            distToMove -= maxDist;
        }
    }
}
