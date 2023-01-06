using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class PlayerScore : System.IComparable<PlayerScore>
{
    
        public string PlayerName { get; set; }
        public float Score { get; set; }

    public int Index { get; set; }

    public PlayerScore(string playerName, float score, int index)
        {
            PlayerName = playerName;
            Score = score;
        Index = index;

        }

    public int CompareTo(PlayerScore other)
    {
        // Compare the Score properties of the two PlayerScore objects
        return Score.CompareTo(other.Score);
    }

}
