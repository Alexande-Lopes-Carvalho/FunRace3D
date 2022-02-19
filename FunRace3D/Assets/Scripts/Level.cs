using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level : MonoBehaviour, IPointProvider {
    [SerializeField] protected PathFollower character;
    [SerializeField] protected List<GameObject> levelComponentsPrefab;
    [SerializeField] protected Transform levelComponentTransform;
    private Camera cam;
    public Camera Cam{get => cam; set => cam = value;}
    protected Queue<LevelComponent> levelComponents;

    protected FCloserTo closerTo;
    private Vector3 oldCamPos;
    private Quaternion oldCamRot;

    [SerializeField] private GameObject start;
    [SerializeField] private GameObject end;
    [SerializeField] private bool shuffle = false;
    [SerializeField] private int countShuffle = 5;

    // Start is called before the first frame update
    public virtual void Awake() {
        levelComponents = new Queue<LevelComponent>();
        Vector3 spawn = transform.position;
        spawn = SpawnLevelComponent(start, spawn);
        if(shuffle){
            for(int i = 0; i < countShuffle; ++i){
                int f = (int)Random.Range(0, 100f);
                GameObject k = levelComponentsPrefab[f%levelComponentsPrefab.Count];
                spawn = SpawnLevelComponent(k, spawn);
            }
        } else {
            foreach(GameObject k in levelComponentsPrefab){

                spawn = SpawnLevelComponent(k, spawn);
            }
        }
        spawn = SpawnLevelComponent(end, spawn);
        character.transform.position = transform.position;
        character.Provider = this;
        closerTo = new FCloserTo(0, 1, 0);
    }

    // Update is called once per frame
    void Update() {
        if(levelComponents.Count != 0){
            Vector3 p = levelComponents.Peek().GetCameraPosition(character.transform);
            Quaternion q = levelComponents.Peek().GetCameraRotation(character.transform);
            float value = closerTo.GetValue(Time.deltaTime*1000.0f);
            cam.transform.position = Vector3.Slerp(oldCamPos, p, value);
            cam.transform.rotation = Quaternion.Slerp(oldCamRot, q, value);
        }
    }

    public Vector3 GetNextPoint(){
        if(levelComponents.Count == 0){
            character.enabled = false;
            LevelManager.Instance.EndLevel(true);
            return character.transform.position;
        }
        if(!levelComponents.Peek().HasNextPoint()){
            Debug.Log("new  : ");
            LevelComponent l = levelComponents.Dequeue();
            if(levelComponents.Count != 0 && l.GetCameraPosition(character.transform) != levelComponents.Peek().GetCameraPosition(character.transform)){
                oldCamPos = cam.transform.position;
                oldCamRot = cam.transform.rotation;
                closerTo = new FCloserTo(1500, 1, 0);
            }
            return GetNextPoint();
        }
        return levelComponents.Peek().GetNextPoint();
    }

    protected Vector3 SpawnLevelComponent(GameObject k, Vector3 spawn){
        GameObject g = Instantiate(k);
        LevelComponent l = g.GetComponent<LevelComponent>();
        g.transform.position = spawn-l.GetStart();
        g.transform.parent = levelComponentTransform;
        levelComponents.Enqueue(l);
        return g.transform.position+(l.GetEnd()-l.GetStart());
    }
}
