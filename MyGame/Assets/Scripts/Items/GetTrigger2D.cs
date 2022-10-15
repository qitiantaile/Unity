using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetTrigger2D : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Destroy(gameObject);
    }
}
