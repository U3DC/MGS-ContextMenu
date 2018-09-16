/*************************************************************************
 *  Copyright © 2018 Mogoson. All rights reserved.
 *------------------------------------------------------------------------
 *  File         :  IContextMenuAgent.cs
 *  Description  :  Define interface for context menu agent.
 *------------------------------------------------------------------------
 *  Author       :  Mogoson
 *  Version      :  0.1.0
 *  Date         :  9/16/2018
 *  Description  :  Initial development version.
 *************************************************************************/

using System.Collections.Generic;

namespace Mogoson.ContextMenu
{
    /// <summary>
    /// Interface for context menu agent.
    /// </summary>
    public interface IContextMenuAgent
    {
        #region Property
        /// <summary>
        ///  Name of target context menu.
        /// </summary>
        string MenuName { set; get; }

        /// <summary>
        /// Disable items of show target context menu.
        /// </summary>
        IEnumerable<string> DisableItems { get; }
        #endregion

        #region Public Method
        /// <summary>
        /// Event on context menu item click.
        /// </summary>
        /// <param name="itemName">Name of menu item.</param>
        void OnMenuItemClick(string itemName);
        #endregion
    }
}