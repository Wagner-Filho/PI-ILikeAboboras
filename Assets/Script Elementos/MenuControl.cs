using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

public class MenuControl : MonoBehaviour
{
    [SerializeField]
    List<Transform> _itensMenu;
    internal Vector3 localScale;

    public void MenuOff()
    {
        for (int i = 0 ; i < _itensMenu.Count; i++) 
        {
            _itensMenu[i].localScale = Vector3.zero;
        }
    }

    public void ChamarMenu()
    {
        _itensMenu[0].GetComponent<Button>().Select();
        StartCoroutine(TimeItens());
    }

    IEnumerator TimeItens()
    {
        for (int i = 0; i < _itensMenu.Count; i++)
        {
            yield return new WaitForSeconds(.25f);
            _itensMenu[i].DOScale(1.5f, 0.25f);
            yield return new WaitForSeconds(.25f);
            _itensMenu[i].DOScale(1f, 0.25f);
        }
    }
}
