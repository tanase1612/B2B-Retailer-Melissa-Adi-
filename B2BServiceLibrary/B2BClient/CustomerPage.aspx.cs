using B2BClient.CustomerServiceReference;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace B2BClient
{
    public partial class CustomerPage : System.Web.UI.Page
    {
        CustomerServiceClient client = new CustomerServiceReference.CustomerServiceClient();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                bind(client);
            }
        }

        private void bind(CustomerServiceClient client)
        {
            try
            {
                gvCustomer.DataSource = client.GetCustomers();
                dvSelectedCustomer.DataSource = "";
                dvSelectedCustomer.DataBind();
                gvCustomer.DataBind();
            }
            catch (System.ServiceModel.FaultException<ServiceFault> ex)
            {

                lblError.Text = ex.Detail.OperationName + ":" + ex.Detail.ExceptopMessage;
            }
            finally
            {
                client.Close();
            }
        }

        protected void gvCustomers_SelectedIndexChanged(object sender, EventArgs e)
        {
            int selectedId = int.Parse(gvCustomer.SelectedValue.ToString());
            CustomerServiceClient client = new CustomerServiceClient();
            try
            {
                List<Customer> customers = new List<Customer>();
                Customer c = client.GetCustomer(selectedId);
                customers.Add(c);

                dvSelectedCustomer.DataSource = customers;
                dvSelectedCustomer.DataBind();
            }
            catch (System.ServiceModel.FaultException<ServiceFault> ex)
            {
                lblError.Text = ex.Detail.OperationName + ": " + ex.Detail.ExceptopMessage;
            }
            finally
            {
                client.Close();
            }
        }

        protected void gvCustomer_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            int selectedId = (int)gvCustomer.DataKeys[e.RowIndex].Value;
            CustomerServiceClient client = new CustomerServiceClient();
            try
            {
                client.DeleteCustomer(selectedId);
                bind(client);
                Response.Write("<script>alert('delete success!');</script>");
            }
            catch (System.ServiceModel.FaultException<ServiceFault> ex)
            {
                lblError.Text = ex.Detail.OperationName + ": " + ex.Detail.ExceptopMessage;
            }
            finally
            {
                client.Close();
            }
        }

        protected void gvCustomer_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            int selectedId = (int)gvCustomer.DataKeys[e.RowIndex].Value;
            CustomerServiceClient client = new CustomerServiceClient();
            try
            {
                Customer c = new Customer();
                c.Id = selectedId;
                c.Billing = Convert.ToInt32(e.NewValues[0].ToString());
                c.CompanyName = e.NewValues[1].ToString();
                c.EmailAddress = e.NewValues[2].ToString();
                c.PhoneNumber = Convert.ToInt32(e.NewValues[3].ToString());
                c.ShippingAddress = e.NewValues[4].ToString();

                client.UpdateCustomer(c);
                gvCustomer.EditIndex = -1;
                bind(client);
                Response.Write("<script>alert('edit success!');</script>");
            }
            catch (System.ServiceModel.FaultException<ServiceFault> ex)
            {
                lblError.Text = ex.Detail.OperationName + ": " + ex.Detail.ExceptopMessage;
            }
            finally
            {
                client.Close();
            }
        }

        protected void gvCustomer_RowEditing(object sender, GridViewEditEventArgs e)
        {
            gvCustomer.EditIndex = e.NewEditIndex;
            bind(client);
        }

        protected void gvCustomer_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            gvCustomer.EditIndex = -1;
            bind(client);
        }

        protected void btnAddCustomer_Click(object sender, EventArgs e)
        {
            addCustomer.Style["Display"] = "Block";
        }

        protected void btSubmit_Click(object sender, EventArgs e)
        {
            Customer cust = new Customer();
            cust.Billing = Convert.ToInt32(tbBilling.Text);
            cust.PhoneNumber = Convert.ToInt32(tbPhoneNumber.Text);
            cust.ShippingAddress = tbShippingAddress.Text;
            cust.CompanyName = tbCompanyName.Text;
            cust.EmailAddress = tbEmailAddress.Text;
            client.AddCustomer(cust);
            clearTxt();
            addCustomer.Style["Display"] = "None";
            bind(client);
        }

        private void clearTxt()
        {
            tbBilling.Text = null;
            tbPhoneNumber.Text = null;
            tbShippingAddress.Text = null;
            tbCompanyName.Text = null;
            tbEmailAddress.Text = null;
        }

        protected void btCancle_Click(object sender, EventArgs e)
        {
            clearTxt();
            addCustomer.Style["Display"] = "None";
            bind(client);
        }
    }
}