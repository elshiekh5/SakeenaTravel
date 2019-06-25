using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class _Default : System.Web.UI.Page
{
    [System.Web.Services.WebMethod]
    public static City GetCity(City city)
    {
        return city;
    }
}

public class City
{
    private string name;
    public string Name
    {
        get
        {
            return name;
        }
        set
        {
            name = value;
        }
    }

    private int population;
    public int Population
    {
        get
        {
            return population;
        }
        set
        {
            population = value;
        }
    }
}