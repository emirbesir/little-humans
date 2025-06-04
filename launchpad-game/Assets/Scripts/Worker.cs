using System.Resources;
using Unity.VisualScripting;
using UnityEngine;

public class Worker : MonoBehaviour
{
    bool isSelected;

    public float collectDistance;
    public float timeBetweenCollects;
    public int amountToCollect;
    public LayerMask resourceLayer;
    public float distanceToSacrifice;

    float nextCollectTime;
    Resource currentResource;
    GameObject bloodAltar;

    public GameObject popUp;
    Animator camAnim;
    AudioSource altarAudio;
    AudioSource workerAudio;

    void Start()
    {
        bloodAltar = GameObject.FindGameObjectWithTag("Altar");
        camAnim = Camera.main.GetComponent<Animator>();
        altarAudio = bloodAltar.GetComponent<AudioSource>();
        workerAudio = GetComponent<AudioSource>();
    }

    void Update()
    {
        if (isSelected)
        {
            MoveWorker();
        }
        else 
        {
            if(Vector3.Distance(transform.position, bloodAltar.transform.position) < distanceToSacrifice)
            {
                altarAudio.Play();
                camAnim.SetTrigger("shake");
                Destroy(gameObject);
                ResourceManager.instance.SacrificeWorker();
            }
            else
            {
                CollectResource();
            }
        }
    }

    private void MoveWorker()
    {
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePos.z = 0;
        transform.position = mousePos;
    }

    private void CollectResource()
    {
        Collider2D col = Physics2D.OverlapCircle(transform.position, collectDistance, resourceLayer);
        if (col != null && currentResource == null)
        {
            currentResource = col.GetComponent<Resource>();
        }
        else
        {
            currentResource = null;
        }

        if (currentResource != null)
        {
            if (Time.time > nextCollectTime)
            {
                Instantiate(popUp, transform.position, Quaternion.identity);
                nextCollectTime = Time.time + timeBetweenCollects;
                currentResource.resourceAmount -= amountToCollect;
                ResourceManager.instance.StoreResource(currentResource.resourceType, amountToCollect);
            }
        }
    }


    private void OnMouseDown()
    {
        isSelected = true;
    }

    private void OnMouseUp()
    {
        isSelected = false;
        workerAudio.Play();
    }
}
