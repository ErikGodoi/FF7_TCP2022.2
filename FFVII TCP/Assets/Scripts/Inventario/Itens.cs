using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Itens
{
    public string nomeItem;
    public int idItem;
    public string descricaoItem;
    public Sprite iconeItem;
    public GameObject modeloItem;
    public int itemDano;
    public int itemVelocidade;
    public int itemValor;
    public ItemType itemType;

    public enum ItemType
    {
        Weapon,
        Consumable,
        Quest,
        Head,
        Shoes,
        Gloves,
        Chest,
        Trousers,
        Earrings,
        Necklace,
        Rings,
        Materia,
    }
    public Itens(string nome, int id, string descricao, int dano, int velocidade, int valor, ItemType type)
    {
        nomeItem = nome;
        idItem = id;
        descricaoItem = descricao;
        itemDano = dano;
        itemVelocidade = velocidade;
        itemValor = valor;
        itemType = type;
        iconeItem = Resources.Load<Sprite>("" + nome);
    }
    public Itens()
    {

    }
}
