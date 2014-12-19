using System.Web.Mvc;

namespace CodeFirst1.Areas.TestBookiArea
{
    public class TestBookiAreaAreaRegistration : AreaRegistration 
    {
        public override string AreaName 
        {
            get 
            {
                return "TestBookiArea";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context) 
        {
            context.MapRoute(
                "TestBookiArea_default",
                "TestBookiArea/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}