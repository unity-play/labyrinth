using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
// using UnityEditor;

public class PlayerController : MonoBehaviour
{
    public int levelsCount = 3;

    private bool optionalObjectsVisible;
    private GameObject[] optionalObjects;

    void Start()
    {
        optionalObjectsVisible = true;
        optionalObjects = GameObject.FindGameObjectsWithTag("Optional");

        optionalObjects = new GameObject[] {
            GameObject.Find("Tree1"),
            GameObject.Find("Tree2"),
            GameObject.Find("Tree3"),
            GameObject.Find("Flower1"),
            GameObject.Find("Flower2"),
            GameObject.Find("Flower3"),
            GameObject.Find("Flower4"),
            GameObject.Find("Flower5"),
            GameObject.Find("Flower6")
        };
    }

    void Update()
    {
        float velocity = 4.0f;
        if (Input.GetButton("Jump"))
        {
            velocity = 6 * velocity;
        }

        float x = velocity * Input.GetAxis("Horizontal");
        float y = 0;
        float z = velocity * Input.GetAxis("Vertical");
        transform.Translate(x * Time.deltaTime, y * Time.deltaTime, z * Time.deltaTime);
    }

    private void OnCollisionEnter(Collision collision)
    {
        switch(collision.gameObject.name)
        {
            case "Exit":
                int index = SceneManager.GetActiveScene().buildIndex + 1;
                SceneManager.LoadSceneAsync(index % levelsCount);
                break;

            case "Floor":
                break;

            default:
                // Destroy(collision.gameObject);
                SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().buildIndex);
                break;
        }
    }

    public void OnDecorationButton()
    {
        // EditorUtility.DisplayDialog("Test", "Are you sure you want to place?", "OK");
        optionalObjectsVisible = !optionalObjectsVisible;
        foreach (GameObject optionalObject in optionalObjects)
        {
            optionalObject.SetActive(optionalObjectsVisible);
        }
    }
}
