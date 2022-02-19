using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class LevelManager : MonoBehaviour {
    private static LevelManager instance;
    public static LevelManager Instance{get => instance;}
    [SerializeField] private GameObject level1, level2, levelProc;
    private Dictionary<string, GameObject> levelList;
    [SerializeField] private Transform levelTransform;
    [SerializeField] private Camera camera;

    private List<Character> players;
    public List<Character> Players{get => players;}
    [SerializeField] private float timeToReturnToMenu = 5.0f;
    private IEnumerator returnToMenu;
    [SerializeField] private Transform menu;
    [SerializeField] private Transform endLevel;
    [SerializeField] private TextMeshProUGUI endLevelText;
    // Start is called before the first frame update
    void Start() {
        if(instance != null){
            Destroy(instance.gameObject);
        }
        instance = this;
        levelList = new Dictionary<string, GameObject>();
        levelList.Add("Level_1", level1);
        levelList.Add("Level_2", level2);
        levelList.Add("Level_Procedural", levelProc);
        players = new List<Character>();
        LaunchMenu();
    }

    // Update is called once per frame
    void Update() {
        
    }

    public void LaunchLevel(string name){
        Debug.Log(name);
        GameObject level = Instantiate(levelList[name]);
        Level l = level.GetComponent<Level>();
        l.Cam = camera;
        level.transform.parent = levelTransform;
        Time.timeScale = 1;
        menu.gameObject.SetActive(false);
        endLevel.gameObject.SetActive(false);
    }

    public void LaunchMenu(){
        foreach(Transform k in levelTransform){
            Destroy(k.gameObject);
        }
        endLevel.gameObject.SetActive(false);
        menu.gameObject.SetActive(true);
        camera.transform.position = new Vector3(0, 0, 0);
        camera.transform.eulerAngles = new Vector3(0, 0, 0);
    }

    private IEnumerator ReturnToMenuCoroutine(float timeToLaunchMenu){
        yield return new WaitForSecondsRealtime(timeToLaunchMenu);
        LaunchMenu();
        returnToMenu = null;
    }

    public void EndLevel(bool hasWon){
        if(returnToMenu == null){
            endLevel.gameObject.SetActive(true);
            endLevelText.SetText((hasWon)? "You Won": "You Lost");
            Time.timeScale = 0;
            returnToMenu = ReturnToMenuCoroutine(timeToReturnToMenu);
            StartCoroutine(returnToMenu);
        }
    }

    public void Register(Character c){
        players.Add(c);
    }
    public void Remove(Character c){
        players.Remove(c);
    }
}
