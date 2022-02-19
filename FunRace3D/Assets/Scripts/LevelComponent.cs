using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelComponent : MonoBehaviour {
    [SerializeField] private Path path;
    [SerializeField] private CameraState cameraState;
    private int index;
    private void Awake(){
        index = 0;
    }
    public Vector3 GetStart(){
        return path.Points[0];
    }
    public Vector3 GetEnd(){
        return path.Points[path.Points.Count-1];
    }
    public bool HasNextPoint(){
        return index < path.Points.Count;
    }
    public Vector3 GetNextPoint(){
        return path.Points[index++];
    }

    public Vector3 GetCameraPosition(Transform player){
        return cameraState.Position(player);
    }
    public Quaternion GetCameraRotation(Transform player){
        return cameraState.Rotation(player);
    }
}
