using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerWallDetector : MonoBehaviour
{
    [SerializeField] PlayerGroundDetector wallDetector;
    public PlayerGroundDetector WallDetector => wallDetector;

}
