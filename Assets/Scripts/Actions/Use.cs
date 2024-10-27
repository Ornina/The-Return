using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Actions/Use")]
public class Use : Action
{
    public override void RespondToInput(GameController controller, string noun)
    {
        //use in the room
        if (UseItem(controller, controller.player.currentLocation.items, noun))
            return;

        //use in inventroy
        if (UseItem(controller, controller.player.inventory, noun))
            return;

        controller.currentText.text = "There is no " + noun;
    }

    private bool UseItem(GameController controller, List<Item> items, string noun)
    {
        foreach (var item in items)
        {
            if (item.itemName == noun)
            {
                if (controller.player.CanUseItem(controller, item))
                { 
                    if (item.InteractWith(controller, "use"))
                        return true;
                    controller.currentText.text = "The " + noun + " does nothing!";
                    return true;
                }
            }
        }
        return false;
    }
}
