using StudentAPI.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace StudentAPI.Controllers
{
    public class StudentController : ApiController
    {
        // GET api/<controller>
        // decalre sql connection and command object there
        private SqlConnection _conn;
        private SqlDataAdapter _adapter;
        public IEnumerable<Student> Get()
        {
            _conn = new SqlConnection("Data Source=.;Initial Catalog=Store;Integrated Security=True");
            DataTable _dt = new DataTable();
            var query = "Select * from student";
            _adapter = new SqlDataAdapter
            {
                SelectCommand = new SqlCommand(query, _conn)

            };
            _adapter.Fill(_dt);
            List<Student> students = new List<Models.Student>(_dt.Rows.Count);
            if (_dt.Rows.Count > 0)
            {
                foreach(DataRow studentrecord in _dt.Rows)
                {
                    students.Add(new ReadStudent(studentrecord));
                }
            }
            return students;
        }

        // GET api/<controller>/5
        public IEnumerable<Student> Get(int id)
        {

            _conn = new SqlConnection("Data Source=.;Initial Catalog=Store;Integrated Security=True");
            DataTable _dt = new DataTable();
            var query = "Select * from student where Id =" + id;
            _adapter = new SqlDataAdapter
            {
                SelectCommand = new SqlCommand(query, _conn)

            };
            _adapter.Fill(_dt);
            List<Student> students = new List<Models.Student>(_dt.Rows.Count);
            if (_dt.Rows.Count > 0)
            {
                foreach (DataRow studentrecord in _dt.Rows)
                {
                    students.Add(new ReadStudent(studentrecord));
                }
            }
            return students;
        }

        // POST api/<controller>
        public string Post([FromBody]createStudent value)
        {
            _conn = new SqlConnection("Data Source=.;Initial Catalog=Store;Integrated Security=True");

            var query = "insert into student (f_name, m_name, l_name, address, birthdate, score) values(@f_name, @m_name, @l_name, @address, @birthDate, @score)";
            SqlCommand insertCommand = new SqlCommand(query, _conn);
            insertCommand.Parameters.AddWithValue("@f_name",value.f_name);
            insertCommand.Parameters.AddWithValue("@m_name",value.m_name);
            insertCommand.Parameters.AddWithValue("@l_name",value.l_name);
            insertCommand.Parameters.AddWithValue("@address",value.address);
            insertCommand.Parameters.AddWithValue("@birthdate",value.birthDate);
            insertCommand.Parameters.AddWithValue("@score",value.score);

            _conn.Open();
            int result = insertCommand.ExecuteNonQuery();
            if (result > 0)
            {
                return "true";
            }
            else
            {
                return "false";
            }
        }

        // PUT api/<controller>/5
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<controller>/5
        public void Delete(int id)
        {
        }
    }
}