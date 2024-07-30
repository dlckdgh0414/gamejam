using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName ="SO/Card")]
public class CardSO : ScriptableObject
{
  
    public string cardName;
    public Sprite[] sprite;
    public List<int> correctCard;
    [Range(0, 100)]
   
            
}
