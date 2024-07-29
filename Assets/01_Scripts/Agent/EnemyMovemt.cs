using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovemt : MonoBehaviour
{
    [Header("Settings")]
    public float moveSpeed = 5f;

    public Rigidbody2D rbcompo { get; private set; }
    public float xyMove;
}
