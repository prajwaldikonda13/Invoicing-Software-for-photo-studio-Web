using System.Collections.Generic;
using System.Linq;
using VivaBillingNewWeb.Database;

namespace VivaBillingNewWeb
{
    public static class Initializer
    {
        static DBConnection dBConnection = new DBConnection();
        public static List<States> states { get; set; }
        public static List<Countries> countries { get; set; }
        public static List<Customers> customers { get; set; }
        public static List<Sizes> sizes { get; set; }
        public static List<Products> products { get; set; }
        public static List<PaymentMethods> paymentMethods { get; set; }
        public static List<ProductTypes> productTypes { get; set; }
        public static List<Jobs> jobs { get; set; }
        public static List<Prices> prices { get; set; }
        public static List<Invoices> invoices { get; set; }
        public static List<EmailVerifications> emailVerifications { get; set; }
        public static List<MobileVerifications> mobileVerifications { get; set; }
        public static List<Logins> logins { get; set; }
        public static List<Commands> commands { get; set; }
        public static List<DailyCount> dailyCount { get; set; }
        public static List<MacAddresses> macAddresses { get; set; }
        public static void getUpdatedLists(string nameOfList)
        {

            if (nameOfList == "all")
            {
                jobs = dBConnection.jobs.ToList();
                prices = dBConnection.prices.ToList();
                invoices = dBConnection.invoices.ToList();
                logins = dBConnection.logins.ToList();
                emailVerifications = dBConnection.emailVerifications.ToList();
                mobileVerifications = dBConnection.mobileVerifications.ToList();
                productTypes = dBConnection.productTypes.ToList();
                paymentMethods = dBConnection.paymentMethods.ToList();
                products = dBConnection.products.ToList();
                sizes = dBConnection.sizes.ToList();
                customers = dBConnection.customers.ToList();
                countries = dBConnection.countries.ToList();
                states = dBConnection.states.ToList();
                commands = dBConnection.commands.ToList();
                dailyCount = dBConnection.dailyCount.ToList();
                macAddresses = dBConnection.macAddresses.ToList();
            }
            else
            {
                switch (nameOfList)
                {
                    case "jobs":
                        jobs = dBConnection.jobs.ToList();
                        break;
                    case "prices":
                        prices = dBConnection.prices.ToList();
                        break;
                    case "invoices":
                        invoices = dBConnection.invoices.ToList();
                        break;
                    case "logins":
                        logins = dBConnection.logins.ToList();
                        break;
                    case "emailVerifications":
                        emailVerifications = dBConnection.emailVerifications.ToList();
                        break;
                    case "mobileVerifications":
                        mobileVerifications = dBConnection.mobileVerifications.ToList();
                        break;
                    case "productTypes":
                        productTypes = dBConnection.productTypes.ToList();
                        break;
                    case "paymentMethods":
                        paymentMethods = dBConnection.paymentMethods.ToList();
                        break;
                    case "products":
                        products = dBConnection.products.ToList();
                        break;
                    case "sizes":
                        sizes = dBConnection.sizes.ToList();
                        break;
                    case "customers":
                        customers = dBConnection.customers.ToList();
                        break;
                    case "countries":
                        countries = dBConnection.countries.ToList();
                        break;
                    case "states":
                        states = dBConnection.states.ToList();
                        break;
                    case "commands":
                        commands = dBConnection.commands.ToList();
                        break;
                    case "dailyCount":
                        dailyCount = dBConnection.dailyCount.ToList();
                        break;
                    case "macAddresses":
                        macAddresses = dBConnection.macAddresses.ToList();
                        break;

                }
            }

        }
    }
}