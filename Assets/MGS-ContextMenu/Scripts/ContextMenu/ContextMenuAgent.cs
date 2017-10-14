/*************************************************************************
 *  Copyright (C), 2017-2018, Mogoson Tech. Co., Ltd.
 *------------------------------------------------------------------------
 *  File         :  ContextMenuAgent.cs
 *  Description  :  Define agent for ContextMenuUI component.
 *------------------------------------------------------------------------
 *  Author       :  Mogoson
 *  Version      :  0.1.0
 *  Date         :  6/14/2017
 *  Description  :  Initial development version.
 *************************************************************************/

using UnityEngine;

namespace Developer.ContextMenu
{
    [RequireComponent(typeof(Collider))]
    public abstract class ContextMenuAgent : MonoBehaviour
    {
        #region Property and Field
        /// <summary>
        /// ContextMenuType of agent.
        /// </summary>
        public ContextMenuType menuType = ContextMenuType.Untyped;
        #endregion

        #region Public Method
        /// <summary>
        /// Event on ContextMenu item click.
        /// </summary>
        /// <param name="itemIndex">Index of menu item.</param>
        public abstract void OnMenuItemClick(int itemIndex);
        #endregion
    }
}