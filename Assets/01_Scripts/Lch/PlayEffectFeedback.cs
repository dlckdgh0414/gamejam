using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayEffectFeedback : Feedback
{
    EffectPlay effect;

    private void Awake()
    {
        effect = GetComponent<EffectPlay>();
    }

    public override void PlayFeedback()
    {
        EffectPlay.Intacne.ParticlePool.Pop();
         effect.SetPositionAndPlay(transform.position);
    }

    public override void StopFeedback()
    {
       
    }
}
