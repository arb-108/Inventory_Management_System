using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;

namespace Costco
{
    public class DatabaseFile
    {
        string constr = ConfigurationManager.ConnectionStrings["Costco.Properties.Settings.CostcoConnectionString"].ConnectionString;
        public DataTable comboboxData()
        {
            DataTable dt = new DataTable();
            SqlConnection conn=new SqlConnection(constr);
            using (conn)
            {
                SqlCommand cmd = new SqlCommand("usp_products", conn);
                cmd.CommandType= CommandType.StoredProcedure;
                conn.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                dt.Load(dr);
                return dt;
            }
        }
        public DataTable InventoryData()
        {
            DataTable dt = new DataTable();
            SqlConnection conn = new SqlConnection(constr);
            using (conn)
            {
                SqlCommand cmd = new SqlCommand("usp_inventoryData", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                conn.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                dt.Load(dr);
                return dt;
            }
        }
        public DataTable Emp_Data()
        {
            DataTable dt = new DataTable();
            SqlConnection conn = new SqlConnection(constr);
            using (conn)
            {
                SqlCommand cmd = new SqlCommand("usp_costcoEmployee", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                conn.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                dt.Load(dr);
                return dt;
            }
        }
        public DataTable SupplierData()
        {
            DataTable dt = new DataTable();
            SqlConnection conn = new SqlConnection(constr);
            using (conn)
            {
                SqlCommand cmd = new SqlCommand("usp_CostcoSuppliers", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                conn.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                dt.Load(dr);
                return dt;
            }
        }
        public DataTable CustomersGridData()
        {
            DataTable dt = new DataTable();
            SqlConnection conn = new SqlConnection(constr);
            using (conn)
            {
                SqlCommand cmd = new SqlCommand("usp_clients", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                conn.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                dt.Load(dr);
                return dt;
            }
        }
        public DataTable returnGridData()
        {
            DataTable dt = new DataTable();
            SqlConnection conn = new SqlConnection(constr);
            using (conn)
            {
                SqlCommand cmd = new SqlCommand("usp_returns_data_get", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                conn.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                dt.Load(dr);
                return dt;
            }
        }
        public DataTable Returns_Data(string inv)
        {
            DataTable dt = new DataTable();
            SqlConnection conn = new SqlConnection(constr);
            using (conn)
            {
                SqlCommand cmd = new SqlCommand("usp_returns_data", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                conn.Open();
                cmd.Parameters.AddWithValue("@inv", inv);
                SqlDataReader dr = cmd.ExecuteReader();
                dt.Load(dr);
                return dt;
            }
        }
        public DataTable Returns_Data_name(string inv)
        {
            DataTable dt = new DataTable();
            SqlConnection conn = new SqlConnection(constr);
            using (conn)
            {
                SqlCommand cmd = new SqlCommand("usp_returns_data_name", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                conn.Open();
                cmd.Parameters.AddWithValue("@inv", inv);
                SqlDataReader dr = cmd.ExecuteReader();
                dt.Load(dr);
                return dt;
            }
        }
        public DataTable invoice_order(string inv)
        {
            DataTable dt = new DataTable();
            SqlConnection conn = new SqlConnection(constr);
            using (conn)
            {
                SqlCommand cmd = new SqlCommand("usp_invOrders", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                conn.Open();
                cmd.Parameters.AddWithValue("@inv",inv);
                SqlDataReader dr = cmd.ExecuteReader();
                dt.Load(dr);
                return dt;
            }
        }
        public DataTable Returns_invoice_order(string inv)
        {
            DataTable dt = new DataTable();
            SqlConnection conn = new SqlConnection(constr);
            using (conn)
            {
                SqlCommand cmd = new SqlCommand("usp_return_invoices", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                conn.Open();
                cmd.Parameters.AddWithValue("@inv", inv);
                SqlDataReader dr = cmd.ExecuteReader();
                dt.Load(dr);
                return dt;
            }
        }

        public decimal FindPrice(int id)
        {
            decimal price = 0;  
            SqlConnection conn = new SqlConnection(constr);
            using (conn)
            {
                SqlCommand cmd = new SqlCommand("ucp_findprice", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                conn.Open();
                cmd.Parameters.AddWithValue("@id",id);
                price=Convert.ToDecimal(cmd.ExecuteScalar());
                
                return price;
            }
        }
        public int FindQty(int id)
        {
            int qty = 0;
            SqlConnection conn = new SqlConnection(constr);
            using (conn)
            {
                SqlCommand cmd = new SqlCommand("ucp_findqty", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                conn.Open();
                cmd.Parameters.AddWithValue("@id", id);
                qty = Convert.ToInt32(cmd.ExecuteScalar());

                return qty;
            }
        }
        public string FindInvoice_number()
        {
             string max ="";
            SqlConnection conn = new SqlConnection(constr);
            using (conn)
            {
                SqlCommand cmd = new SqlCommand("usp_invoice_number", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                conn.Open();
               
                max = cmd.ExecuteScalar().ToString();

                return max;
            }
        }
        public string Find_max_emp_id()
        {
            string max = "";
            SqlConnection conn = new SqlConnection(constr);
            using (conn)
            {
                SqlCommand cmd = new SqlCommand("usp_max_emp_id", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                conn.Open();

                max = cmd.ExecuteScalar().ToString();

                return max;
            }
        }
        public string FindSupplierID()
        {
            string max = "";
            SqlConnection conn = new SqlConnection(constr);
            using (conn)
            {
                SqlCommand cmd = new SqlCommand("usp_supplierID", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                conn.Open();

                max = cmd.ExecuteScalar().ToString();

                return max;
            }
        }
        public void orders(DataGridView dataGridView,string inv)
        {
            foreach (DataGridViewRow dr in dataGridView.Rows)
            {
                string Sr_no = dr.Cells["Sr_no"].Value.ToString();
                string id = dr.Cells["ID"].Value.ToString();
                int idint = int.Parse(dr.Cells["ID"].Value.ToString());
                string name = dr.Cells["Product_Name"].Value.ToString();
                int qty = int.Parse(dr.Cells["Quantity"].Value.ToString());
                int price = int.Parse(dr.Cells["Price"].Value.ToString());
                int total = int.Parse(dr.Cells["Total_Price"].Value.ToString());


                SqlConnection conn = new SqlConnection(constr);
                using (conn)
                {
                    SqlCommand cmd = new SqlCommand("usp_order", conn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    conn.Open();
                    cmd.Parameters.AddWithValue("@Sr_no",Sr_no);
                    cmd.Parameters.AddWithValue("@invoice_no",inv);
                    cmd.Parameters.AddWithValue("@Id",id);
                    cmd.Parameters.AddWithValue("@P_name",name);
                    cmd.Parameters.AddWithValue("@Qty",qty);
                    cmd.Parameters.AddWithValue("@Price",price);
                    cmd.Parameters.AddWithValue("@total",total);
                    cmd.Parameters.AddWithValue("@datetiming", DateTime.Now.ToString());
                    cmd.ExecuteNonQuery();
                }
                SqlConnection con = new SqlConnection(constr);
                using (con)
                {
                    SqlCommand cmdi = new SqlCommand("usp_minus_qty", con);
                    cmdi.CommandType = CommandType.StoredProcedure;
                    con.Open();
                    cmdi.Parameters.AddWithValue("@id", idint);
                    cmdi.Parameters.AddWithValue("@Qty", qty);
                    cmdi.ExecuteNonQuery();
                }
            }
        }
        public void return_invoices(DataGridView dataGridView, string inv,string rid)
        {
            foreach (DataGridViewRow dr in dataGridView.Rows)
            {
                string name = dr.Cells["Name"].Value.ToString();
                int qty = int.Parse(dr.Cells["Qty"].Value.ToString());
                int price = int.Parse(dr.Cells["Price"].Value.ToString());
                int total = int.Parse(dr.Cells["Total_Price"].Value.ToString());


                SqlConnection conn = new SqlConnection(constr);
                using (conn)
                {
                    SqlCommand cmd = new SqlCommand("usp_returns_invoices", conn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    conn.Open();
                    cmd.Parameters.AddWithValue("@r_id", rid);
                    cmd.Parameters.AddWithValue("@invoice_no", inv);
                    cmd.Parameters.AddWithValue("@P_name", name);
                    cmd.Parameters.AddWithValue("@Qty", qty);
                    cmd.Parameters.AddWithValue("@Price", price);
                    cmd.Parameters.AddWithValue("@total", total);
                    cmd.ExecuteNonQuery();
                }
                SqlConnection con= new SqlConnection(constr);
                using (con)
                {
                    SqlCommand cmd = new SqlCommand("usp_add_returns", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    con.Open();
                    cmd.Parameters.AddWithValue("@name", name);
                    cmd.Parameters.AddWithValue("@qty", qty);
                    cmd.ExecuteNonQuery();
                }
               
            }
        }
        public void customers(string name,string phone,string Address,string invoice_no,string dis,string pretotal,string tax,decimal total)
        {
                SqlConnection conn = new SqlConnection(constr);
                using (conn)
                {
                    SqlCommand cmd = new SqlCommand("usp_customer", conn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    conn.Open();
                    cmd.Parameters.AddWithValue("@Name", name);
                    cmd.Parameters.AddWithValue("@phone", phone);
                    cmd.Parameters.AddWithValue("@Address", Address);
                    cmd.Parameters.AddWithValue("@invoice_no", invoice_no);
                    cmd.Parameters.AddWithValue("@dis", dis);
                    cmd.Parameters.AddWithValue("@pretotal", pretotal);
                    cmd.Parameters.AddWithValue("@tax", tax);
                    cmd.Parameters.AddWithValue("@total", total);
                    cmd.Parameters.AddWithValue("@datetiming",DateTime.Now.ToString());
                cmd.ExecuteNonQuery();
                }
        }
        public void returns_customers(string rid,string invoice_no,string name, decimal total)
        {
            SqlConnection conn = new SqlConnection(constr);
            using (conn)
            {
                SqlCommand cmd = new SqlCommand("usp_returns_customers", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                conn.Open();
                cmd.Parameters.AddWithValue("@rid", rid);
                cmd.Parameters.AddWithValue("@invoice_no", invoice_no);
                cmd.Parameters.AddWithValue("@Name", name);
                cmd.Parameters.AddWithValue("@total", total);
                cmd.Parameters.AddWithValue("@datetiming", DateTime.Now.ToString());
                cmd.ExecuteNonQuery();
            }
        }
        public void addemp(int id, string name,string  job,string  dept,string phone,int salary,string hiredate,string email, byte[] photo)
        {
            SqlConnection conn = new SqlConnection(constr);
            using (conn)
            {
                SqlCommand cmd = new SqlCommand("usp_add_emp", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                conn.Open();
                cmd.Parameters.AddWithValue("@ID", id);
                cmd.Parameters.AddWithValue("@Name", name);
                cmd.Parameters.AddWithValue("@Job", job);
                cmd.Parameters.AddWithValue("@Phone", phone);
                cmd.Parameters.AddWithValue("@deptno", dept);
                cmd.Parameters.AddWithValue("@Email", email);
                cmd.Parameters.AddWithValue("@HireDate", hiredate);
                cmd.Parameters.AddWithValue("@Salary",salary);
                cmd.Parameters.AddWithValue("@photo", photo);
                cmd.ExecuteNonQuery();
            }
        }

        public bool verifyId(int id)
        {
            bool check;
            SqlConnection conn = new SqlConnection(constr);
            using (conn)
            {
                SqlCommand cmd = new SqlCommand("ucp_cheakID", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                conn.Open();
                cmd.Parameters.AddWithValue("@id", id);
                 check= Convert.ToBoolean(cmd.ExecuteScalar());
                if (check == false)
                {
                    return false;
                }
                else
                {
                    return true;
                }
            }

        }
        public bool verifySupplierId(string id)
        {
            bool check;
            SqlConnection conn = new SqlConnection(constr);
            using (conn)
            {
                SqlCommand cmd = new SqlCommand("ucp_cheakSupplierID", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                conn.Open();
                cmd.Parameters.AddWithValue("@id", id);
                check = Convert.ToBoolean(cmd.ExecuteScalar());
                if (check == false)
                {
                    return false;
                }
                else
                {
                    return true;
                }
            }

        }
        public void AddProduct(int id,string category, string name, decimal price,int qty)
        {
            SqlConnection conn = new SqlConnection(constr);
            using (conn)
            {
                SqlCommand cmd = new SqlCommand("usp_addnewproduct", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                conn.Open();
                cmd.Parameters.AddWithValue("@id", id);
                cmd.Parameters.AddWithValue("@category", category);
                cmd.Parameters.AddWithValue("@Name", name);
                cmd.Parameters.AddWithValue("@Price", price);
                cmd.Parameters.AddWithValue("@Qty", qty);
                cmd.ExecuteNonQuery();
            }
        }
        public void AddSupplier(string id,string company,string name, string category, string email, string phone, string address)
        {
            SqlConnection conn = new SqlConnection(constr);
            using (conn)
            {
                SqlCommand cmd = new SqlCommand("usp_add_supplier", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                conn.Open();
                cmd.Parameters.AddWithValue("@ID", id);
                cmd.Parameters.AddWithValue("@Company_Name", company);
                cmd.Parameters.AddWithValue("@Supplier_s_Name", name);
                cmd.Parameters.AddWithValue("@Category", category);
                cmd.Parameters.AddWithValue("@Emails", email);
                cmd.Parameters.AddWithValue("@Phone_no", phone);
                cmd.Parameters.AddWithValue("@Address", address);
                cmd.ExecuteNonQuery();
            }
        }
        public void Editqty(int id,int qty)
        {
            SqlConnection conn = new SqlConnection(constr);
            using (conn)
            {
                SqlCommand cmd = new SqlCommand("ucp_editqty", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                conn.Open();
                cmd.Parameters.AddWithValue("@id", id);
                cmd.Parameters.AddWithValue("@Qty", qty);
                cmd.ExecuteNonQuery();
            }
        }
        public void deleteproduct(int id)
        {
            SqlConnection conn = new SqlConnection(constr);
            using (conn)
            {
                SqlCommand cmd = new SqlCommand("ucp_deleteproduct", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                conn.Open();
                cmd.Parameters.AddWithValue("@id", id);
                cmd.ExecuteNonQuery();
            }
        }
        public void deleteemp(int id)
        {
            SqlConnection conn = new SqlConnection(constr);
            using (conn)
            {
                SqlCommand cmd = new SqlCommand("usp_delete_emp", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                conn.Open();
                cmd.Parameters.AddWithValue("@id", id);
                cmd.ExecuteNonQuery();
            }
        }

        public void deleteSupplier(string id)
        {
            SqlConnection conn = new SqlConnection(constr);
            using (conn)
            {
                SqlCommand cmd = new SqlCommand("usp_delete_supplier", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                conn.Open();
                cmd.Parameters.AddWithValue("@id", id);
                cmd.ExecuteNonQuery();
            }
        }
        public bool check_login(string username,string password)
        {
            bool check;
            SqlConnection conn = new SqlConnection(constr);
            using (conn)
            {
                SqlCommand cmd = new SqlCommand("usp_login_check", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                conn.Open();
                cmd.Parameters.AddWithValue("@username", username);
                cmd.Parameters.AddWithValue("@password", password);
                check = Convert.ToBoolean(cmd.ExecuteScalar());
                if (check == false)
                {
                    return false;
                }
                else
                {
                    return true;
                }
            }

        }


    }
}
