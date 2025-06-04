using UnityEngine;

public class ShopManager : MonoBehaviour
{
    public Ghost worker;
    public Ghost tree;
    public Ghost crystal;
    public Ghost village;
    public Ghost trap;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnShopClick(string item)
    {
        if (item == "worker")
        {
            Instantiate(worker);
        }
        else if (item == "tree")
        {
            Instantiate(tree);
        }
        else if (item == "crystal")
        {
            Instantiate(crystal);
        }
        else if (item == "village")
        {
            Instantiate(village);
        }
        else if (item == "trap")
        {
            Instantiate(trap);
        }
        else
        {
            print("Error while creating a ghost object!");
        }
    }
}
