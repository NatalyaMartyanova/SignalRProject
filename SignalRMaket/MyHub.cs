﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using Microsoft.AspNet.SignalR;
using Microsoft.AspNet.SignalR.Hubs;
using ORM;

namespace SignalRMaket
{
	[HubName("myHub")]
	public class MyHubSv : Hub
	{
		string cid
		{
			get
			{
				string clientId = "";
				if (Context.QueryString["clientId"] != null)
				{
					clientId = Context.QueryString["clientId"];
				}
				if (string.IsNullOrWhiteSpace(clientId))
				{
					clientId = Context.ConnectionId;
				}
				return clientId;
			}
		}

		public override Task OnDisconnected(bool stopCalled)
		{
			Users.DisconnectUser(Users.UserByCid(cid));
			return base.OnDisconnected(stopCalled);
		}

		[HubMethodName("getHtmlSv")]
		public string GetHtml(string tag)
		{
			return HtmlGetter.getString(tag);
		}

		[HubMethodName("logInSv")]
		public void LogIn(string user, string pass)
		{
			var u = User.LoadUser(user, pass);
			if (u != null)
			{
				Users.ConnectUser(new WebUser(u, cid));
				Clients.Caller.onSuccessfulLoginCl();
			}
			else
				Clients.Caller.alertFuncCl("unknown user!");
		}

		[HubMethodName("alertAllSv")]
		public void AlertAll(string mes)
		{
			var u = Users.UserByCid(cid);
			if (u == null)
			{
				Clients.Caller.alertFuncCl("authorization required!");
				return;
			}
			Clients.All.alertFuncCl(string.Format("message from {0}:\n {1}", u._User.Login, mes));
		}
	}
}