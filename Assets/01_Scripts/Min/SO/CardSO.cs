using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName ="SO/Card")]
public class CardSO : ScriptableObject
{
    public Sprite[] sprite;

    public List<int> correctCard;

    public string cardName;

}
