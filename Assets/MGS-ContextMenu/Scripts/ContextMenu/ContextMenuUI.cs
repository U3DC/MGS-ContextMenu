/*************************************************************************
 *  Copyright © 2017-2018 Mogoson. All rights reserved.
 *------------------------------------------------------------------------
 *  File         :  ContextMenuUI.cs
 *  Description  :  Context menu UI(UGUI).
 *------------------------------------------------------------------------
 *  Author       :  Mogoson
 *  Version      :  0.1.0
 *  Date         :  6/14/2017
 *  Description  :  Initial development version.
 *  
 *  Author       :  Mogoson
 *  Version      :  0.1.1
 *  Date         :  3/12/2018
 *  Description  :  Protected agent.
 *************************************************************************/

using System.Collections.Generic;
using UnityEngine;

namespace Mogoson.ContextMenu
{
    /// <summary>
    /// Context menu UI(UGUI).
    /// </summary>
    [AddComponentMenu("Mogoson/ContextMenu/ContextMenuUI")]
    [RequireComponent(typeof(RectTransform))]
    public class ContextMenuUI : MonoBehaviour, IContextMenuUI
    {
        #region Field and Property
        /// <summary>
        /// Name of context menu.
        /// </summary>
        [SerializeField]
        protected string menuName = "Menu Name";

        /// <summary>
        /// Agent of context menu.
        /// </summary>
        protected IContextMenuAgent agent;

        /// <summary>
        /// Root RectTransform of context menu.
        /// </summary>
        protected RectTransform rootRect;

        /// <summary>
        /// Dictionary of context menu items.
        /// </summary>
        protected Dictionary<string, IContextMenuItem> itemDic = new Dictionary<string, IContextMenuItem>();

        /// <summary>
        /// Name of context menu.
        /// </summary>
        public string MenuName
        {
            set { menuName = value; }
            get { return menuName; }
        }
        #endregion

        #region Protected Method
        protected virtual void Awake()
        {
            rootRect = GetComponent<RectTransform>();
            var items = GetComponentsInChildren<IContextMenuItem>(true);
            foreach (var item in items)
            {
                var itemName = item.ItemName;
                item.AddListener(() => MenuItemClick(itemName));
                itemDic.Add(item.ItemName, item);
            }
        }

        /// <summary>
        /// Menu item click.
        /// </summary>
        /// <param name="itemName">Name of menu item.</param>
        protected virtual void MenuItemClick(string itemName)
        {
            agent.OnMenuItemClick(itemName);
            Close();
        }

        /// <summary>
        /// Enable all children items.
        /// </summary>
        protected virtual void EnableAllItems()
        {
            foreach (var item in itemDic.Values)
            {
                item.Interactable = true;
            }
        }

        /// <summary>
        /// Disable children items by items name.
        /// </summary>
        /// <param name="itemNames">Names of menu items to disable.</param>
        protected virtual void DisableItems(IEnumerable<string> itemNames)
        {
            foreach (var itemName in itemNames)
            {
                if (itemDic.ContainsKey(itemName))
                {
                    itemDic[itemName].Interactable = false;
                }
            }
        }

        /// <summary>
        /// Get screen position of menu UI base on mouse pointer position.
        /// </summary>
        /// <param name="mousePosition">Screen position of mouse pointer.</param>
        /// <returns>Screen position of menu UI.</returns>
        protected virtual Vector2 GetMenuUIPosition(Vector2 mousePosition)
        {
            var halfWidth = rootRect.rect.width * 0.5f;
            var halfHeight = rootRect.rect.height * 0.5f;
            var newX = mousePosition.x < Screen.width - rootRect.rect.width ? mousePosition.x + halfWidth : Screen.width - halfWidth;
            var newY = mousePosition.y < rootRect.rect.height ? mousePosition.y + halfHeight : mousePosition.y - halfHeight;
            return new Vector2(newX, newY);
        }
        #endregion

        #region Public Method
        /// <summary>
        /// Show context menu.
        /// </summary>
        /// <param name="agent">Agent of menu.</param>
        /// <param name="mousePosition">Screen position of mouse pointer.</param>
        public void Show(IContextMenuAgent agent, Vector2 mousePosition)
        {
            this.agent = agent;
            DisableItems(agent.DisableItems);
            gameObject.SetActive(true);
            transform.position = GetMenuUIPosition(mousePosition);
        }

        /// <summary>
        /// Close context menu.
        /// </summary>
        public virtual void Close()
        {
            gameObject.SetActive(false);
            EnableAllItems();
        }
        #endregion
    }
}