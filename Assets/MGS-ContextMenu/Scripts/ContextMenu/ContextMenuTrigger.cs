/*************************************************************************
 *  Copyright © 2017-2018 Mogoson. All rights reserved.
 *------------------------------------------------------------------------
 *  File         :  ContextMenuTrigger.cs
 *  Description  :  Trigger of context menu.
 *------------------------------------------------------------------------
 *  Author       :  Mogoson
 *  Version      :  0.1.0
 *  Date         :  3/12/2018
 *  Description  :  Initial development version.
 *************************************************************************/

using Mogoson.IO;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Mogoson.ContextMenu
{
    /// <summary>
    /// Trigger of context menu.
    /// </summary>
    [AddComponentMenu("Mogoson/ContextMenu/ContextMenuTrigger")]
    [RequireComponent(typeof(Camera))]
    public class ContextMenuTrigger : MonoBehaviour, IContextMenuTrigger
    {
        #region Field and Property
        /// <summary>
        /// Layer of ray.
        /// </summary>
        [SerializeField]
        protected LayerMask layerMask = 1;

        /// <summary>
        /// Max distance of ray.
        /// </summary>
        [SerializeField]
        protected float maxDistance = 100;

        /// <summary>
        /// List of context menu.
        /// </summary>
        [SerializeField]
        protected List<ContextMenuUI> menuList = new List<ContextMenuUI>();

        /// <summary>
        /// Current context menu of trigger.
        /// </summary>
        public IContextMenuUI CurrentMenu { protected set; get; }

        /// <summary>
        /// Camera to ray.
        /// </summary>
        public Camera RayCamera { protected set; get; }

        /// <summary>
        /// Layer of ray.
        /// </summary>
        public LayerMask LayerMask
        {
            set { layerMask = value; }
            get { return layerMask; }
        }

        /// <summary>
        /// Max distance of ray.
        /// </summary>
        public float MaxDistance
        {
            set { maxDistance = value; }
            get { return maxDistance; }
        }
        #endregion

        #region Protected Method
        protected virtual void Start()
        {
            RayCamera = GetComponent<Camera>();
        }

        protected virtual void Update()
        {
            if (Input.GetMouseButtonDown(0) && !EventSystem.current.IsPointerOverGameObject())
                CloseCurrentMenu();
            else if (Input.GetMouseButtonDown(1))
            {
                CloseCurrentMenu();

                var ray = RayCamera.ScreenPointToRay(Input.mousePosition);
                var hitInfo = new RaycastHit();
                if (Physics.Raycast(ray, out hitInfo, maxDistance, layerMask))
                {
                    var menuAgent = hitInfo.transform.GetComponent<IContextMenuAgent>();
                    if (menuAgent != null)
                    {
                        CurrentMenu = FindContextMenu(menuAgent.MenuName);
                        if (CurrentMenu != null)
                            CurrentMenu.Show(menuAgent, Input.mousePosition);
                    }
                }
            }
        }

        /// <summary>
        /// Close current context menu.
        /// </summary>
        protected void CloseCurrentMenu()
        {
            if (CurrentMenu != null)
            {
                CurrentMenu.Close();
                CurrentMenu = null;
            }
        }

        /// <summary>
        /// Find context menu from menuList by menu type.
        /// </summary>
        /// <param name="menuName">Name of target context menu.</param>
        /// <returns>Context menu found.</returns>
        protected IContextMenuUI FindContextMenu(string menuName)
        {
            foreach (var menu in menuList)
            {
                if (menu.MenuName == menuName)
                    return menu;
            }

            LogUtility.LogWarning("Find context menu UI is failed: The context menu that name is {0} does not exist.", menuName);
            return null;
        }
        #endregion

        #region Public Method
        /// <summary>
        /// Add menu UI to trigger.
        /// </summary>
        /// <param name="menuUI">Context menu ui to add.</param>
        public void AddMenuUI(ContextMenuUI menuUI)
        {
            if (menuUI == null || menuList.Contains(menuUI))
                return;

            menuList.Add(menuUI);
        }

        /// <summary>
        /// Remove menu UI from trigger.
        /// </summary>
        /// <param name="menuUI">Context menu ui to remove.</param>
        public void RemoveMenuUI(ContextMenuUI menuUI)
        {
            menuList.Remove(menuUI);
        }

        /// <summary>
        /// Clear all menu UI of trigger.
        /// </summary>
        public void ClearMenuUI()
        {
            menuList.Clear();
        }
        #endregion
    }
}