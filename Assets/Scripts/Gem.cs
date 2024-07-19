using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Gem : MonoBehaviour, Icollectible
{
    public static event Action OnGemCollected;
    public void Collect()
    {
        Destroy(gameObject);
        OnGemCollected?.Invoke();
    }
}
