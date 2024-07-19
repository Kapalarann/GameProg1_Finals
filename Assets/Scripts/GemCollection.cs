using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GemCollection : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        Icollectible collectible = other.GetComponent<Icollectible>();
        if(collectible != null)
        {
            collectible.Collect();
        }
    }
}
