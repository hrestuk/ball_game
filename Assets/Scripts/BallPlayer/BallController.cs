using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallController : MonoBehaviour
{
    [SerializeField] private List<BallTypeSettings> ballTypeSettings;
    private BallType currentType;
    private BallSettings currentSettings;

    public BallSettings CurrentSettings => currentSettings;

    private Rigidbody rb;
    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
        currentType = BallType.Normal;
    }

    public void SwitchMode()
    {
        int currentIndex = (int)currentType;
        int nextIndex = (currentIndex + 1) % Enum.GetValues(typeof(BallType)).Length;

        currentType = (BallType)nextIndex;
        UpdateSettings();
    }

    private void UpdateSettings()
    {
        foreach (var item in ballTypeSettings)
        {
            if (item.ballType == currentType)
            {
                currentSettings = item.ballSettings;
                break;
            }
        }
    }

}
