using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RepeatingBackground : MonoBehaviour
{
    [SerializeField] private Vector2 position;
    private RawImage rawImage;

    private void Awake()
    {
        rawImage = GetComponent<RawImage>();
    }

    private void Update()
    {
        MoveBackground();
    }

    private void MoveBackground()
    {
        rawImage.uvRect = new Rect(rawImage.uvRect.position + position * Time.deltaTime, rawImage.uvRect.size);
    }
}
