using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMove : MonoBehaviour
{
    PlayerController player;

    private float speed;
    
    public float minX,maxX;
    public float minY, maxY;
    public float yOffset;


    void Start()
    {

        player = GameObject.FindObjectOfType<PlayerController>();
    }

    void Update()
    {
        //Cameranin hareketini x ve y duzleminde belli bir alana kisitlar
        transform.position = new Vector3
        (
             Mathf.Clamp(player.transform.position.x, minX, maxX),
             Mathf.Clamp(player.transform.position.y+yOffset, minY, maxY),
             transform.position.z
        );



    }



}

