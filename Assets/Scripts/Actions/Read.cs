using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Actions/Read")]
public class Read : Action
{
    public override void RespondToInput(GameController controller, string noun)
    {
        //check in the room
        if (ReadItem(controller, controller.player.currentLocation.items, noun))
            return;

        //check in inventroy
        if (ReadItem(controller, controller.player.inventory, noun))
            return;

        controller.currentText.text = "There is nothing to read!";
    }

    private bool ReadItem(GameController controller, List<Item> items, string noun)
    {
        foreach (Item item in items)
        {
            if (item.itemName == noun)
            {
                if (controller.player.CanReadItem(controller, item))
                {
                    if (item.InteractWith(controller, "read"))
                        return true;
                    controller.currentText.text = "The " + noun + " reads: " + item.itemDescription;
                    return true;
                }
            }
        }
        return false;
    }
}
