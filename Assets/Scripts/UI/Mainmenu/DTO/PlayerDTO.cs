using System;
using UnityEngine;

[Serializable]
public class PlayerDTO
{
    public Vector3 Position = Vector3.zero;
    public Quaternion Rotation = Quaternion.identity;
    public float PlayerSpeed = default;
    public string PlayerName  = "noname";
}
