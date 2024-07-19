using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GemUI : MonoBehaviour
{
    private TextMeshProUGUI gemText;

    public int gemCount;

    private void Start()
    {
        gemText = GetComponent<TextMeshProUGUI>();
    }
    private void OnEnable()
    {
        Gem.OnGemCollected += IncrementGemCount;
    }

    private void OnDisable()
    {
        Gem.OnGemCollected += IncrementGemCount;
    }
    public void IncrementGemCount()
    {
        gemCount++;
        gemText.text = $"Gems: {gemCount}";
    }
}
