using System.Collections.Generic;
using System.Web.Mvc;
using System.Xml;

public class HomeController : Controller
{
    public ActionResult Index()
    {
        string defaultFirstItem = "Select Item";
        string xmlFilePath = Server.MapPath("~/App_Data/example.xml");

        List<SelectListItem> dropdownItems = new List<SelectListItem>();
        PopulateDropDownFromXml(dropdownItems, defaultFirstItem, xmlFilePath);  // Populate dropdown from XML file
        ViewBag.DropDownItems = dropdownItems;
        return View();
    }

    // custom function
    private void PopulateDropDownFromXml(List<SelectListItem> dropDownList, string defaultFirstItem, string xmlFilePath)
    {
        dropDownList.Clear();
        dropDownList.Add(new SelectListItem { Text = defaultFirstItem, Value = "" });
        XmlDocument xmlDoc = new XmlDocument();
        xmlDoc.Load(xmlFilePath);
        XmlNodeList nodes = xmlDoc.SelectNodes("//name");

        foreach (XmlNode node in nodes)
        {
            dropDownList.Add(new SelectListItem { Text = node.InnerText, Value = node.InnerText });
        }  
    }
}
