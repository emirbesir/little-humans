using UnityEngine;
using UnityEngine.SceneManagement;

public class Enemy : MonoBehaviour
{
    public float speed;

    public float minX, minY, maxX, maxY;

    Vector3 currentTarget;

    public GameObject blood;
    public GameObject bloodParticle;

    Animator camAnim;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        currentTarget = generateRandomPosition();
        camAnim = Camera.main.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Vector3.Distance(transform.position, currentTarget) > 0.5f)
        {
            transform.position = Vector3.MoveTowards(transform.position, currentTarget, speed * Time.deltaTime);
        }
        else
        {
            currentTarget = generateRandomPosition();
        }
        
    }

    Vector3 generateRandomPosition()
    {
        return new Vector3(Random.Range(minX,maxX), Random.Range(minY, maxY), 0);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Altar")
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
        if (collision.tag == "Trap")
        {
            camAnim.SetTrigger("shake");
            Destroy(collision.gameObject);

            Instantiate(bloodParticle, transform.position, Quaternion.identity);
            Instantiate(blood, transform.position, Quaternion.identity);

            EnemyManager.instance.enemyAmount--;
            Destroy(gameObject);
        }
        if (collision.tag == "Human")
        {
            Instantiate(bloodParticle, transform.position, Quaternion.identity);
            Instantiate(blood, collision.gameObject.transform.position, Quaternion.identity);
            Destroy(collision.gameObject);
        }
    }
}
