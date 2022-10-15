using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VictoryGem : MonoBehaviour
{
    [SerializeField] VoidEventChannel levelClearedEventChannel;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        levelClearedEventChannel.Broadcast();
        Destroy(gameObject);
    }
}
