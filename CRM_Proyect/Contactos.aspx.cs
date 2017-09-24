using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CRM_Proyect
{
    public partial class Contactos : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        public void codigoContactos()
        {
            string codigoParaContacto = "<div class='col-md-4'>"
                + "<div class='box box-primary'>"
                + "<div class='box-body box-profile'>"
                + "<img class='profile-user-img img-responsive img-circle' src = '../../dist/img/user4-128x128.jpg' alt='User profile picture'>"
                + "<h3 class='profile-username text-center'>Nina Mcintire</h3>"

                + "<p class='text-muted text-center'>Software Engineer</p>"

                + "<ul class='list-group list-group-unbordered'>"
                + "<li class='list-group-item'>"
                + "<b>Followers</b> <a class='pull-right'>1,322</a>"
                + "</li>"
                + "<li class='list-group-item'>"
                + "<b>Following</b> <a class='pull-right'>543</a>"
                + "</li>"
                + "<li class='list-group-item'>"
                + "<b>Friends</b> <a class='pull-right'>13,287</a>"
                + "</li>"
                + "</ul>"

                + "<a href = '#' class='btn btn-primary btn-block'><b>Follow</b></a>"
                + "</div>"
                + "</div>";

           Response.Write(codigoParaContacto);
        }
    }

    
}