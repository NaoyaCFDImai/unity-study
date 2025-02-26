using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RawImageControl : MonoBehaviour
{
    private void Awake()
    {
        Debug.Log($"Awake");
        Debug.Log($"gameObject name: {gameObject.name}");
        RectTransform rectTransform = GetComponent<RectTransform>();
        Debug.Log($"({rectTransform.rect.width} ,{rectTransform.rect.height})");
    }
    private void Start()
    {
        Debug.Log($"Start");
        RectTransform rectTransform = GetComponent<RectTransform>();
        Debug.Log($"({rectTransform.rect.width} ,{rectTransform.rect.height})");
    }
    private void Update()
    {
    }
}
