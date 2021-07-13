using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class Player : MonoBehaviour
{
   [Header("General")]
   [Tooltip("in m/s")][SerializeField] float Speed = 4f;
   [Tooltip("in m")][SerializeField] float xRange = 5f; 
   [Tooltip("in m")][SerializeField] float yRange = 5f;

   [Header("Parameters")]
   [SerializeField] float posPitchFactor = -5f; 
   [SerializeField] float posYawFactor = -5f; 
    [SerializeField] float ConRollFactor = -20f; 
   [SerializeField] float ConPitchFactor = -20f; 
   float xThrow,yThrow;
   bool IsControledEnabled = true;

   void PlayerDeath()
   {
       IsControledEnabled = false;
   }


   
    void Update()
    { 
          if(IsControledEnabled == true)
          {
            ProcessingTranslate();
            ProcessingRotation();
          }
    }

    public void ProcessingTranslate()
    {
        xThrow = CrossPlatformInputManager.GetAxis("Horizontal");
        float xOffset = xThrow * Speed * Time.deltaTime;
        float rawXpos= xOffset + transform.localPosition.x;
        float xClampedpos=Mathf.Clamp(rawXpos,-xRange,xRange);

        //transform.localPosition = new Vector3(xClampedpos,transform.localPosition.y,transform.localPosition.z);

        yThrow = CrossPlatformInputManager.GetAxis("Vertical");
        float yOffset = yThrow * Speed * Time.deltaTime;
        float rawYpos= yOffset + transform.localPosition.y;
        float yClampedpos=Mathf.Clamp(rawYpos,-yRange,yRange);

        transform.localPosition = new Vector3(xClampedpos,yClampedpos,transform.localPosition.z);
    }

    public void ProcessingRotation()
    {
        float pitch=transform.localPosition.y * posPitchFactor + yThrow * ConPitchFactor ;
        float yaw=transform.localPosition.x * posYawFactor;
        float roll=yThrow * ConRollFactor;
        transform.localRotation=Quaternion.Euler(pitch,yaw,roll);
    }
}  