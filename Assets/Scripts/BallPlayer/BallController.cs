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
    public BallType CurrentType => currentType;

    private Rigidbody rb;
    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
        currentType = BallType.Normal;
        UpdateSettings();
    }

    public void SwitchMode()
    {
        int currentIndex = (int)currentType;
        int nextIndex = (currentIndex + 1) % Enum.GetValues(typeof(BallType)).Length;

        currentType = (BallType)nextIndex;
        Debug.Log("Current mode:" + currentType);
        UpdateSettings();
    }

    private void UpdateSettings()
    {
        rb.useGravity = true;
        foreach (var item in ballTypeSettings)
        {
            if (item.ballType == currentType)
            {
                if (currentType == BallType.Magnetic)
                    rb.useGravity = false;

                currentSettings = item.ballSettings;
                break;
            }
        }
    }

}
