//------------------------------------------------------------------------------
// <auto-generated>
//     此代码已从模板生成。
//
//     手动更改此文件可能导致应用程序出现意外的行为。
//     如果重新生成代码，将覆盖对此文件的手动更改。
// </auto-generated>
//------------------------------------------------------------------------------

using Apps.Models;
using System;
namespace Apps.Models.V
{
	public class Virtual_V_DEF_DefectModel
	{
			public virtual string ItemID { get; set; }
			public virtual string VerCode { get; set; }
			public virtual string Code { get; set; }
			public virtual string Title { get; set; }
			public virtual string Creator { get; set; }
			public virtual Nullable<System.DateTime> CrtDt { get; set; }
			public virtual string Receiver { get; set; }
			public virtual Nullable<System.DateTime> SendDt { get; set; }
			public virtual Nullable<bool> CloseState { get; set; }
			public virtual string Closer { get; set; }
			public virtual Nullable<System.DateTime> CloseDt { get; set; }
			public virtual string TestContent { get; set; }
			public virtual string ResultContent { get; set; }
			public virtual string Remark { get; set; }
			public virtual string MessageId { get; set; }
			public virtual Nullable<int> Sort { get; set; }
			public virtual Nullable<bool> ProcessState { get; set; }
			public virtual string Processor { get; set; }
			public virtual Nullable<System.DateTime> ProcessDt { get; set; }
			public virtual Nullable<int> ErrorLevel { get; set; }
			public virtual string CaseName { get; set; }
			public virtual Nullable<int> Complex { get; set; }
			public virtual Nullable<System.DateTime> PStartDt { get; set; }
			public virtual Nullable<System.DateTime> PEndDt { get; set; }
			public virtual string Executor { get; set; }
		}
}
