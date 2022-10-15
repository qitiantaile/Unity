using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundSensor : MonoBehaviour
{
    [SerializeField] int Count = 0;
    float DisableTimer;
    private void OnEnable()
    {
        Count = 0;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("·¢ÉúÅö×²");
        Count++;
    }


    private void OnTriggerExit2D(Collider2D collision)
    {
        Count--;
    }


    public bool IsGrounded 
    {
        get
        {
            if (DisableTimer > 0)
                return false;
            return Count > 0;
        }
    }
    // Update is called once per frame
    void Update()
    {
        DisableTimer -= Time.deltaTime;
    }
    public void Disable(float duration)
    {
        DisableTimer = duration;
    }
}
