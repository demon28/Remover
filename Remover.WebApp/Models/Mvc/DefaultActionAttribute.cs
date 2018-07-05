using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Mvc;

namespace Remover.WebApp.Models.Mvc
{
    public class DefaultActionAttribute : ActionNameSelectorAttribute
    {

        public override bool IsValidName(ControllerContext controllerContext, string actionName, MethodInfo methodInfo)
        {
            return false;
        }
    }
}