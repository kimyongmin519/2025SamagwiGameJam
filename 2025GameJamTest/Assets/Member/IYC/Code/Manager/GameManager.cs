using System;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance {  get; private set; }

    public float baseScrollSpeed = 5f;
    public float currentScrollSpeed;

    private void Update()
    {
        UpdateScrollSpeed();
    }

    private void UpdateScrollSpeed()
    {

    }
}