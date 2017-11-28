using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace jQueryAutocomplete
{
    public partial class _default : System.Web.UI.Page
    {
        protected void test(object sender, EventArgs e)
        {
            string t;

            t = txtCountry.Text;
            string lastWord = t.Substring(t.LastIndexOf(' ') + 1);
            var i = 1;


            SqlConnection cnn = new SqlConnection();
            cnn.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["QA_Zak_TestConnectionString"].ConnectionString;
            cnn.Open();

            var sql = "";
            sql = sql + "SELECT person.gender as gender,person.person_code as person_code, person.person_name as pn, person.d_o_b as dob, person.ni_number as ni, person.d_o_d as dod, premise.postcode as postcode, premise.name as nm, premise.street as street, premise.town as town, person.telephone as tel,person_types.Person_type as pt FROM premise LEFT JOIN person on premise.premcode = person.premcode left join person_types on person.person_type = person_types.Person_type where person.person_code='" + lastWord + "'";

            using (SqlCommand cmd =
           new SqlCommand(sql, cnn))
            {
                SqlDataReader reader = cmd.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        PersCode.Text = reader["person_code"] as string;
                        HttpContext.Current.Session["Id"] = PersCode.Text;

                        PatName.Text = reader["pn"] as string;
                        HttpContext.Current.Session["Name"] = PatName.Text;

                        if (!(reader["dob"] is DBNull))
                        {
                            d_o_b.Text = Convert.ToDateTime(reader["dob"]).ToString("dd/MM/yyyy");
                        }
                        ni_no.Text = reader["ni"] as string;

                        if (!(reader["dod"] is DBNull))
                        {
                            d_o_d.Text = Convert.ToDateTime(reader["dod"]).ToString("dd/MM/yyyy");
                        }

                        postcode.Text = reader["postcode"] as string;
                        name.Text = reader["nm"] as string;
                        street.Text = reader["street"] as string;
                        town.Text = reader["town"] as string;
                        telephone.Text = reader["tel"] as string;


                        person_type.Text = reader["pt"] as string;
                        switch (person_type.Text)
                        {
                            case "G":
                                person_type.Text = "GP";
                                break;
                            case "I":
                                person_type.Text = "Nurse Assessor";
                                break;
                            case "O":
                                person_type.Text = "Owner";
                                break;
                            case "P":
                                person_type.Text = "Patient";
                                break;
                            case "R":
                                person_type.Text = "Relative";
                                break;
                            case "W":
                                person_type.Text = "Social Worker";
                                break;
                            default:
                                break;
                        }

                        gender.Text = reader["gender"] as string;
                        switch (gender.Text)
                        {
                            case "M":
                                gender.Text = "Male";
                                break;
                            case "F":
                                gender.Text = "Female";
                                break;
                            default:
                                break;
                        }
                    }
                }

                reader.Close();
            }


        }




        protected void Page_Load(object sender, EventArgs e)
        {

        }





        [WebMethod]
        public static string[] GetCountryNames(string keyword)
        {
            List<string> empt = new List<string>();
            List<string> country = new List<string>();
            string query = string.Format("SELECT person_name,person_code FROM person WHERE (person_name LIKE '%{0}%' or person_code LIKE '%{0}%')", keyword);

            using (SqlConnection con =
                    new SqlConnection("Data Source=BCCG-DB01;Initial Catalog=QA_Zak_Test;Integrated Security=True"))
            {
                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    con.Open();
                    SqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        country.Add(reader.GetString(0) + " " + reader.GetString(1));
                    }
                }
            }
            if (country.ToArray().Length < 200)
            {
                return country.ToArray();
            }
            else
            { return empt.ToArray(); }
        }
    }
}