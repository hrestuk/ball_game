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


    public void SwitchToNormal()
    {
        currentType = BallType.Normal;
        UpdateSettings();
    }
    
    public void SwitchToHeavy()
    {
        currentType = BallType.Heavy;
        UpdateSettings();
    }
    
    public void SwitchToMagnetic()
    {
        currentType = BallType.Magnetic;
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
                Debug.Log(currentType);
                break;
            }
        }
    }

    

    public BallSettings GetSettingsForType(BallType type)
    {
        foreach (var item in ballTypeSettings)
        {
            if (item.ballType == type)
                return item.ballSettings;
        }
        return null;
    }
    
    public void SetCurrentSettings(BallType type)
    {
        foreach (var item in ballTypeSettings)
        {
            if (item.ballType == type)
            {
                currentSettings = item.ballSettings;
                break;
            }
        }
    }

}
