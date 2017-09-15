==========================================================================
  Copyright (C), 2017-2018, Mogoson Tech. Co., Ltd.
  Name: MGS-ContextMenu
  Author: Mogoson   Version: 1.0   Date: 6/16/2017
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
    ContextMenuUI : Manage the context menu UI(UGUI).

    ContextMenuTrigger : Trigger of context menu, show context menu
    on mouse right button click on the target gameobject.

    ContextMenuAgent : Agent of context menu, achieve the actions of
    context menu item is clicked.

    In fact, this plugin just build a frame of context menu, you need
    write the component script, extend the ContextMenuAgent class and
    achieve the OnMenuItemClick method to something that you wan, and
    attach it to the target gameobject. just like the TransformExample
    and the ColorExample component.
--------------------------------------------------------------------------
  [Usage]
    Attach the ContextMenuTrigger to the main camera of your scene.

    Attach the ContextMenuUI to the context menu UI root, in fact, you
    can make multi context menu UI.

    Create your script component, extend the ContextMenuAgent class and
    achieve the OnMenuItemClick method to something that you wan, just
    like the TransformExample component.

    Require the Collider component is attached to the target gameobject
    and attach your script component.
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