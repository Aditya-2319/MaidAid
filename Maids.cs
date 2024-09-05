using System.Data;
using Microsoft.AspNetCore.Mvc.Localization;
using Microsoft.Data.SqlClient;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Driver;

namespace Miad_api.Models
{

    public class Maids
    {
       
        public int maid_Id { get; set; }
        public string maid_Name { get; set; }
        public int maid_Age { get; set; }
        public int maid_Exp { get; set; }
        public string maid_mod_no { get; set; }
        public string maid_Loc { get; set; }
        public decimal maid_Salary { get; set; }

        public string maid_Skill { get; set; }  


        public Maids(int maid_Id = 0, string maid_Name = "Default", int maid_Age = 0, int maid_Exp = 0, string maid_mod_no = "0", string maid_Loc = "Default", decimal maid_Salary = 0, string maid_Skill = null)
        {
            this.maid_Id = maid_Id;
            this.maid_Name = maid_Name;
            this.maid_Age = maid_Age;
            this.maid_Exp = maid_Exp;
            this.maid_mod_no = maid_mod_no;
            this.maid_Loc = maid_Loc;
            this.maid_Salary = maid_Salary;
            this.maid_Skill = maid_Skill;
        }
        public Maids() { }

        public static void Insert(Maids obj)
        {
            SqlConnection cn = new SqlConnection();
            cn.ConnectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=MaidDB;Integrated Security=True";
            try
            {
                cn.Open();
                SqlCommand cmdInsert = new SqlCommand();
                cmdInsert.Connection = cn;
                cmdInsert.CommandType = CommandType.Text;
                cmdInsert.CommandText = $"Insert into Maids values({obj.maid_Id},'{obj.maid_Name}',{obj.maid_Age},{obj.maid_Exp},'{obj.maid_mod_no}',{obj.maid_Salary},'{obj.maid_Loc}')";
                cmdInsert.ExecuteNonQuery();
            }
            catch (Exception ex) { throw; }
            finally { cn.Close(); }
        }

        public static void Update(Maids obj)
        {
            SqlConnection cn = new SqlConnection();
            cn.ConnectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=MaidDB;Integrated Security=True"; 
            try
            {
                cn.Open();
                SqlCommand cmdUpdate = new SqlCommand();
                cmdUpdate.Connection = cn;
                cmdUpdate.CommandType = CommandType.Text;
                cmdUpdate.CommandText = $"Update Maids set Name=@Maid_Name, Age=@Maid_Age, Exp=@Maid_Exp, Mod_no=@Maid_Mob_no, Salary=@Maid_Salary, Loc=@Maid_Loc, Skill=@Maids_Skill where Maid_id=@Maid_Id";
                cmdUpdate.Parameters.AddWithValue("@Maid_Name", obj.maid_Name);
                cmdUpdate.Parameters.AddWithValue("@Maid_Age", obj.maid_Age);
                cmdUpdate.Parameters.AddWithValue("@Maid_Exp", obj.maid_Exp);
                cmdUpdate.Parameters.AddWithValue("@Maid_Mod_no", obj.maid_mod_no);
                cmdUpdate.Parameters.AddWithValue("@Maid_Salary", obj.maid_Salary);
                cmdUpdate.Parameters.AddWithValue("@Maid_Loc", obj.maid_Loc);
                cmdUpdate.Parameters.AddWithValue("@Maids_Skill", obj.maid_Skill);
                cmdUpdate.ExecuteNonQuery();
            }
            catch (Exception ex) { throw; }
            finally { cn.Close(); }
        }
        public static void Delete(Maids obj)
        {
            SqlConnection cn = new SqlConnection();
            cn.ConnectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=MaidDB;Integrated Security=True";
            try
            {
                cn.Open();
                SqlCommand cmdDelete = new SqlCommand();
                cmdDelete.Connection = cn;
                cmdDelete.CommandType = CommandType.Text;
                cmdDelete.CommandText = "Delete Maids where Maid_id=@Maid_Id";
                cmdDelete.Parameters.AddWithValue("@Maid_Id", obj);

            }
            catch (Exception ex) { throw; }
            finally { cn.Close(); }
        }
        public static Maids GetMaidbyId(int maid_id)
        {
            Maids maids = new Maids();
            SqlConnection cn = new SqlConnection();
            cn.ConnectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=MaidDB;Integrated Security=True";
            try
            {
                cn.Open();
                SqlCommand cmdGet = new SqlCommand();
                cmdGet.Connection = cn;
                cmdGet.CommandType = CommandType.Text;
                cmdGet.CommandText = "Select * from Maids";

                SqlDataReader reader = cmdGet.ExecuteReader();
                while (reader.Read())
                {
                    if ((int)reader[0] == maid_id)
                    {
                        maids.maid_Id = (int)reader[0];
                        maids.maid_Name = (string)reader[1];
                        maids.maid_Age = (int)reader[2];
                        maids.maid_Exp = (int)reader[3];
                        maids.maid_mod_no = (string)reader[4];
                        maids.maid_Salary = (int)reader[5];
                        maids.maid_Loc = (string)reader[6];
                        maids.maid_Skill = (string)reader[7];
                    }
                }
            }
            catch (Exception ex) { throw; }
            finally { cn.Close(); }
            return maids;
        }

        public static List<Maids> GetAllMaids()
        {
            List<Maids> values = new List<Maids>();
            SqlConnection cn = new SqlConnection();
            cn.ConnectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=MaidDB;Integrated Security=True";
            try
            {
                cn.Open();
                SqlCommand getAll = new SqlCommand();
                getAll.Connection = cn;
                getAll.CommandType = CommandType.Text;
                getAll.CommandText = "Select * from Maids";
                SqlDataReader reader = getAll.ExecuteReader();
                while (reader.Read())
                {
                    values.Add(new Maids((int)reader[0], (string)reader[1], (int)reader[2], (int)reader[3],
                        (string)reader[4], (string)reader[5], (int)reader[6], (string)reader[7]));
                }

            }
            catch (Exception ex) { throw; }
            finally { cn.Close(); }
            return values;
        }
        public static List<Maids> GetMaidbyLoc(string maid_Loc)
        {
            List<Maids> values = new List<Maids>();
            SqlConnection cn = new SqlConnection();
            cn.ConnectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=MaidDB;Integrated Security=True";
            try 
            {
                cn.Open();
                SqlCommand getbyLoc = new SqlCommand();
                getbyLoc.Connection = cn;
                getbyLoc.CommandType = CommandType.Text;
                getbyLoc.CommandText = $"Select * from Maids where Loc=@Maids_Loc";
                SqlDataReader reader = getbyLoc.ExecuteReader();
                
            }
            catch (Exception ex) { throw; }
            finally { cn.Close(); }
            return values;
        }

        public static List<Maids> GetMaidByAge(int maid_Age)
        {
            List<Maids> values = new List<Maids>();
            SqlConnection cn = new SqlConnection();
            cn.ConnectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=MaidDB;Integrated Security=True";
            try 
            {
                cn.Open();
                SqlCommand getbyAge = new SqlCommand();
                getbyAge.Connection = cn;
                getbyAge .CommandType = CommandType.Text;
                getbyAge.CommandText = $"Select * from Maids where Age=@Maids_Age ";
                SqlDataReader reader= getbyAge.ExecuteReader();
            }
            catch (Exception ex) { throw; }
            finally { cn.Close(); }
            return values;
        }

        public static List<Maids> GetMaidsbySal(decimal maid_Salary)
        {
            List<Maids> maids = new List<Maids>();
            SqlConnection cn = new SqlConnection();
            cn.ConnectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=MaidDB;Integrated Security=True"; 
            try
            {
                cn.Open();
                SqlCommand getbySal = new SqlCommand();
                getbySal.Connection = cn;
                getbySal .CommandType = CommandType.Text;
                getbySal.CommandText = $"Select * from Maids where Salary =@maids_Salary";
                SqlDataReader reader = getbySal.ExecuteReader();


            }
            catch (Exception ex) { throw; }
            finally { cn.Close(); }
            return maids;
        }

        public static List<Maids> GetMaidByExp(int maid_Exp)
        {
            List<Maids> maids = new List<Maids>();
            SqlConnection cn = new SqlConnection();
            cn.ConnectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=MaidDB;Integrated Security=True";
            try
            {
                cn.Open();
                SqlCommand getbyExp = new SqlCommand();
                getbyExp .Connection = cn;
                getbyExp.CommandType = CommandType.Text;
                getbyExp.CommandText = $"Select *  from Maids where Exp=@Maids_Exp";
                SqlDataReader reader = getbyExp.ExecuteReader();

            }
            catch (Exception ex) { throw; }
            finally { cn.Close(); }
            return maids;
        }
        public static List<Maids> GetMaidBySkill()
        {
            List<Maids> maids = new List<Maids>();
            SqlConnection cn = new SqlConnection();
            cn.ConnectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=MaidDB;Integrated Security=True";
            try 
            {
                cn.Open (); 
                SqlCommand getbySkill = new SqlCommand();
                getbySkill .Connection = cn;
                getbySkill.CommandType = CommandType.Text;
                getbySkill.CommandText = $"select * from Maids where Skill=@Maids_Skill";
                SqlDataReader reader = getbySkill.ExecuteReader();  
            }
            catch (Exception ex) { throw; }
            finally { cn.Close(); }
            return maids;

        }
    }
}
