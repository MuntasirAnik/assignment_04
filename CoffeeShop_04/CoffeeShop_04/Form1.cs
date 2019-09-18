using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CoffeeShop_04
{
    public partial class Form1 : Form
    {
        List<string> names = new List<string> { };
        List<string> contacts = new List<string> { };
        List<string> addresses = new List<string> { };
        List<string> orders = new List<string> { };
        List<int> quantities = new List<int> { };
        List<int> prices = new List<int> { };

        int price = 0;
    
        public Form1()
        {
            InitializeComponent();
        }
               
        private void addButton_Click(object sender, EventArgs e)
        {
            if(nameTextBox.Text == "" || contactTextBox.Text == "" || addressTextBox.Text =="")
            {
                MessageBox.Show("please enter your information...");
            }
            else
            {
                if(itemComboBox.Text == "Select item")
                {
                    MessageBox.Show("select an item...");
                }
                else
                {
                    
                    if (quantityTextBox.Text == "")
                        {
                            MessageBox.Show("enter quantity...");
                        }
                    else
                    {
                        foreach (string contact in contacts)
                        {
                            if (contact == contactTextBox.Text)
                            {
                                MessageBox.Show("Contact number should be different");
                                return;
                            }

                        }
                        switch (itemComboBox.Text)
                        {
                        
                            case "Black-120":
                                  price = 120;
                                  break;
                            case "Cold-100":
                                  price = 100;
                                  break;
                            case "Hot-90":
                                  price = 90;
                                  break;
                            case "Regular-60":
                                  price = 60;
                                  break;
                        }
                        price = Convert.ToInt32(quantityTextBox.Text) *price;                                                          
                        AddCustomer(nameTextBox.Text, contactTextBox.Text, addressTextBox.Text, itemComboBox.Text, Convert.ToInt32(quantityTextBox.Text),price);
                        ViewCurrentOrder(nameTextBox.Text, contactTextBox.Text, addressTextBox.Text, itemComboBox.Text, Convert.ToInt32(quantityTextBox.Text), price);
                        price = 0;                                                     
                    }                                       
                }
            }            
        }
        private void showButton_Click(object sender, EventArgs e)
        {
            FullPurchaseList();
        }
        private void AddCustomer(string name, string mobile, string address, string order, int quantity,int price)
        {
            names.Add(name);
            contacts.Add(mobile);
            addresses.Add(address);
            orders.Add(order);
            quantities.Add(quantity);
            prices.Add(price);
        }
        private void ViewCurrentOrder(string name, string mobile, string address, string order, int quantity, int price)
        {            
            orderListRichTextBox.Text = "name:\t" + name + "\nMobile:\t" + mobile + "\nAddress:\t" + address + "\nOrder;\t" + order + "\nQuantity:\t" + quantity + "\nPrice:\t" + price+"\n----------------------------------\n";
            nameTextBox.Text = "";
            contactTextBox.Text = "";
            addressTextBox.Text = "";
            itemComboBox.Text = "";
            quantityTextBox.Text = "";
        }
        private void FullPurchaseList()
        {
            orderListRichTextBox.Text="";
            string message = "";
            for (int i=0; i< names.Count();i++)
            {
                message += "name:\t" + names[i ]+ "\nMobile:\t" + contacts[i] + "\nAddress:\t" + addresses[i] + "\nOrder;\t" + orders[i] + "\nQuantity:\t" + quantities[i] + "\nPrice:\t" + prices[i]+"\n-------------------------------\n";                
            }
            orderListRichTextBox.Text += message;
        }
       
    }
}
