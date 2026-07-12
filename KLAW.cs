using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

// Ryan Smith KLAW Player Script
public class KLAW : MonoBehaviour
{
    [Header("Instantiating Objects")]
    public GameObject[] objectArray;
    public GameObject instantiateTransform;
    private int objectNumber;

    [Header("Movement")]
    public float playerSpeed;

    [Header("Countdown Timer")]
    private float currentTime = 0f;
    public float startTime = 30f;
    public Text countdownUI;

    [Header("Arm Movement")]
    public Animator closeAnimation;

    //-----------------------------------Start is called once upon creation-------------------------
    private void Start()
    {
        // Starts Spawning Objects
        StartCoroutine(instantiateObject());

        // Sets To Max
        currentTime = startTime;
    }

    //-----------------------------------Update is called once per frame----------------------------
    private void Update()
    {
        Countdown();

        // Player Movement
        Vector3 pos = transform.position;

        if (Input.GetKey(KeyCode.LeftArrow) && pos.x > -6.58f) // Magic Numbers for Scene Boundaries
        {
            transform.position += Vector3.left * playerSpeed * Time.deltaTime;
        }

        if (Input.GetKey(KeyCode.RightArrow) && pos.x < 6.58f)
        {
            transform.position += Vector3.right * playerSpeed * Time.deltaTime;
        }

        if (Input.GetKey(KeyCode.UpArrow) && pos.y < 0.8f)
        {
            transform.position += Vector3.up * playerSpeed * Time.deltaTime;
        }

        if (Input.GetKey(KeyCode.DownArrow) && pos.y > -0.115f)
        {
            transform.position += Vector3.down * playerSpeed * Time.deltaTime;
        }

        if (Input.GetKey(KeyCode.Space))
        {
            closeAnimation.SetBool("Close", true); // Bool, Not Trigger So Holding Key Keeps Closed
        }

        else
        {
            closeAnimation.SetBool("Close", false);
        }
    }

    //-----------------------------------Object Spawner----------------------------
    private IEnumerator instantiateObject()
    {
        // Picks Random Object Through Correlating Index Number
        objectNumber = Random.Range(0, objectArray.Length);
        
        // Spawning Object/s At The Correct Location
        Instantiate(objectArray[objectNumber], instantiateTransform.transform.position, Quaternion.identity);
        
        // Prevents Loads Spawning At Once 
        yield return new WaitForSeconds(2f);

        StartCoroutine(instantiateObject());
    }

    //-----------------------------------Countdown----------------------------
    private void Countdown()
    {
        currentTime -= 1 * Time.deltaTime;
        countdownUI.text = Mathf.Floor(currentTime).ToString();

        // Restarts Game Once Time Runs Out
        if (currentTime < 0)
        {
            SceneManager.LoadScene(0);
        }
    }
}