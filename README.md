# MGS-ContextMenu

## Summary
- Unity plugin for make context menu UI in scene.

## Demand
- In Unity scene, show context menu when mouse right button click on the target gameobject and click the menu item to do something.

## Environment
- Unity 5.0 or above.
- .Net Framework 3.0 or above.

## Achieve
- ContextMenuUI.cs : Manage the context menu UI(UGUI).
- ContextMenuTrigger.cs : Trigger of context menu, show context menu on mouse right button click on the target gameobject.
- ContextMenuAgent.cs : Agent of context menu, achieve the actions of context menu item is clicked.
- In fact, this plugin just build a frame of context menu, you need write the component script, extend the ContextMenuAgent class and achieve the OnMenuItemClick method to something that you wan, and attach it to the target gameobject. just like the TransformExample and the ColorExample component.

## Demo
- Demos in the path “MGS-ContextMenu\Scenes” provide reference to you.

## Contact
- If you have any questions, feel free to contact me at mogoson@qq.com.
