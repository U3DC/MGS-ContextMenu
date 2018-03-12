/*************************************************************************
 *  Copyright © 2017-2018 Mogoson. All rights reserved.
 *------------------------------------------------------------------------
 *  File         :  ContextMenuAgent.cs
 *  Description  :  Define agent for context menu.
 *------------------------------------------------------------------------
 *  Author       :  Mogoson
 *  Version      :  0.1.0
 *  Date         :  3/12/2018
 *  Description  :  Initial development version.
 *************************************************************************/

using UnityEngine;

namespace Developer.ContextMenu
{
    [RequireComponent(typeof(Collider))]
    public abstract class ContextMenuAgent : MonoBehaviour
    {
        #region Field and Property
        /// <summary>
        /// Type of target context menu.
        /// </summary>
        public ContextMenuType menuType = ContextMenuType.Undefined;
        #endregion

        #region Public Method
        /// <summary>
        /// Event on context menu item click.
        /// </summary>
        /// <param name="itemIndex">Index of menu item.</param>
        public abstract void OnMenuItemClick(int itemIndex);
        #endregion
    }
}