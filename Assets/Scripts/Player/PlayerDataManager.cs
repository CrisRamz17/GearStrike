using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDataManager : MonoBehaviour
{
    [SerializeField] private PlayerData playerData;
    [SerializeField] private GameObject buttonSFX;
    // Resets player data to the starting state
    public void ResetPlayerData()
    {
        Instantiate(buttonSFX);
        playerData.checkpoint = 1;
    }

    public void SetToTitle()
    {
        playerData.checkpoint = 0;
    }
}
