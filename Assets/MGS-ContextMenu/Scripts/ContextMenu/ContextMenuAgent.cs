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

using System.Collections.Generic;
using UnityEngine;

namespace Mogoson.ContextMenu
{
    /// <summary>
    /// Agent for context menu.
    /// </summary>
    [RequireComponent(typeof(Collider))]
    public abstract class ContextMenuAgent : MonoBehaviour, IContextMenuAgent
    {
        #region Field and Property
        /// <summary>
        /// Name of target context menu.
        /// </summary>
        [SerializeField]
        protected string menuName = "Menu Name";

        /// <summary>
        /// Name of target context menu.
        /// </summary>
        public string MenuName
        {
            set { menuName = value; }
            get { return menuName; }
        }

        /// <summary>
        /// Disable items of show target context menu.
        /// </summary>
        public abstract IEnumerable<string> DisableItems { get; }
        #endregion

        #region Public Method
        /// <summary>
        /// Event on context menu item click.
        /// </summary>
        /// <param name="itemName">Name of menu item.</param>
        public abstract void OnMenuItemClick(string itemName);
        #endregion
    }
}