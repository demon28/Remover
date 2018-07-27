using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Routing;

namespace Remover.WebAdmin.Models.Mvc
{
    public class WorkContext
    {
        private RequestContext _context;
        public WorkContext(RequestContext context)
        {
            this._context = context;
        }
        public string Avatar { get; set; }

        public bool IsActive(string controllersplit, string action = null)
        {
            if (_context == null || string.IsNullOrEmpty(controllersplit))
            {
                return false;
            }
            string[] controllers = null;
            if (controllersplit.Contains(','))
            {
                controllers = controllersplit.Split(',');
            }
            else
            {
                controllers = new string[] { controllersplit };
            }
            if (controllers == null || controllers.Length <= 0)
            {
                return false;
            }
            var currentController = _context.RouteData.Values["controller"] + string.Empty;
            var currentAction = _context.RouteData.Values["action"] + string.Empty;

            bool sameController = controllers.Contains(currentController, new Javirs.Common.OrdinalIgnoreCaseStringComparer());
            bool emptyAction = string.IsNullOrEmpty(action);
            bool sameAction = currentAction.Equals(action, StringComparison.OrdinalIgnoreCase);
            bool res = (sameController && emptyAction) || (sameController && !emptyAction && sameAction);
            return res;
        }

        public int? Audit_ID { get; set; }
    }
}