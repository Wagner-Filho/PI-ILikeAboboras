using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HudController : MonoBehaviour
{
    [SerializeField]
    List<MenuControl> _menuControl;

    void Start()
    {
        for (int i = 0; i < _menuControl.Count;  i++)
        {
            _menuControl[i].localScale = Vector3.zero;
            _menuControl[i].gameObject.SetActive(false);
        }    
    }

    void Update()
    {
        
    }
}
