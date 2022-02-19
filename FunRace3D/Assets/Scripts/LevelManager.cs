using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour {
    private static LevelManager instance;
    public static LevelManager Instance{get => instance;}
    [SerializeField] private GameObject level1, level2;
    private Dictionary<string, GameObject> levelList;
    [SerializeField] private Transform levelTransform;
    [SerializeField] Camera camera;

    private List<Character> players;
    public List<Character> Players{get => players;}
    // Start is called before the first frame update
    void Start() {
        if(instance != null){
            Destroy(instance.gameObject);
        }
        instance = this;
        levelList = new Dictionary<string, GameObject>();
        levelList.Add("Level_1", level1);
        players = new List<Character>();
        LaunchLevel("Level_1");
    }

    // Update is called once per frame
    void Update() {
        
    }

    public void LaunchLevel(string name){
        GameObject level = Instantiate(levelList[name]);
        Level l = level.GetComponent<Level>();
        l.Cam = camera;
        level.transform.parent = levelTransform;
    }

    public void LaunchMenu(){
        
    }

    public void EndLevel(bool hasWon){
        Time.timeScale = 0;
        LaunchMenu();
    }

    public void Register(Character c){
        players.Add(c);
    }
    public void Remove(Character c){
        players.Remove(c);
    }
}
