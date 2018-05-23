using Serverside.HelperLibraries;
using ServerSide;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SHSApplication.Business_Layer
{
    public class ContractProducts
    {
        private Contract contractProducts_contract;
        private Product contractProducts_product;

        public ContractProducts(Contract contractProducts_contract, Product contractProducts_product)
        {
            this.ContractProducts_Contract = contractProducts_contract;
            this.ContractProducts_Product = contractProducts_product;
        }

        public ContractProducts()
        {

        }
        public Product ContractProducts_Product
        {
            get { return contractProducts_product; }
            set { contractProducts_product = value; }
        }


        public Contract ContractProducts_Contract
        {
            get { return contractProducts_contract; }
            set { contractProducts_contract = value; }
        }

        public override bool Equals(object obj)
        {
            if (obj==null)
            {
                return false;
            }

            ContractProducts cp = obj as ContractProducts;
            if ((object)cp==null)
            {
                return false;
            }
            return (this.ContractProducts_Contract==cp.ContractProducts_Contract)&&(this.ContractProducts_Product==cp.ContractProducts_Product);
        }

        public override int GetHashCode()
        {
            return this.ContractProducts_Contract.GetHashCode()^this.ContractProducts_Product.GetHashCode();
        }

        public override string ToString()
        {
            return base.ToString();
        }

        public bool InsertContractProduct()
        {
            Datahandler dh = Datahandler.getData();
            Dictionary<string, string[]> clientProd_details = new Dictionary<string, string[]>();

            clientProd_details.Add(DataAccesHelper.cpContractId, new string[] { DataAccesHelper.typeString, this.ContractProducts_Contract.ContractIdentifier});
            clientProd_details.Add(DataAccesHelper.cpProductSerial, new string[] { DataAccesHelper.typeString, this.ContractProducts_Product.ProductSerialNr });

            return dh.runQuery(DataAccesHelper.targetContractProducts, DataAccesHelper.requestInsert, clientProd_details);
        }

        public bool RemoveContractProduct()
        {
            Datahandler dh = Datahandler.getData();
            Dictionary<string, string[]> clientProd_details = new Dictionary<string, string[]>();

            clientProd_details.Add(DataAccesHelper.cpContractId, new string[] { DataAccesHelper.typeString, this.ContractProducts_Contract.ContractIdentifier });
            clientProd_details.Add(DataAccesHelper.cpProductSerial, new string[] { DataAccesHelper.typeString, this.ContractProducts_Product.ProductSerialNr });

            return dh.runQuery(DataAccesHelper.targetContractProducts, DataAccesHelper.requestDelete, clientProd_details,DataAccesHelper.cpContractId+" = '"+this.ContractProducts_Contract.ContractIdentifier+"' AND "+DataAccesHelper.cpProductSerial+" = '"+this.ContractProducts_Product.ProductSerialNr+"'");
        }

        public List<ContractProducts> GetContractProducts()
        {
            Datahandler dh = Datahandler.getData();
            List<ContractProducts> clientProds = new List<ContractProducts>();
            DataTable table = dh.readDataFromDB(DataAccesHelper.QueryGetContractProducts + this.ContractProducts_Contract.ContractIdentifier);

            foreach (DataRow item in table.Rows)
            {
                ContractProducts cp = new ContractProducts();
                cp.ContractProducts_Contract = new Contract();
                cp.ContractProducts_Contract.ContractIdentifier = item[DataAccesHelper.cpContractId].ToString();
                cp.ContractProducts_Product = new Product();
                cp.ContractProducts_Product.ProductSerialNr = item[DataAccesHelper.cpProductSerial].ToString();
                clientProds.Add(cp);
            }

            return clientProds;
        }

    }
}
