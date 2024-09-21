using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ShipBehaviour : MonoBehaviour
{
    private Rigidbody _rigid;
    public float thrustforce = 100f;
    public float rotationspeed = 120f;

    public GameObject gun,bulletprefab;

    public static int SCORE = 0;

    public static float xBorderLimit = 9f;
    public static float yBorderLimit = 5f;

    // Start is called before the first frame update
    void Start()
    {
        _rigid = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        var NewPos = transform.position;

        if (NewPos.x > xBorderLimit)
            NewPos.x = -xBorderLimit + 1;
        else if(NewPos.x < -xBorderLimit)
            NewPos.x = xBorderLimit - 1;
        else if (NewPos.y > yBorderLimit+1)
            NewPos.y = -yBorderLimit + 1;
        else if (NewPos.y < -(yBorderLimit-1))
            NewPos.y = yBorderLimit +1;

        transform.position = NewPos;

        float thrust = Input.GetAxis("Thrust") * Time.deltaTime;
        Vector3 thrustDirection = transform.right;
        _rigid.AddForce(thrustDirection * thrust * thrustforce);

        float rotation = Input.GetAxis("Rotate") * Time.deltaTime;
        transform.Rotate(Vector3.back, rotation * rotationspeed);


        if (Input.GetKeyDown(KeyCode.Space))
        {
            GameObject bullet = Instantiate(bulletprefab,gun.transform.position,Quaternion.identity);

            BulletMovement balascript = bullet.GetComponent<BulletMovement>();

            balascript.targetVector = transform.right;
        }
    }




    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Enemy"|| collision.gameObject.tag == "Enemy2")
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
        else
        {
            Debug.Log("Hemos colisionado con otra cosa");
        }
    }
}
