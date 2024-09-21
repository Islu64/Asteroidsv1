using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class BulletMovement : MonoBehaviour
{

    public GameObject asteroidprefab;
    public float maxmetlimit = 4f;
    public float speed = 10f;
    public float maxlifetime = 3f;
    public Vector3 targetVector;
    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject,maxlifetime);
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(speed * targetVector * Time.deltaTime);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            IncreaseScore();

            Vector2 spawnposition1 = new Vector2(collision.gameObject.transform.position.x-1, gameObject.transform.position.y);
            Vector2 spawnposition2 = new Vector2(collision.gameObject.transform.position.x+1, gameObject.transform.position.y);
            GameObject meteor1 = Instantiate(asteroidprefab, spawnposition1, Quaternion.identity);
            Destroy(meteor1, maxmetlimit);
            GameObject meteor2 = Instantiate(asteroidprefab, spawnposition2, Quaternion.identity);
            Destroy(meteor2, maxmetlimit);

            Destroy(collision.gameObject);
            Destroy(gameObject);
        }
        else if (collision.gameObject.tag == "Enemy2")
        {
            IncreaseScore();
            Destroy(collision.gameObject);
            Destroy(gameObject);
        }
        else
        {
            Debug.Log("Hemos disparado a otra cosa");
        }
    }

    private void IncreaseScore()
    {
        ShipBehaviour.SCORE++;
        Debug.Log("Funciona");
        UpdateScoreText();
    }

    private void UpdateScoreText()
    {
        GameObject go = GameObject.FindGameObjectWithTag("UI");
        go.GetComponent<Text>().text ="Puntos=" + ShipBehaviour.SCORE;
    }
}
