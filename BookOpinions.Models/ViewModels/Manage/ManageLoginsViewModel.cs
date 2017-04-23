﻿namespace BookOpinions.Models.ViewModels.Manage
{
    using Microsoft.AspNet.Identity;
    using Microsoft.Owin.Security;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class ManageLoginsViewModel
    {
        public IList<UserLoginInfo> CurrentLogins { get; set; }
        public IList<AuthenticationDescription> OtherLogins { get; set; }
    }
}