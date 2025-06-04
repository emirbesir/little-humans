using UnityEngine;

public class Resource : MonoBehaviour
{
    public int resourceAmount;
    public string resourceType;
    
    void Start()
    {
        
    }

    void Update()
    {
        if (resourceAmount <= 0)
        {
            Destroy(gameObject);
        }
    }
}
