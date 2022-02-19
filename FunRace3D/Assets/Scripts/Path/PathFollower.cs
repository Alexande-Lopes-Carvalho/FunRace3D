using System.Collections;
using System.Collections.Generic;
using UnityEngine;

interface IPointProvider{
    Vector3 GetNextPoint();
}

public class PathFollower : MonoBehaviour {
    [SerializeField] private IPointProvider provider;
    private Vector3 currentPoint;
    private float speed = 1;
    public float Speed{get => speed; set => speed = value;}
    private float tolerance = 0.001f;
    // Start is called before the first frame update
    private void Start() {
        currentPoint = provider.GetNextPoint();
    }

    // Update is called once per frame
    private void FixedUpdate() {
        Move(speed*Time.deltaTime);
    }

    private void Move(float distToMove){
        while(distToMove > tolerance){
            if(currentPoint == null){
                return;
            }
            Vector3 v = currentPoint-transform.position;
            if(v.magnitude < tolerance){
                currentPoint = provider.GetNextPoint();
                continue;
            }
            float maxDist = Mathf.Min(v.magnitude, distToMove);
            transform.position = v.normalized*maxDist;
            distToMove -= maxDist;
        }
    }
}