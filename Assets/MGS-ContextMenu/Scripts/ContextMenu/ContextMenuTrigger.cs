/*************************************************************************
 *  Copyright (C), 2017-2018, Mogoson Tech. Co., Ltd.
 *  FileName: ContextMenuTrigger.cs
 *  Author: Mogoson   Version: 0.1.0   Date: 6/14/2017
 *  Version Description:
 *    Internal develop version,mainly to achieve its function.
 *  File Description:
 *    Ignore.
 *  Class List:
 *    <ID>           <name>             <description>
 *     1.      ContextMenuTrigger          Ignore.
 *  Function List:
 *    <class ID>     <name>             <description>
 *     1.
 *  History:
 *    <ID>    <author>      <time>      <version>      <description>
 *     1.     Mogoson     6/14/2017       0.1.0       Create this file.
 *************************************************************************/

using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Developer.ContextMenu
{
    [RequireComponent(typeof(Camera))]
    [AddComponentMenu("Developer/ContextMenu/ContextMenuTrigger")]
    public class ContextMenuTrigger : MonoBehaviour
    {
        #region Property and Field
        /// <summary>
        /// Layer of ray.
        /// </summary>
        public LayerMask layerMask = 1;

        /// <summary>
        /// Max distance of ray.
        /// </summary>
        public float maxDistance = 100;

        /// <summary>
        /// List of ContextMenuUI.
        /// </summary>
        public List<ContextMenuUI> menuUIList = new List<ContextMenuUI>();

        /// <summary>
        /// Current ContextMenuUI of trigger.
        /// </summary>
        protected ContextMenuUI currentMenuUI;

        /// <summary>
        /// Camera to ray.
        /// </summary>
        protected Camera rayCamera;
        #endregion

        #region Protected Method
        protected virtual void Start()
        {
            rayCamera = GetComponent<Camera>();
        }

        protected virtual void Update()
        {
            if (Input.GetMouseButtonDown(0) && !EventSystem.current.IsPointerOverGameObject())
                CloseCurrentMenuUI();
            else if (Input.GetMouseButtonDown(1))
            {
                CloseCurrentMenuUI();
                var ray = rayCamera.ScreenPointToRay(Input.mousePosition);
                RaycastHit hitInfo;
                if (Physics.Raycast(ray, out hitInfo, maxDistance, layerMask))
                {
                    var menuAgent = hitInfo.transform.GetComponent<ContextMenuAgent>();
                    if (menuAgent)
                    {
                        currentMenuUI = GetContextMenuUI(menuAgent.menuType);
                        if (currentMenuUI)
                        {
                            currentMenuUI.menuAgent = menuAgent;
                            currentMenuUI.Show(Input.mousePosition);
                        }
                    }
                }
            }
        }

        /// <summary>
        /// Close current ContextMenuUI.
        /// </summary>
        protected void CloseCurrentMenuUI()
        {
            if (currentMenuUI)
            {
                currentMenuUI.Close();
                currentMenuUI = null;
            }
        }

        /// <summary>
        /// Get ContextMenuUI from menuUIList by menuType.
        /// </summary>
        /// <param name="menuType">Type of ContextMenuUI.</param>
        /// <returns>Target ContextMenuUI.</returns>
        protected ContextMenuUI GetContextMenuUI(ContextMenuType menuType)
        {
            foreach (var menuUI in menuUIList)
            {
                if (menuUI.menuType == menuType)
                    return menuUI;
            }

            Debug.LogWarning("Can not fined the ContextMenuUI. ContextMenuType is : " + menuType);
            return null;
        }
        #endregion
    }
}