/*************************************************************************
 *  Copyright (C), 2017-2018, Mogoson Tech. Co., Ltd.
 *  FileName: ContextMenuTrigger.cs
 *  Author: Mogoson   Version: 1.0   Date: 6/14/2017
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
 *     1.     Mogoson     6/14/2017       1.0        Build this file.
 *************************************************************************/

namespace Developer.ContextMenu
{
    using UnityEngine;
    using UnityEngine.EventSystems;

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
        /// Current ContextMenuAgent of trigger.
        /// </summary>
        public ContextMenuAgent current { protected set; get; }

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
                CloseCurrent();
            else if (Input.GetMouseButtonDown(1))
            {
                CloseCurrent();
                var ray = rayCamera.ScreenPointToRay(Input.mousePosition);
                RaycastHit hitInfo;
                if (Physics.Raycast(ray, out hitInfo, maxDistance, layerMask))
                {
                    current = hitInfo.transform.GetComponent<ContextMenuAgent>();
                    if (current)
                    {
                        current.menuUI.agent = current;
                        current.menuUI.Show(Input.mousePosition);
                    }
                }
            }
        }

        /// <summary>
        /// Close current ContextMenuUI.
        /// </summary>
        protected void CloseCurrent()
        {
            if (current)
            {
                current.menuUI.Close();
                current = null;
            }
        }
        #endregion
    }
}