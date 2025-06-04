using UnityEngine;
using UnityEngine.UI;

public class ShopButton : MonoBehaviour
{
    public int bloodCost;
    public int woodCost;
    public int crystalCost;

    Button button;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        button = GetComponent<Button>();
    }

    // Update is called once per frame
    void Update()
    {
        if (ResourceManager.instance.blood < bloodCost || ResourceManager.instance.wood < woodCost || ResourceManager.instance.crystal < crystalCost)
        {
            button.interactable = false;
        }
        else 
        { 
            button.interactable = true; 
        }
    }
    public void RemoveResources()
    {
        ResourceManager.instance.StoreResource("blood", -bloodCost);
        ResourceManager.instance.StoreResource("wood", -woodCost);
        ResourceManager.instance.StoreResource("crystal", -crystalCost);
    }
}
