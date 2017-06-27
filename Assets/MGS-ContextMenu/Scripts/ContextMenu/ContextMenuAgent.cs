/*************************************************************************
 *  Copyright (C), 2017-2018, Mogoson tech. Co., Ltd.
 *  FileName: ContextMenuAgent.cs
 *  Author: Mogoson   Version: 1.0   Date: 6/14/2017
 *  Version Description:
 *    Internal develop version,mainly to achieve its function.
 *  File Description:
 *    Ignore.
 *  Class List:
 *    <ID>           <name>             <description>
 *     1.       ContextMenuAgent           Ignore.
 *  Function List:
 *    <class ID>     <name>             <description>
 *     1.
 *  History:
 *    <ID>    <author>      <time>      <version>      <description>
 *     1.     Mogoson     6/14/2017       1.0        Build this file.
 *************************************************************************/

namespace Developer.ContextMenu
{
    using UnityEngine;

    [RequireComponent(typeof(Collider))]
    public abstract class ContextMenuAgent : MonoBehaviour
    {
        #region Property and Field
        /// <summary>
        /// Target ContextMenuUI of agent.
        /// </summary>
        public ContextMenuUI menuUI;
        #endregion

        #region Protected Method
        protected virtual void Reset()
        {
            menuUI = FindObjectOfType<ContextMenuUI>();
        }//Reset()_end
        #endregion

        #region Public Method
        /// <summary>
        /// ContextMenuUI menu item click.
        /// </summary>
        /// <param name="itemIndex">Index of menu item.</param>
        public abstract void OnMenuItemClick(int itemIndex);
        #endregion
    }//class_end
}//namespace_end