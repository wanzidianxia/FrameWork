using FreamWork;
using System;
using System.ServiceModel;
using System.ServiceModel.Description;

namespace ServerHost
{
	internal class MexHost : ServiceHost
	{
		public MexHost(Type serviceType, params Uri[] baseAddresses) : base(serviceType, baseAddresses)
		{
		}

		private void addguidvalidation()
		{
			int count = base.Description.Endpoints.Count;
			for (int i = 0; i < count; i++)
			{
				if (base.Description.Endpoints[i].Contract.Name != "IMetadataExchange")
				{
					int count2 = base.Description.Endpoints[i].Contract.Operations.Count;
					for (int j = 0; j < count2; j++)
					{
						if (base.Description.Endpoints[i].Contract.Operations[j].Name.Substring(0, 1) != "_")
						{
							base.Description.Endpoints[i].Contract.Operations[j].Behaviors.Add(new ValidationGuid());
						}
					}
				}
			}
		}

		private void addmexbehavior()
		{
			ServiceMetadataBehavior serviceMetadataBehavior = base.Description.Behaviors.Find<ServiceMetadataBehavior>();
			if (serviceMetadataBehavior == null)
			{
				serviceMetadataBehavior = new ServiceMetadataBehavior();
				base.Description.Behaviors.Add(serviceMetadataBehavior);
			}
			foreach (Uri current in base.BaseAddresses)
			{
				if (current.Scheme == Uri.UriSchemeHttp)
				{
					serviceMetadataBehavior.HttpGetEnabled = true;
					base.AddServiceEndpoint("IMetadataExchange", MetadataExchangeBindings.CreateMexHttpBinding(), "mex");
				}
				else if (current.Scheme == Uri.UriSchemeHttps)
				{
					serviceMetadataBehavior.HttpsGetEnabled = true;
					base.AddServiceEndpoint("IMetadataExchange", MetadataExchangeBindings.CreateMexHttpsBinding(), "mex");
				}
				else if (current.Scheme == Uri.UriSchemeNetPipe)
				{
					base.AddServiceEndpoint("IMetadataExchange", MetadataExchangeBindings.CreateMexNamedPipeBinding(), "mex");
				}
				else if (current.Scheme == Uri.UriSchemeNetTcp)
				{
					base.AddServiceEndpoint("IMetadataExchange", MetadataExchangeBindings.CreateMexTcpBinding(), "mex");
				}
			}
		}

		protected override void ApplyConfiguration()
		{
			base.ApplyConfiguration();
			if (Service.GetAppHelp().GetAppSettingToInt("novalidationguid") == 0)
			{
				this.addguidvalidation();
			}
			if (Service.GetAppHelp().GetAppSettingToInt("publicmex") != 0)
			{
				this.addmexbehavior();
			}
		}
	}
}
