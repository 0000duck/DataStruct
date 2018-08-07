using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using WHC.Pager.Entity;
using WHC.Framework.Commons;
using WHC.MVCWebMis.BLL;
using WHC.MVCWebMis.Entity;
using WHC.Framework.ControlUtil;

namespace WHC.MVCWebMis.Controllers
{
    /// <summary>
    /// ��ɫ�ɷ������ݣ���֯�������Ŀ�������
    /// </summary>
    public class RoleDataController : BusinessController<RoleData, RoleDataInfo>
    {
        public RoleDataController() : base()
        {
        }

        /// <summary>
        /// �����ɫ������Ȩ��
        /// </summary>
        /// <param name="roleId">��ɫID</param>
        /// <param name="belongCompanys">������˾</param>
        /// <param name="belongDepts">��������</param>
        /// <returns></returns>
        public ActionResult UpdateRoleData(int roleId, string belongCompanys, string belongDepts)
        {
            bool result = BLLFactory<RoleData>.Instance.UpdateRoleData(roleId, belongCompanys, belongDepts);

            return Content(result);
        }

        /// <summary>
        /// ��ȡ��ɫ����������Ȩ�ޣ���֯����ID�б�
        /// </summary>
        /// <param name="roleId">��ɫID</param>
        /// <returns></returns>
        public ActionResult GetRoleDataList(int roleId)
        {
            Dictionary<int,int> dict = BLLFactory<RoleData>.Instance.GetRoleDataDict(roleId);

            List<int> list = new List<int>(); 
            list.AddRange(dict.Keys);

            return Json(list, JsonRequestBehavior.AllowGet);
        }
    }
}
