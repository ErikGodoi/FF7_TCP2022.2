using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class SlotScript : MonoBehaviour, IPointerDownHandler, IPointerEnterHandler
{
    public Itens item;
    Image itemImage;
    public int slotNumber;
    Inventario inv;
    void Start()
    {
        inv = GameObject.FindGameObjectWithTag("Inventario").GetComponent<Inventario>();
        itemImage = gameObject.transform.GetChild(0).GetComponent<Image>();
    }
    void Update()
    {
        if (inv.Items[slotNumber].nomeItem != null)
        {
            itemImage.enabled = true;
            itemImage.sprite = item.iconeItem;
        }
        else
        {
            itemImage.enabled = false;
        }
    }
    public void OnPointerDown(PointerEventData data)
    {
        Debug.Log("clicou");
    }
    public void OnPointerEnter(PointerEventData data)
    {
        Debug.Log("Pudim");
    }
}
