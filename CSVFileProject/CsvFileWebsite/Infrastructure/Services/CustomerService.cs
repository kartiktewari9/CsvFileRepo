using CsvFileProject.Common.Objects.ViewModels;
using CsvFileProject.Common.Services.Interfaces;
using CsvFileProject.Common.Services.Services;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;

namespace CsvFileWebsite.Infrastructure.Services
{
    public class CustomerService: ICustomerService
    {
        private ICsvFileReaderService _csvFileReader { get; set; }
        private ICsvFileWriterService _csvFileWriter { get; set; }

        public CustomerService(ICsvFileReaderService csvFileReader, ICsvFileWriterService csvFileWriter)
        {
            _csvFileReader = csvFileReader;
            _csvFileWriter = csvFileWriter;
        }

        public List<CustomerViewModel> GetCustomers(Stream stream)
        {
            _csvFileReader.Reader = new StreamReader(stream);
            List<string> columns = new List<string>();
            var result = new List<CustomerViewModel>();
            while (_csvFileReader.ReadRow(columns))
            {
                if (columns.Count < 5)
                    continue;
                var item = new CustomerViewModel
                {
                    Id=columns[0],
                    Name=columns[1],
                    Address=columns[2],
                    Email=columns[3],
                    Mobile=columns[4]
                };
                result.Add(item);
            }
            _csvFileReader.Dispose();
            return result;
        }

        public void WriteCustomers(Stream stream, List<CustomerViewModel> customers)
        {
            _csvFileWriter.Writer = new StreamWriter(stream);
            foreach(var customer in customers)
            {
                List<string> columns = new List<string>();
                columns.Add(customer.Id);
                columns.Add(customer.Name);
                columns.Add(customer.Address);
                columns.Add(customer.Email);
                columns.Add(customer.Mobile);

                _csvFileWriter.WriteRow(columns);
            }
            _csvFileWriter.Dispose();
        }
    }

    public interface ICustomerService
    {
        List<CustomerViewModel> GetCustomers(Stream stream);
        void WriteCustomers(Stream stream, List<CustomerViewModel> customers);
    }
}