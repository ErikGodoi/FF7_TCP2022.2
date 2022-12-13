using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventario : MonoBehaviour
{
    public List<GameObject> Slots = new List<GameObject>();
    public List<Itens> Items = new List<Itens>();
    public GameObject slots;
    ItemDatabase database;
    int x = -450;
    int y = 110;
    // Start is called before the first frame update
    void Start()
    {
        int slotAmount = 0;

        database = FindObjectOfType<ItemDatabase>();

        for (int i = 1; i < 7; i++)
        {
            for (int k = 1; k < 6; k++)
            {
                GameObject slot = (GameObject)Instantiate(slots);
                slot.GetComponent<SlotScript>().slotNumber = slotAmount;
                Slots.Add(slot);
                Items.Add(new Itens());
                slot.transform.parent = this.gameObject.transform;
                slot.name = "Slot" + i + "." + k;
                slot.GetComponent<RectTransform>().localPosition = new Vector3(x, y, 0f);
                x = x + 55;
                if (k == 5)
                {
                    x = -450;
                    y = y - 55;
                }
                slotAmount++;
            }
        }
        AddItem(0);
        AddItem(6);
    }
    void AddItem(int id)
    {
        for (int i = 0; i < database.itens.Count; i++)
        {
            if (database.itens[i].idItem == id)
            {
                Itens Item = database.itens[i];
                AddItemAtEmptySlot(Item);
                break;
            }
        }
    }
    void AddItemAtEmptySlot(Itens item)
    {
        for (int i = 0; i < Items.Count; i++)
        {
            if (Items[i].nomeItem == null)
            {
                Items[i] = item;
                break;
            }
        }
    }
}
