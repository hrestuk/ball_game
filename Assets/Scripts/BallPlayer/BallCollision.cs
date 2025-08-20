using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallCollision : MonoBehaviour
{
    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag.Contains("Trap"))
        {
            LevelStateManager.Instance.OnPlayerLose();
        }
        else if(other.gameObject.tag.Contains("Finish"))
        {
            LevelStateManager.Instance.OnPlayerWin();
        }
    }
}
