using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDataManager : MonoBehaviour
{
    [SerializeField] private PlayerData playerData;

    // Resets player data to the starting state
    public void ResetPlayerData()
    {
        playerData.checkpoint = 0;
    }
}
