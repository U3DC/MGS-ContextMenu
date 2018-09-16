/*************************************************************************
 *  Copyright © 2018 Mogoson. All rights reserved.
 *------------------------------------------------------------------------
 *  File         :  ContextMenuItem.cs
 *  Description  :  Define context menu item.
 *------------------------------------------------------------------------
 *  Author       :  Mogoson
 *  Version      :  0.1.0
 *  Date         :  9/16/2018
 *  Description  :  Initial development version.
 *************************************************************************/

using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace Mogoson.ContextMenu
{
    /// <summary>
    /// Item of context menu.
    /// </summary>
    [AddComponentMenu("Mogoson/ContextMenu/ContextMenuItem")]
    [RequireComponent(typeof(Button))]
    public class ContextMenuItem : MonoBehaviour, IContextMenuItem
    {
        #region Field and Property
        /// <summary>
        /// Button of menu item.
        /// </summary>
        [SerializeField]
        protected Button button;

        /// <summary>
        /// Name of menu item.
        /// </summary>
        [SerializeField]
        protected string itemName = "Item Name";

        /// <summary>
        /// Name of menu item.
        /// </summary>
        public string ItemName
        {
            set { itemName = value; }
            get { return itemName; }
        }

        /// <summary>
        /// Interactable of menu item.
        /// </summary>
        public bool Interactable
        {
            set { button.interactable = value; }
            get { return button.interactable; }
        }
        #endregion

        #region Protected Method
        protected virtual void Reset()
        {
            button = GetComponent<Button>();
        }
        #endregion

        #region Public Method
        /// <summary>
        /// Add listener to menu item.
        /// </summary>
        /// <param name="callback">Callback function.</param>
        public void AddListener(UnityAction callback)
        {
            button.onClick.AddListener(callback);
        }

        /// <summary>
        /// Remove listener from menu item.
        /// </summary>
        /// <param name="callback">Callback function.</param>
        public void RemoveListener(UnityAction callback)
        {
            button.onClick.RemoveListener(callback);
        }
        #endregion
    }
}