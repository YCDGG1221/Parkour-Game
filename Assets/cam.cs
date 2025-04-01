using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cam : MonoBehaviour
{
    public float player_sensitive = 100f;
   
    public Transform player;
  
    float xRotation = 0f;

    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
       
    }

    // Update is called once per frame
    void Update()
    {
        float mouseX = Input.GetAxis("Mouse X") * player_sensitive * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * player_sensitive * Time.deltaTime;

        xRotation -= mouseY;
        
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);
       

        transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
     
        player.Rotate(Vector3.up * mouseX);
      
    }
}