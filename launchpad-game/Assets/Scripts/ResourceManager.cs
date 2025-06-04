using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class ResourceManager : MonoBehaviour
{
    [Header("Current Stored Resources")]
    public int wood;
    public int crystal;
    public int blood;
    public int sacrificedWorkerAmount;

    [Header("Text Reference of Stored Resources")]
    public TMP_Text woodDisplay;
    public TMP_Text crystalDisplay;
    public TMP_Text bloodDisplay;
    public TMP_Text bloodAltarText;

    [Header("Reference to Level Cleared Screen")]
    public GameObject levelClearScreen;
    [Header("Reference to Animator of Main Canvas")]
    public Animator mainCanvas;

    int sacrificeGoal;


    public static ResourceManager instance;

    private void Awake()
    {
        instance = this;
    }

    void Start()
    {
        sacrificeGoal = LevelManager.sacrificeCount;
        bloodAltarText.text = sacrificedWorkerAmount + " / " + sacrificeGoal;
    }

    void Update()
    {
        
    }

    public void StoreResource(string type, int amount)
    {
        if (type == "wood")
        {
            wood += amount;
            woodDisplay.text = wood.ToString();
        }
        else if (type == "crystal")
        {
            crystal += amount;
            crystalDisplay.text = crystal.ToString();
        }
        else if (type == "blood")
        {
            blood += amount;
            bloodDisplay.text = blood.ToString();
        }
        else
        {
            print("unknown resource");
        }  
    }

    public void SacrificeWorker() 
    {
        sacrificedWorkerAmount++;
        bloodAltarText.text = sacrificedWorkerAmount + " / " + sacrificeGoal;

        if (sacrificedWorkerAmount >= sacrificeGoal) 
        {
            GameObject.FindGameObjectWithTag("Altar").gameObject.GetComponent<BoxCollider2D>().enabled = false;
            mainCanvas.SetTrigger("levelCleared");
            print(LevelManager.level);
            if (LevelManager.level + 1 < LevelManager.maxLevel)
            {
                print(LevelManager.level + 1);
                print(LevelManager.maxLevel);
                Instantiate(levelClearScreen);
            }
            else
            {
                SceneManager.LoadScene("GameEnding");
            }
        }
    }
}
