using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoopPath : MonoBehaviour, IPointProvider {
    [SerializeField] private Path path;
    private PathFollower follower;
    private int index;
    // Start is called before the first frame update
    private void Start() {
        follower = gameObject.GetComponent<PathFollower>();
        follower.Provider = this;
        index = 0;
    }

    // Update is called once per frame
    private void Update() {
        
    }

    public Vector3 GetNextPoint(){
        index = (index+1)%path.Points.Count;
        return path.Points[index];
    }
}
