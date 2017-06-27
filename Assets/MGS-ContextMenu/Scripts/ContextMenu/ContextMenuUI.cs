/*************************************************************************
 *  Copyright (C), 2017-2018, Mogoson tech. Co., Ltd.
 *  FileName: ContextMenuUI.cs
 *  Author: Mogoson   Version: 1.0   Date: 6/14/2017
 *  Version Description:
 *    Internal develop version,mainly to achieve its function.
 *  File Description:
 *    Ignore.
 *  Class List:
 *    <ID>           <name>             <description>
 *     1.        ContextMenuUI             Ignore.
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

    [RequireComponent(typeof(RectTransform))]
    [AddComponentMenu("Developer/ContextMenu/ContextMenuUI")]
    public class ContextMenuUI : MonoBehaviour
    {
        #region Property and Field
        /// <summary>
        /// Background RectTransform of ContextMenu UI.
        /// </summary>
        public RectTransform bgRect;

        /// <summary>
        /// ContextMenuAgent of ContextMenu UI.
        /// </summary>
        public ContextMenuAgent agent { set; get; }
        #endregion

        #region Protected Method
        protected virtual void Reset()
        {
            bgRect = GetComponent<RectTransform>();
        }//Reset()_end
        #endregion

        #region Public Method
        /// <summary>
        /// Show ContextMenu UI.
        /// </summary>
        /// <param name="pointerPos">Mouse pointer screen position.</param>
        public virtual void Show(Vector2 pointerPos)
        {
            //Calculate position of ContextMenu UI.
            var halfWidth = bgRect.rect.width * 0.5f;
            var halfHeight = bgRect.rect.height * 0.5f;
            var newX = pointerPos.x < Screen.width - bgRect.rect.width ? pointerPos.x + halfWidth : Screen.width - halfWidth;
            var newY = pointerPos.y < bgRect.rect.height ? pointerPos.y + halfHeight : pointerPos.y - halfHeight;
            transform.position = new Vector2(newX, newY);

            //Axtive ContextMenu UI.
            gameObject.SetActive(true);
        }//Show()_end

        /// <summary>
        /// Close ContextMenu UI.
        /// </summary>
        public virtual void Close()
        {
            gameObject.SetActive(false);
        }//Close()_end

        /// <summary>
        /// Menu item click.
        /// </summary>
        /// <param name="itemIndex">Index of menu item.</param>
        public virtual void MenuItemClick(int itemIndex)
        {
            agent.OnMenuItemClick(itemIndex);
            Close();
        }//MenuI...()_end
        #endregion
    }//class_end
}//namespace_end