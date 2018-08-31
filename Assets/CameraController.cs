using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public GameObject player;
    private Vector3 offset;
    private bool above;

    // Use this for initialization
    void Start()
    {
        // offset = transform.position - player.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetButton("Fire1"))
        {
            above = true;
            UpdateCameraPosition();
        }
    }

    public void OnPerspectiveButton()
    {
        above = !above;
        UpdateCameraPosition();
    }

    private void UpdateCameraPosition()
    {
        //transform.position = player.transform.position + offset;
        if (above)
        {
            transform.position = new Vector3(0f, 20f, 0f);
            transform.rotation = Quaternion.Euler(90f, 0f, 0f);

            //Quaternion quaternion = new Quaternion();
            //quaternion.Set(90f, 0f, 0f, 0f);
            //transform.rotation = quaternion;
        }
        else
        {
            transform.position = new Vector3(0f, 6f, -14f);
            transform.rotation = Quaternion.Euler(30f, 0f, 0f);

            //Quaternion quaternion = new Quaternion();
            //quaternion.Set(30f, 0f, 0f, 0f);
            //transform.rotation = quaternion;
        }
    }
}
