using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MobilePlatform : MonoBehaviour
{
    public GameObject mobilePlat;
    public GameObject door;
    private bool activated;
    public float platSpeedUp;
    public float platSpeedDown;
    public float doorSpeedUp;
    public float doorSpeedDown;
    private bool releaseDoor;
    public static bool stoneOnPlat;

    void Update()
    {
        if(activated)
        {
            float posYPlat = mobilePlat.transform.position.y;
            
            if(posYPlat <= 0.4f && posYPlat >= 0.3f)
                mobilePlat.transform.Translate(0, platSpeedDown * Time.deltaTime, 0);
            
            if(posYPlat <= 0.3f)
                releaseDoor = true;
        }
        else
        {
            releaseDoor = false;
            float posYPlat = mobilePlat.transform.position.y;

            if(posYPlat >= 0.26f && posYPlat <= 0.39f)
                mobilePlat.transform.Translate(0, platSpeedUp * Time.deltaTime, 0);
        }

        if(releaseDoor)
        {
            float posYdoor = door.transform.position.y;
            if(posYdoor >= 2.95f && posYdoor <= 6f)
                door.transform.Translate(0, doorSpeedUp * Time.deltaTime, 0);
        }
        else
        {
            float posYdoor = door.transform.position.y;
            if(posYdoor <= 6.2f && posYdoor >= 3f)
                door.transform.Translate(0, doorSpeedDown * Time.deltaTime, 0);
        }

    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("mario") && stoneOnPlat == false)
            activated = true;

        if(other.gameObject.CompareTag("stone"))
        {
            activated = true;
            stoneOnPlat = true;
        }
    }

    private void OnTriggerExit(Collider other )
    {
        if(other.gameObject.CompareTag("mario") && stoneOnPlat == false)
            activated = false;

        if(other.gameObject.CompareTag("stone"))
        {
            activated = false;
            stoneOnPlat = false;
        }
    }

}
