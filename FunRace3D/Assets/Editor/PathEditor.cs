using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(Path))]
public class PathEditor : Editor {
    public void OnSceneGUI(){
        Path path = target as Path;
        if(path == null || path.RawPoints == null || path.RawPoints.Count <= 1){
            return;
        }
        Vector3 offset = new Vector3(0, 1, 0);
        List<Vector3> raw = new List<Vector3>(), p = new List<Vector3>();
        for(int i = 0 ; i < path.RawPoints.Count; ++i){
            raw.Add(path.RawPoints[i].x*path.transform.right + path.RawPoints[i].y*path.transform.up + path.RawPoints[i].z*path.transform.forward + path.transform.position+offset);
        }
        Handles.color = Color.black;
        for(int i = 0; i < raw.Count-1; ++i){
            Handles.DrawLine(raw[i], raw[i+1], 3);
        }
        p = path.ComputeBezier(raw);
        Handles.color = Color.red;
        for(int i = 0; i < p.Count-1; ++i){
            Handles.DrawLine(p[i], p[i+1], 3);
        }

        // move handle
        for(int i = 0; i < raw.Count; ++i){
            EditorGUI.BeginChangeCheck();
            Vector3 newPosition = Handles.PositionHandle(raw[i], Quaternion.identity);
            if(EditorGUI.EndChangeCheck()){
                Undo.RecordObject(path, "Point n°" + i + " update");
                Vector3 res = newPosition-(path.transform.position+offset);
                path.RawPoints[i] = new Vector3(Vector3.Dot(res, path.transform.right), Vector3.Dot(res, path.transform.up), Vector3.Dot(res, path.transform.forward));
            }
        }
    }
}
