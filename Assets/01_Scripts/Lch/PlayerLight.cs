using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerLight : MonoBehaviour
{
    public UnityEvent PlayerLightInts;
    [SerializeField] UnityEngine.Rendering.Universal.Light2D _Light;

  
    public void Light()
    {
        _Light.intensity += 2;
    }

}
