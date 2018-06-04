using SHSApplication.Business_Layer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IronPdf;

namespace SHSApplication.Helper_Libraries
{
    public static class PdfWriter
    {
        public static void CreateCallHistoryPdf(Client c, List<CallLog> cl)
        {
            var Renderer = new IronPdf.HtmlToPdf();
            var HtmlData = @"<html><head>
                            <style>
                               h1{font-family: 'Copperplate Gothic Bold';font-size: 24pt}
                               h2{font-family: 'Century Gothic';font-size:16pt}
                               h3{font-family: 'Century Gothic';font-size:12pt}
                               table{width: 100%;font-family: 'Century Gothic'}
                               #heading{font-weight: bold}
                            </style>
                            </head><body>";
            HtmlData += string.Format("<header><h1 align='center'>Smart Home Systems</h1><h2 align = 'center'>{0} {1}({2})</h2><h2 align = 'center'>Call History:</h2>",c.Name,c.Surname,c.ClientIdentifier);
            HtmlData += string.Format("<h3>{0}</h3></header>",DateTime.UtcNow.ToShortDateString());
            HtmlData += @"<table border='1px solid white'>
                            <tr id='heading'>
                                <td>Date:</td>
                                <td>Time:</td>
                                <td>Call Operator:</td>
                                <td>Remarks:</td>
                            </tr>";
            foreach (CallLog item in cl)
            {
                HtmlData += string.Format(@"<tr>
                                <td>{0}</td>
                                <td>{1}</td>
                                <td>{2}</td>
                                <td>{3}</td>
                            </tr>", item.StartTime.ToShortDateString(),item.StartTime.ToShortTimeString(),item.LogOperator.Name +" "+item.LogOperator.Surname,item.Remarks);
            }
            HtmlData += "</table></body></html>";
            var Pdf = Renderer.RenderHtmlAsPdf(HtmlData);
            var OutputPath = c.ClientIdentifier+DateTime.UtcNow.Year.ToString()+"_"+DateTime.UtcNow.Month.ToString()+"_"+DateTime.UtcNow.Day.ToString()+"_CallHistory.pdf";
            Pdf.SaveAs(OutputPath);
            
            System.Diagnostics.Process.Start(OutputPath);
        }

        public static void CreateClientContractPdf(Client c,Contract contract, List<Product> products,List<SystemComponents> comps,List<Configurations> confs)
        {
            var Renderer = new IronPdf.HtmlToPdf();
            var HtmlData = @"<html><head>
                            <style>
                               h1{font-family: 'Copperplate Gothic Bold';font-size: 24pt}
                               h2{font-family: 'Century Gothic';font-size:16pt}
                               h3{font-family: 'Century Gothic';font-size:12pt}
                               table{width: 100%;font-family: 'Century Gothic'}
                               #heading{font-weight: bold}
                            </style>
                            </head><body>";
            HtmlData += string.Format("<header><h1 align='center'>Smart Home Systems</h1><h2 align = 'center'>{0} {1}({2})</h2><h2 align = 'center'>Contract:</h2>", c.Name, c.Surname, c.ClientIdentifier);
            HtmlData += string.Format(@"<h3>Date of Issue:{0}</h3>
                                        <h3>Term:{1} Months</h3>
                                        <h3>Service Level:{2}</h3></header>", contract.DateOfIssue.ToShortDateString(),contract.TermDuration.ToString(),contract.SLevel.Level);
            HtmlData += string.Format("<h3 align='center'>{0}</h3></header>", DateTime.UtcNow.ToShortDateString());
            HtmlData += "<h3>Products</h3></header>";
            HtmlData += @"<table border='1px solid white'>
                            <tr id='heading'>
                                <td>Product Code:</td>
                                <td>Name:</td>
                                <td>Description Operator:</td>
                                <td>Base Price:</td>
                            </tr>";
            foreach (Product item in products)
            {
                HtmlData += string.Format(@"<tr>
                                <td>{0}</td>
                                <td>{1}</td>
                                <td>{2}</td>
                                <td>R{3}</td>
                            </tr>", item.ProductCode, item.Name, item.Description, item.BasePrice.ToString());
            }
            HtmlData += "</table></br>";
            HtmlData += "<h3>Components</h3></header>";
            HtmlData += @"<table border='1px solid white'>
                            <tr id='heading'>
                                <td>Component Code:</td>
                                <td>Product Code:</td>
                                <td>Model:</td>
                                <td>Manufacturer:</td>
                                <td>Description:</td>
                            </tr>";
            foreach (SystemComponents item in comps)
            {
                HtmlData += string.Format(@"<tr>
                                <td>{0}</td>
                                <td>{1}</td>
                                <td>{2}</td>
                                <td>{3}</td>
                                <td>{4}</td>
                            </tr>", item.CompCode, item.SysComps_Product.ProductCode, item.Model, item.Manufacturer,item.Description);
            }
            HtmlData += "</table></br>";
            HtmlData += "<h3>Configurations</h3></header>";
            HtmlData += @"<table border='1px solid white'>
                            <tr id='heading'>
                                <td>Component Code:</td>
                                <td>Name:</td>
                                <td>Description:</td>
                                <td>Additional Cost:</td>
                            </tr>";
            foreach (Configurations item in confs)
            {
                HtmlData += string.Format(@"<tr>
                                <td>{0}</td>
                                <td>{1}</td>
                                <td>{2}</td>
                                <td>R{3}</td>
                            </tr>", item.Configuration_Component.CompCode, item.Name, item.Description, item.AddCost.ToString());
            }
            HtmlData += "</table></body></html>";
            var Pdf = Renderer.RenderHtmlAsPdf(HtmlData);
            var OutputPath = contract.ContractIdentifier + DateTime.UtcNow.Year.ToString() + "_" + DateTime.UtcNow.Month.ToString() + "_" + DateTime.UtcNow.Day.ToString() + "_Contract.pdf";
            Pdf.SaveAs(OutputPath);

            System.Diagnostics.Process.Start(OutputPath);
        }

        public static void CreateSchedule(List<RequestedEvents> events)
        {
            var Renderer = new IronPdf.HtmlToPdf();
            var HtmlData = @"<html><head>
                            <style>
                               h1{font-family: 'Copperplate Gothic Bold';font-size: 24pt}
                               h2{font-family: 'Century Gothic';font-size:16pt}
                               h3{font-family: 'Century Gothic';font-size:12pt}
                               table{width: 100%;font-family: 'Century Gothic'}
                               #heading{font-weight: bold}
                            </style>
                            </head><body>";
            HtmlData += "<header><h1 align='center'>Smart Home Systems</h1><h2 align = 'center'>Job Schedule:</h2>";
            HtmlData += string.Format("<h3>{0}</h3></header>", DateTime.UtcNow.ToShortDateString());
            HtmlData += @"<table border='1px solid white'>
                            <tr id='heading'>
                                <td>Priority:</td>
                                <td>Date Requested:</td>
                                <td>Client:</td>
                                <td>Skill Required:</td>
                            </tr>";
            foreach (RequestedEvents item in events)
            {
                HtmlData += string.Format(@"<tr>
                                <td>{0}</td>
                                <td>{1}</td>
                                <td>{2}</td>
                                <td>{3}</td>
                            </tr>", item.ScheduleOrder.ToString(), item.RequestedDate.ToShortDateString(), item.TechLog_Client.Name+" "+item.TechLog_Client.Surname, item.SkillRequired);
            }
            HtmlData += "</table></body></html>";
            var Pdf = Renderer.RenderHtmlAsPdf(HtmlData);
            var OutputPath =DateTime.UtcNow.Year.ToString() + "_" + DateTime.UtcNow.Month.ToString() + "_" + DateTime.UtcNow.Day.ToString() + "_TechnicalSchedule.pdf";
            Pdf.SaveAs(OutputPath);

            System.Diagnostics.Process.Start(OutputPath);
        }
    }
}
