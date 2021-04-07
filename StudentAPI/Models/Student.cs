using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace StudentAPI.Models
{
    public class Student
    {
        //define all the properties of the table with get and set
        
    }
    //will create a class to create an object of student class
    public class createStudent : Student
    {
        public int Id { get; set; }
        public string f_name { get; set; }
        public string m_name { get; set; }
        public string l_name { get; set; }
        public string address { get; set; }
        public string birthDate { get; set; }
        public string score { get; set; }
        public string dep_id { get; set; }
    }
    public class ReadStudent : Student
    {
        public ReadStudent(DataRow row)
        {
            Id = Convert.ToInt32(row["id"]);
            f_name = row["f_name"].ToString();
            m_name = row["m_name"].ToString();
            l_name = row["l_name"].ToString();
            address = row["address"].ToString();
            birthDate = row["birthdate"].ToString();
            score = row["score"].ToString();
        }

        public int Id { get; set; }
        public string f_name { get; set; }
        public string m_name { get; set; }
        public string l_name { get; set; }
        public string address { get; set; }
        public string birthDate { get; set; }
        public string score { get; set; }
        public string dep_id { get; set; }
    }

}