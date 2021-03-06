using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Guard : MonoBehaviour{
    [SerializeField] private PathFollower pathFollower;
    [SerializeField] private float speed;
    private Animator animator;
    private Vector3 lastPosition;
    private static readonly int forwardSpeedAnimation = Animator.StringToHash("forwardSpeed");
    private float maxSpeedAnimation = 3.5f;    
    private void Start(){
        animator = GetComponent<Animator>();
        lastPosition = transform.position;
        GetComponent<PathFollower>().Speed = speed;
    }

    private void FixedUpdate(){
        RefreshMoveAnimation();
    }

    // Update is called once per frame
    private void Update(){
        
    }

    private void RefreshMoveAnimation(){
        if(Time.deltaTime == 0){
            return;
        }
        Vector3 move = (transform.position-lastPosition)/Time.deltaTime;
        animator.SetFloat(forwardSpeedAnimation, Mathf.Min(move.magnitude/maxSpeedAnimation, 1.0f));
        lastPosition = transform.position;
    }
}
