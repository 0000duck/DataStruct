using System;
using System.Collections;
using System.Data;
using System.Data.Common;
using System.Collections.Generic;

using WHC.Pager.Entity;
using WHC.MVCWebMis.Entity;
using WHC.MVCWebMis.IDAL;
using WHC.Framework.ControlUtil;

namespace WHC.MVCWebMis.BLL
{
	public class DictType : BaseBLL<DictTypeInfo>
    {
        public DictType()
        {
            base.Init(this.GetType().FullName, System.Reflection.Assembly.GetExecutingAssembly().GetName().Name);
        }
                
        /// <summary>
        /// ��ȡ�����ֵ����͵��б���(KeyΪ���ƣ�ValueΪIDֵ��
        /// </summary>
        /// <returns></returns>
        public Dictionary<string, string> GetAllType()
        {
            IDictType typeDal = baseDal as IDictType;
            return typeDal.GetAllType();
        }

        /// <summary>
        /// ��ȡ�����ֵ����͵��б���(KeyΪ���ƣ�ValueΪIDֵ��
        /// </summary>
        /// <param name="dictTypeId">�ֵ�����ID</param>
        /// <returns></returns>
        public Dictionary<string, string> GetAllType(string dictTypeId)
        {
            IDictType typeDal = baseDal as IDictType;
            return typeDal.GetAllType(dictTypeId);
        }

        /// <summary>
        /// �ж��Ƿ��ظ�������ظ�����True������ΪFalse
        /// </summary>
        /// <param name="dictTypeInfo"></param>
        /// <returns></returns>
        public bool CheckDuplicated(DictTypeInfo dictTypeInfo)
        {
            string condition = string.Format("(Name ='{0}' and id<> '{1}')",
                dictTypeInfo.Name, dictTypeInfo.ID);
            DictTypeInfo info = baseDal.FindSingle(condition);
            return (info != null);
        }

        public List<DictTypeNodeInfo> GetTree()
        {
            IDictType typeDal = baseDal as IDictType;
            return typeDal.GetTree();
        }

        public List<DictTypeInfo> GetTopItems()
        {
            IDictType typeDal = baseDal as IDictType;
            return typeDal.GetTopItems();
        }

        public List<DictTypeNodeInfo> GetTreeByID(string mainID)
        {
            IDictType typeDal = baseDal as IDictType;
            return typeDal.GetTreeByID(mainID);
        }
    }
}
