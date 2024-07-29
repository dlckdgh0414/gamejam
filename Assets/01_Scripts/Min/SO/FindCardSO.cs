using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "SO/FindCardSO")]
public class FindCardSO : ScriptableObject
{
    public List<Sprite> sprite;

    public Sprite correctSprite;
}
