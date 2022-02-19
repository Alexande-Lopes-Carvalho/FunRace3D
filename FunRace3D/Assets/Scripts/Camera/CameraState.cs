using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraState : MonoBehaviour {
    public virtual Quaternion Rotation(Transform player){
        return transform.rotation;
    }
    public virtual Vector3 Position(Transform player){
        return transform.position;
    }
}

