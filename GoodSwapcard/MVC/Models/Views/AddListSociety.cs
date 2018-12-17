using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVC.Models.Views
{
    public class AddListSociety
    {
        public List<Society> listSociety { get; set; }
        public AddSociety ajoutSociety { get; set; }

        public AddListSociety()
        {
            ajoutSociety = new AddSociety();
        }
    }
}