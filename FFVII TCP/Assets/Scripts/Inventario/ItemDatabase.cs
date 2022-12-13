using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemDatabase : MonoBehaviour
{
    public List<Itens> itens = new List<Itens>();
    void Start()
    {
        itens.Add(new Itens("Anel", 0, "Prova de um amor não correspondido", 10, 10, 1, Itens.ItemType.Rings));

        itens.Add(new Itens("Armadura", 6, "Camiseta de pijama", 10, 10, 1, Itens.ItemType.Chest));

        itens.Add(new Itens("Bota", 11, "Allstars", 10, 10, 1, Itens.ItemType.Shoes));

        itens.Add(new Itens("Brinco", 16, "Roubou da mãe", 10, 10, 1, Itens.ItemType.Earrings));

        itens.Add(new Itens("Capacete", 21, "Touca que gente estranha usa até quando ta calor", 10, 10, 1, Itens.ItemType.Head));

        itens.Add(new Itens("Espada", 26, "Tramontina", 10, 10, 1, Itens.ItemType.Weapon));

        itens.Add(new Itens("Luva", 31, "Roubou da caixa de ferramentas do pai", 10, 10, 1, Itens.ItemType.Gloves));

        itens.Add(new Itens("Pocao", 101, "Gostinho de Gatorade", 10, 10, 1, Itens.ItemType.Consumable));
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
