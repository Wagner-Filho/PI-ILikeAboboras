using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
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
        _menuControl[0].gameObject.SetActive(true);
        _menuControl[0].MenuOff();
        _menuControl[0].transform.DOScale(1,0.25f);
        _menuControl[0].ChamarMenu();
    }

    public void ChamarMenuControl(int value)
    {
        for (int i = 0 ; i < _menuControl.Count ; i++)
        {
            _menuControl[i].localScale = Vector3.zero;
            _menuControl[i].MenuOff();
            _menuControl[i].gameObject.SetActive(false);
        }
        _menuControl[value].gameObject.SetActive(true);
        _menuControl[value].transform.DOScale(1, .25f);
        _menuControl[value].ChamarMenu();
    }
}
