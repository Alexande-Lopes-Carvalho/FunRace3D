using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(KillOnSight))]
public class KillOnSightEditor : Editor {
    public void OnSceneGUI(){
        KillOnSight kSight = target as KillOnSight;
        Handles.color = Color.green;
        Vector3 t = kSight.transform.position+kSight.Offset;
        Handles.DrawDottedLine(t, t+Quaternion.AngleAxis(-kSight.AngleOfViewDegree, kSight.transform.up)*kSight.transform.forward*kSight.DistOfView, 1);
        Handles.DrawDottedLine(t, t+Quaternion.AngleAxis(kSight.AngleOfViewDegree, kSight.transform.up)*kSight.transform.forward*kSight.DistOfView, 1);
        Handles.DrawWireArc(t, kSight.transform.up, kSight.transform.forward, kSight.AngleOfViewDegree, kSight.DistOfView, 1);
        Handles.DrawWireArc(t, kSight.transform.up, kSight.transform.forward, -kSight.AngleOfViewDegree, kSight.DistOfView, 1);
    }
}
