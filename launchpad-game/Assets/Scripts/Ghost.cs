using UnityEngine;

public class Ghost : MonoBehaviour
{
    public GameObject objectToSpawn;
    public GameObject buildEffect;
    Animator camAnim;

    void Start()
    {
        camAnim = Camera.main.GetComponent<Animator>();
    }

    void Update()
    {
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePos.z = 0;

        transform.position = mousePos;

        if (Input.GetMouseButtonDown(0))
        {
            Instantiate(buildEffect, transform.position, Quaternion.identity);
            camAnim.SetTrigger("shake");
            Instantiate(objectToSpawn, transform.position, Quaternion.identity);
            Destroy(gameObject);
        }
    }
}
