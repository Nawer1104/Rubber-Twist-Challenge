using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Object : MonoBehaviour
{
    [SerializeField] private List<GameObject> objs = new List<GameObject>();

    private int index = 0;

    private bool canTouch;

    private void Start()
    {
        objs[index].SetActive(true);

        objs[index].transform.DOScale(1f, 1f);

        canTouch = true;
    }

    private void OnMouseDown()
    {
        if (!canTouch) return;

        canTouch = false;

        objs[index].transform.DOScale(0f, 1f).OnComplete(() => {
            objs[index].SetActive(false);

            index += 1;

            objs[index].SetActive(true);
            objs[index].transform.DOScale(1f, 1f);

            canTouch = true;
        });

        if (index >= objs.Count - 1)
        {
            GameManager.Instance.CheckLevelUp();
        } 
    }
}
