==========================================================================
  Copyright © 2017-2018 Mogoson. All rights reserved.
  Name: MGS-ContextMenu
  Author: Mogoson   Version: 0.1.1   Date: 3/12/2018
==========================================================================
  [Summary]
    Unity plugin for make context menu UI in scene.
--------------------------------------------------------------------------
  [Demand]
    In Unity scene, show context menu when mouse right button click
    on the target gameobject and click the menu item to do something.
--------------------------------------------------------------------------
  [Environment]
    Unity 5.0 or above.
    .Net Framework 3.0 or above.
--------------------------------------------------------------------------
  [Achieve]
    ContextMenuType : Type to classify ContextMenu.

    ContextMenuUI : Control the context menu UI(UGUI).

    ContextMenuTrigger : Trigger of context menu, show context menu
    on mouse right button click on the target gameobject.

    ContextMenuAgent : Agent of context menu, achieve the action of
    context menu item is clicked.

    In fact, this plugin just build a frame of context menu, you need
    write your component script, inherit the ContextMenuAgent class
    and achieve the OnMenuItemClick method to something that you want
    and attach it to the target gameobject. just like the
    ContextMenuAgentExample component.
--------------------------------------------------------------------------
  [Usage]
    Attach the ContextMenuUI to the context menu UI root. you can make
    multi context menu UI.

    Attach the ContextMenuTrigger to the main camera in your scene and
    add ContextMenuUI to the Menu List.

    Create your script component, inherit the ContextMenuAgent class
    and achieve the OnMenuItemClick method to something that you want.
    just like the ContextMenuAgentExample component.

    Attach your script component to the target gameobject.
--------------------------------------------------------------------------
  [Demo]
    Demos in the path "MGS-ContextMenu\Scenes" provide reference to you.
--------------------------------------------------------------------------
  [Resource]
    https://github.com/mogoson/MGS-ContextMenu.
--------------------------------------------------------------------------
  [Contact]
    If you have any questions, feel free to contact me at mogoson@qq.com.
--------------------------------------------------------------------------