using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReadyScreen : MonoBehaviour
{
    [SerializeField] VoidEventChannel levelStartEventChannel;

    void LevelStart()
    {
        levelStartEventChannel.Broadcast();
        GetComponent<Canvas>().enabled = false;
        GetComponent<Animator>().enabled = false;

    }

}
