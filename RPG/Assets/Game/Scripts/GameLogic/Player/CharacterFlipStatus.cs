using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterFlipStatus : MonoBehaviour
{
    [SerializeField] private Transform content;

    public void Flip(Vector2 direction)
    {
        var rotation = content.rotation;
        rotation.y = direction.x < 0 ? 180 : 0;
        content.rotation = rotation;
    }
}
