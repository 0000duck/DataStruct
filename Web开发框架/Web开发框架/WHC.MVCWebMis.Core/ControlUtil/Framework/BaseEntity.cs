using System;
using System.Xml.Serialization;
using System.Runtime.Serialization;
using WHC.Framework.Commons;

namespace WHC.Framework.ControlUtil
{
	/// <summary>
	/// ���ʵ����Ļ���
	/// </summary>
    [DataContract]
	public class BaseEntity
	{
        private string m_CurrentLoginUserId;

        /// <summary>
        /// ��ǰ��¼�û�ID�����ֶβ����浽���ݱ��У�ֻ���ڼ�¼�û��Ĳ�����־��
        /// </summary>
        [DataMember]
        public string CurrentLoginUserId
        {
            get { return m_CurrentLoginUserId; }
            set { m_CurrentLoginUserId = value; }
        }
	}
}
