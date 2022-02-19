using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour {
    [SerializeField] private PathFollower pathFollower;
    [SerializeField] private float speed;
    private Animator animator;
    private Vector3 lastPosition;
    private static readonly int forwardSpeedAnimation = Animator.StringToHash("forwardSpeed");
    private float maxSpeedAnimation = 3.5f;

    private FCloserTo closerTo;
    private float transitionSpeed = 1075f;
    private bool position;
    // Start is called before the first frame update
    private void Awake() {
        animator = GetComponent<Animator>();
        lastPosition = transform.position;
        position = false;
        closerTo = new FCloserTo(transitionSpeed, 0, 0);
    }

    private void FixedUpdate(){
        RefreshMoveAnimation();
    }

    // Update is called once per frame
    private void Update() {
        bool newPosition = Input.GetMouseButton(0) || Input.GetKey(KeyCode.Space);
        if(newPosition^position){
            position = newPosition;
            closerTo = new FCloserTo(transitionSpeed, (position)? speed : -pathFollower.Speed, pathFollower.Speed/speed);
        }
        pathFollower.Speed = closerTo.GetValue(Time.deltaTime*1000.0f);
        //Debug.Log(pathFollower.Speed);
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
