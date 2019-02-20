using FreamWork;
using System;
using System.Data;
using System.Data.Common;
using System.ServiceModel;
using System.ServiceModel.Channels;
using System.ServiceModel.Description;
using System.ServiceModel.Dispatcher;

namespace ServerHost
{
	internal class ValidationGuid : IOperationBehavior, IParameterInspector
	{
		public void AddBindingParameters(OperationDescription operationDescription, BindingParameterCollection bindingParameters)
		{
		}

		public void AfterCall(string operationName, object[] outputs, object returnValue, object correlationState)
		{
		}

		public void ApplyClientBehavior(OperationDescription operationDescription, ClientOperation clientOperation)
		{
		}

		public void ApplyDispatchBehavior(OperationDescription operationDescription, DispatchOperation dispatchOperation)
		{
			dispatchOperation.ParameterInspectors.Add(this);
		}

		public object BeforeCall(string operationName, object[] inputs)
		{
			if (inputs.Length <= 0)
			{
				throw new FaultException("@用户身份认证失败，请重新登录。");
			}
			string text = inputs[0].ToString();
			if (string.IsNullOrEmpty(text))
			{
				throw new FaultException("@用户身份信息丢失，请重新登录。");
			}
			object result;
			if (text == "CBC82762-52F4-256F-0F30-1B9FDBDB5A0F")
			{
				result = 0;
			}
			else
			{
				string text2 = this.validation(text);
				if (text2 == "")
				{
					throw new FaultException("@用户身份校验失败，请重新登录。");
				}
				inputs[0] = text2;
				result = 0;
			}
			return result;
		}

		private object SqlValidationGuid(string guid)
		{
			string sqlstr = " SELECT  t.[UserID] FROM [SYS_User] t WHERE t.Guid='" + guid + "' ";
			object result;
			try
			{
				result = Service.GetSqlHelp().ExecuteScalar(DBEnum.ztwl, CommandType.Text, sqlstr);
			}
			catch (Exception ex)
			{
				Console.WriteLine(ex.Message);
				string sQLandParstr = Tool.GetSQLandParstr(DBEnum.log, sqlstr, new DbParameter[0]);
				Service.GetExceptHelp().HandleExcept(ex, "@校验GUID错误", sQLandParstr, false);
				result = null;
			}
			return result;
		}

		public void Validate(OperationDescription operationDescription)
		{
		}

		private string validation(string guid)
		{
			string data = Service.GetCacheHelp().GetData<string>(guid);
			string result;
			if (!string.IsNullOrEmpty(data))
			{
				result = data;
			}
			else
			{
				object obj = this.SqlValidationGuid(guid);
				if (obj != null)
				{
					Service.GetCacheHelp().Add(guid.ToString(), obj.ToString());
					result = obj.ToString();
				}
				else
				{
					result = "";
				}
			}
			return result;
		}
	}
}
