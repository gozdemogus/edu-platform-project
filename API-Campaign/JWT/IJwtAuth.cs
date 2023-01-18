using System;
using Microsoft.AspNetCore.Mvc;

namespace APICampaign.JWT
{
	public interface IJwtAuth
    {
        string Authentication(string username, string password);
    }
}

