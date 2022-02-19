using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level : MonoBehaviour, IPointProvider {
    [SerializeField] private PathFollower character;
    [SerializeField] private List<GameObject> levelComponentsPrefab;
    [SerializeField] private Transform levelComponentTransform;
    private Queue<LevelComponent> levelComponents;

    // Start is called before the first frame update
    void Awake() {
        levelComponents = new Queue<LevelComponent>();
        Vector3 spawn = transform.position;
        foreach(GameObject k in levelComponentsPrefab){
            GameObject g = Instantiate(k);
            LevelComponent l = g.GetComponent<LevelComponent>();
            g.transform.position = spawn-l.GetStart();
            g.transform.parent = levelComponentTransform;
            l.RefreshPath();
            levelComponents.Enqueue(l);
            spawn = g.transform.position+(l.GetEnd()-l.GetStart());
        }
        character.transform.position = transform.position;
        character.Provider = this;
    }

    // Update is called once per frame
    void Update() {
        
    }

    public Vector3 GetNextPoint(){
        if(levelComponents.Count == 0){
            character.enabled = false;
            return character.transform.position;
        }
        if(!levelComponents.Peek().HasNextPoint()){
            levelComponents.Dequeue();
            return GetNextPoint();
        }
        return levelComponents.Peek().GetNextPoint();
    }
}
