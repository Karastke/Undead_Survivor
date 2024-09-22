using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gear : MonoBehaviour
{
    public ItemData.ItemType type;
    public float rate;

    public void Init(ItemData data)
    {
        //Basic Set
        name = "Gear " + data.itemId;
        transform.parent = GameManager.Instance.player.transform;
        transform.localPosition = Vector3.zero;

        // Property Set
        type = data.itemType;
        rate = data.damages[0];
        ApplyGear();
    }

    public void LevelUp(float rate)
    {
        this.rate = rate;
        ApplyGear();
    }

    void ApplyGear()
    {
         Debug.Log("ApplyGear 호출됨");
        switch (type)
        {
            case ItemData.ItemType.Glove:
                RateUp();
                break;
            case ItemData.ItemType.Shoe:
                SpeedUp();
                break;
            
        }
    }

    void RateUp()
    {
        Weapon[] weapons = transform.parent.GetComponentsInChildren<Weapon>();
        

        foreach(Weapon weapon in weapons)
        {
            
            switch (weapon.id)
            {
            
                case 0:
                    weapon.speed = 150 + (150 * rate);
                    break;
                default:
                    weapon.speed = 0.5f * (1f - rate);
                    break;
            }
            Debug.Log("Rate: " + rate + ", Weapon Speed: " + weapon.speed);
        }
        
    }

    void SpeedUp()
    {
        float speed =  5.0f;
        GameManager.Instance.player.speed = speed + speed * rate;
    }
}
